using System;
using System.Linq;
using System.Runtime.InteropServices;
using MixSoft.sys;

namespace MixSoft.Classes
{
    public static class Extensions
    {
        #region Degrees <-> Radians

        private const double _PI_Over_180 = Math.PI / 180.0;

        private const double _180_Over_PI = 180.0 / Math.PI;

        public static double DegreeToRadian(this double degree)
        {
            return degree * _PI_Over_180;
        }

        public static double RadianToDegree(this double radian)
        {
            return radian * _180_Over_PI;
        }

        public static float DegreeToRadian(this float degree)
        {
            return (float)(degree * _PI_Over_180);
        }

        public static float RadianToDegree(this float radian)
        {
            return (float)(radian * _180_Over_PI);
        }

        #endregion


        // Get window client rectangle
        public static System.Drawing.Rectangle GetClientRectangle(IntPtr handle)
        {
            return User32.ClientToScreen(handle, out var point) && User32.GetClientRect(handle, out var rect)
                ? new System.Drawing.Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top)
                : default;
        }


        // Get module by name
        public static Module GetModule1(this System.Diagnostics.Process process, string moduleName)
        {
            var processModule = process.GetProcessModule(moduleName);
            return processModule is null || processModule.BaseAddress == IntPtr.Zero
                ? default
                : new Module(process, processModule);
        }


        // Get process module by name
        public static System.Diagnostics.ProcessModule GetProcessModule(this System.Diagnostics.Process process, string moduleName)
        {
            return process?.Modules.OfType<System.Diagnostics.ProcessModule>()
                .FirstOrDefault(a => string.Equals(a.ModuleName.ToLower(), moduleName.ToLower()));
        }


        // Check if value is infinity or NaN
        public static bool IsInfinityOrNaN(this float value)
        {
            return float.IsNaN(value) || float.IsInfinity(value);
        }


        // Is key Down?
        public static bool IsKeyDown(this WindowsVirtualKey key)
        {
            return (User32.GetAsyncKeyState((int)key) & 0x8000) != 0;
        }


        // Get if process is running
        public static bool IsRunning(this System.Diagnostics.Process process)
        {
            try
            {
                System.Diagnostics.Process.GetProcessById(process.Id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }


        // Send mouse left down
        public static void MouseLeftDown()
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTDOWN
                },
            };
            User32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }


        // Send mouse left up
        public static void MouseLeftUp()
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_LEFTUP
                },
            };
            User32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }


        // Send mouse move
        public static void MouseMove(int deltaX, int deltaY)
        {
            var mouseMoveInput = new Input
            {
                type = SendInputEventType.InputMouse,
                mi =
                {
                    dwFlags = MouseEventFlags.MOUSEEVENTF_MOVE,
                    dx = deltaX,
                    dy = deltaY,
                },
            };
            User32.SendInput(1, ref mouseMoveInput, Marshal.SizeOf<Input>());
        }


        // Read process memory
        public static T Read<T>(this System.Diagnostics.Process process, IntPtr lpBaseAddress)
            where T : unmanaged
        {
            return Read<T>(process.Handle, lpBaseAddress);
        }


        // Read process memory from module
        public static T Read<T>(this Module module, int offset)
            where T : unmanaged
        {
            return Read<T>(module.Process.Handle, module.ProcessModule.BaseAddress + offset);
        }


        // Read process memory
        public static T Read<T>(IntPtr hProcess, IntPtr lpBaseAddress)
            where T : unmanaged
        {
            var size = Marshal.SizeOf<T>();
            var buffer = (object)default(T);
            Kernel32.ReadProcessMemory(hProcess, lpBaseAddress, buffer, size, out var lpNumberOfBytesRead);
            return lpNumberOfBytesRead == size ? (T)buffer : default;
        }


        // Convert value to team
        public static Team ToTeam(this int teamNum)
        {
            switch (teamNum)
            {
                case 1:
                    return Team.Spectator;
                case 2:
                    return Team.Terrorists;
                case 3:
                    return Team.CounterTerrorists;
                default:
                    return Team.Unknown;
            }
        }
    }
}
