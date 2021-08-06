using Microsoft.DirectX;
using MixSoft.Classes;
using MixSoft.Data;
using MixSoft.Gfx.Math;
using MixSoft.Objects;
using MixSoft.sys;
using System;
using System.Threading;
using Point = System.Drawing.Point;

namespace MixSoft.Hacks
{
    public class AimBot :
        ThreadedComponent
    {
        #region Properties     
        public Team Team { get; protected set; }

        /// Moving mouse one pixel will give this much of view angle change (in radians).
        /// </summary>
        private double AnglePerPixel { get; set; } = 0.00057596609244744;


        /// Bone id to aim for, 8 = head, 5 = body etc.
        /// </summary>
        public int AimBoneId = 8;


        /// Aim bot field of view (fov) to find targets (in radians).
        /// </summary>
        public static float AimBotFov { get; set; } = 2f.DegreeToRadian();


        /// Parameter to control smoothness of aim bot [1..N].
        /// 1 = no smoothing, bigger number - more smoothing
        /// </summary>
        public float AimBotSmoothing { get; set; } = 5;

        /// <inheritdoc />
        protected override string ThreadName => nameof(AimBot);

        /// <inheritdoc cref="GameProcess"/>
        private GameProcess GameProcess { get; set; }

        /// <inheritdoc cref="GameData"/>
        private GameData GameData { get; set; }


        /// Global mouse hook.
        /// </summary>
        private GlobalHook MouseHook { get; set; }


        /// Synchronization object for <see cref="State"/>.
        /// </summary>
        private readonly object StateLock = new object();

        /// <inheritdoc cref="AimBotState"/>
        private AimBotState State { get; set; }

        #endregion

        #region Ctor & Dispose

        /// <summary />
        public AimBot(GameProcess gameProcess, GameData gameData)
        {
            GameProcess = gameProcess;
            GameData = gameData;
            MouseHook = new GlobalHook(HookType.WH_MOUSE_LL, MouseHookCallback);
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            base.Dispose();

            MouseHook.Dispose();
            MouseHook = default;
            GameData = default;
            GameProcess = default;
        }

        #endregion

        #region Aim

        /// <inheritdoc cref="HookProc"/>
        private IntPtr MouseHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            return nCode < 0 || ProcessMouseMessage((MouseMessage)wParam)
                ? User32.CallNextHookEx(MouseHook.HookHandle, nCode, wParam, lParam)    // continue
                : new IntPtr(1);                                                        // suppress
        }


        /// Control <see cref="State"/> based on mouse input.
        /// </summary>
        private bool ProcessMouseMessage(MouseMessage mouseMessage)
        {
            if (mouseMessage == MouseMessage.WM_LBUTTONUP)
            {
                // left mouser up
                lock (StateLock)
                {
                    // no matter what state it was before, we just released left mouse, therefore get to idle state
                    State = AimBotState.Up;
                }
                return true;
            }


            if (mouseMessage == MouseMessage.WM_LBUTTONDOWN)
            {
                if (!GameProcess.IsValid || !GameData.Player.IsAlive())
                {
                    return true;
                }

                // left mouse down
                lock (StateLock)
                {
                    if (State == AimBotState.Up)
                    {
                        // change state and signal to not call CallNextHookEx (stop this left mouse down)
                        State = AimBotState.DownSuppressed;
                        return false;
                    }
                }
            }
            return true;
        }

        /// <inheritdoc />
        protected override void FrameAction()
        {
            if (!GameProcess.IsValid || !GameData.Player.IsAlive())
            {
                return;
            }
         

            lock (StateLock)
            {
                if (State == AimBotState.Up)
                {
                    // idle state, still waiting for suppressed state
                    return;
                }
            }

            // get and validate aim target
            var aimPixels = Point.Empty;
            if (GetAimTarget(out var aimAngles))
            {
                // get pixels to move
                GetAimPixels(aimAngles, out aimPixels);
            }

            // try mouse down to get into normal state
            var wait = TryMouseDown();

            // try to move mouse on a target
            wait |= TryMouseMove(aimPixels);

            // give time for csgo to process simulated input
            if (wait)
            {
                // arbitrary amount of wait
                Thread.Sleep(20);
            }
        }

        /// Get aim target.
        /// </summary>
        /// <param name="aimAngles">Euler angles to aim target (in radians).</param>
        /// <returns>
        /// <see langword="true"/> if aim target was found.
        /// </returns>
        
        private bool GetAimTarget(out Vector2 aimAngles)
        {
            WeaponList _weaponList = new WeaponList();
            bool isMate;
            var minAngleSize = float.MaxValue;
            aimAngles = new Vector2((float)Math.PI, (float)Math.PI);
            var targetFound = false;
            foreach (var entity in GameData.Entities)
           {
                isMate = entity.Team == entity.LocalTeam.ToTeam() ? true : false;
                // validate
                if (isMate
                    || _weaponList.ActiveWeapon.IsGrenade()
                    || _weaponList.ActiveWeapon.IsC4orTaser()
                    || _weaponList.ActiveWeapon.IsKnife()
                    || !entity.IsAlive()
                    || entity.AddressBase == GameData.Player.AddressBase)
                {
                    continue;
                }
           
                // get angle to bone
                GetAimAngles(entity.BonesPos[AimBoneId], out var angleToBoneSize, out var anglesToBone);
                // let it only be inside fov search space
                if (angleToBoneSize > AimBotFov)
                {
                    continue;
                }

                // check if it's closer
                if (angleToBoneSize < minAngleSize)
                {
                    minAngleSize = angleToBoneSize;
                    aimAngles = anglesToBone;
                    targetFound = true;
                }
            }

            // smooth angles
            if (targetFound)
            {
                aimAngles *= 1 / Math.Max(AimBotSmoothing, 1);
            }

            return targetFound;
        }

        /// Get aim angle to a point.
        /// </summary>
        /// <param name="pointWorld">A point (in world) to which aim angles are calculated.</param>
        /// <param name="angleSize">Angle size (in radians) between aim direction and desired aim direction (direction to <see cref="pointWorld"/>).</param>
        /// <param name="aimAngles">Euler angles to aim target (in radians).</param>
        private void GetAimAngles(Vector3 pointWorld, out float angleSize, out Vector2 aimAngles)
        {
            var aimDirection = GameData.Player.AimDirection;
            var aimDirectionDesired = (pointWorld - GameData.Player.EyePosition).Normalized();
            angleSize = aimDirection.AngleTo(aimDirectionDesired);
            aimAngles = new Vector2
            (
                aimDirectionDesired.AngleToSigned(aimDirection, new Vector3(0, 0, 1)),
                aimDirectionDesired.AngleToSigned(aimDirection, aimDirectionDesired.Cross(new Vector3(0, 0, 1)).Normalized())
            );
        }


        /// Get pixels to move in a screen (from aim angles).
        /// </summary>
        private void GetAimPixels(Vector2 aimAngles, out Point aimPixels)
        {
            var fovRatio = 90.0 / GameData.Player.Fov;
            aimPixels = new Point
            (
                (int)Math.Round(aimAngles.X / AnglePerPixel * fovRatio),
                (int)Math.Round(aimAngles.Y / AnglePerPixel * fovRatio)
            );
        }


        /// Try to simulate mouse move.
        /// </summary>
        private bool TryMouseMove(Point aimPixels)
        {
            if (aimPixels.X == 0 && aimPixels.Y == 0)
            {
                return false;
            }

            Classes.Extensions.MouseMove(aimPixels.X, aimPixels.Y);
            return true;
        }


        /// Try release suppressed mouse down.
        /// </summary>
        private bool TryMouseDown()
        {
            var mouseDown = false;

            lock (StateLock)
            {
                if (State == AimBotState.DownSuppressed)
                {
                    mouseDown = true;
                    State = AimBotState.Down;
                }
            }

            if (mouseDown)
            {
                Classes.Extensions.MouseLeftDown();
            }

            return mouseDown;
        }

        #endregion
    }

    #region AimBotState

    /// Aim bot state.
    /// </summary>
    public enum AimBotState
    {

        /// Hot key is up, waiting for it to be pressed.
        /// </summary>
        Up,


        /// Hot key was pressed and suppressed.
        /// </summary>
        DownSuppressed,


        /// Hot key down simulated (suppress released).
        /// </summary>
        Down,
    }
    #endregion
}
