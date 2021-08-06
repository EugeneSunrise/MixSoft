using MixSoft.Offsets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MixSoft.Objects
{
    static class CBasePlayer
    {
        public static int LocalPlayerPtr
        {
            get
            {
                return Memory.Read<int>(Memory.clientBase + Offsets.Offsets.dwLocalPlayer);
            }
        }
        public static int GetViewModelIndex(int index)
        {
            return Memory.Read<int>(LocalPlayerPtr + Offsets.Offsets.m_hViewModel + index * 0x4) & 0xFFF;
        }
        public static int ActiveWeaponIndex
        {
            get
            {
                return Memory.Read<int>(LocalPlayerPtr + Offsets.Offsets.m_hActiveWeapon) & 0xFFF;
            }
        }
        public static int Team
        {
            get
            {
                return Memory.Read<int>(LocalPlayerPtr + Offsets.Offsets.m_iTeamNum);
            }
        }
    }
}
