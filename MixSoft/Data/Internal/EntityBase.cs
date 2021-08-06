using Microsoft.DirectX;
using System;
using MixSoft.Classes;
using MixSoft.Offsets;

namespace MixSoft.Data.Internal
{
    public abstract class EntityBase
    {
        #region Properties

        // Address base of entity
        public IntPtr AddressBase { get; protected set; }

        // Life state (true = dead, false = alive)
        public bool LifeState { get; protected set; }

        // Health points
        public int Health { get; protected set; }
        public int LocalTeam { get; protected set; }
        public IntPtr LocalPlayer { get; protected set; }
        public int rpClientState { get; protected set; }
        public int LocalPlayerIndex { get; protected set; }

        public Team Team { get; protected set; }

        // Model origin (in world)
        public Vector3 Origin { get; private set; }
        #endregion

        #region Updates
        // Is entity alive?
        public virtual bool IsAlive()
        {
            return AddressBase != IntPtr.Zero &&
                   !LifeState &&
                   Health > 0 &&
                   (Team == Team.CounterTerrorists || Team == Team.Terrorists);
        }
        protected abstract IntPtr ReadAddressBase(GameProcess gameProcess);

        
        // Update data from process
        public virtual bool Update(GameProcess gameProcess)
        {
            AddressBase = ReadAddressBase(gameProcess);
            if (AddressBase == IntPtr.Zero)
            {
                return false;
            }
            LocalPlayer = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwLocalPlayer);
            LocalTeam = Memory.Read<int>((int)(LocalPlayer + Offsets.Offsets.m_iTeamNum));
            LifeState = gameProcess.Process.Read<bool>(AddressBase + Offsets.Offsets.m_lifeState);
            Health = gameProcess.Process.Read<int>(AddressBase + Offsets.Offsets.m_iHealth);
            Team = gameProcess.Process.Read<int>(AddressBase + Offsets.Offsets.m_iTeamNum).ToTeam();
            Origin = gameProcess.Process.Read<Vector3>(AddressBase + Offsets.Offsets.m_vecOrigin);          
            return true;
        }
        #endregion
    }
}
