using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MixSoft.Offsets
{
    public static class OffsetManager
    {
        public static void ScanOffsets()
        {
            #region SigScan
            Offsets.dwLocalPlayer = SigScanner.ClientSigScan("8D 34 85 ? ? ? ? 89 15 ? ? ? ? 8B 41 08 8B 48 04 83 F9 FF", 3, 4, true);
            Offsets.dwForceJump = SigScanner.ClientSigScan("8B 0D ? ? ? ? 8B D6 8B C1 83 CA 02", 2, 0, true);
            Offsets.dwEntityList = SigScanner.ClientSigScan("BB ? ? ? ? 83 FF 01 0F 8C ? ? ? ? 3B F8", 1, 0, true);
            Offsets.dwGlowObjectManager = SigScanner.ClientSigScan("A1 ? ? ? ? A8 01 75 4B", 1, 4, true);
            Offsets.dwPlayerResource = SigScanner.ClientSigScan("8B 3D ? ? ? ? 85 FF 0F 84 ? ? ? ? 81 C7", 2, 0, true);
            Offsets.dwClientState_ViewAngles = SigScanner.EngineSigScan("F3 0F 11 86 ? ? ? ? F3 0F 10 44 24 ? F3 0F 11 86", 4, 0, false);
            Offsets.dwViewMatrix = SigScanner.ClientSigScan("0F 10 05 ? ? ? ? 8D 85 ? ? ? ? B9", 3, 176, true);
            Offsets.dwClientState = SigScanner.EngineSigScan("A1 ? ? ? ? 33 D2 6A 00 6A 00 33 C9 89 B0", 1, 0, true);
            Offsets.dwForceAttack = SigScanner.ClientSigScan("89 0D ? ? ? ? 8B 0D ? ? ? ? 8B F2 8B C1 83 CE 04", 2, 0, true);
            Offsets.m_pStudioHdr = SigScanner.ClientSigScan("8B B6 ? ? ? ? 85 F6 74 05 83 3E 00 75 02 33 F6 F3 0F 10 44 24", 2, 0, false);
            Offsets.m_bDormant = SigScanner.ClientSigScan("8A 81 ? ? ? ? C3 32 C0", 2, 8, false);
            Offsets.clientstate_delta_ticks = SigScanner.EngineSigScan("C7 87 ? ? ? ? ? ? ? ? FF 15 ? ? ? ? 83 C4 08", 2, 0, false);
            Offsets.dwClientState_ModelPrecacheTable = SigScanner.EngineSigScan("0C 3B 81 ? ? ? ? 75 11 8B 45 10 83 F8 01 7C 09 50 83", 3, 0, false);
            Offsets.dwClientState_State = SigScanner.EngineSigScan("83 B8 ? ? ? ? ? 0F 94 C0 C3", 2, 0, false);
            Offsets.dwClientState_GetLocalPlayer = SigScanner.EngineSigScan("8B 80 ? ? ? ? 40 C3", 2, 0, false);
            #endregion

            GC.Collect();

            #region NetvarScan
            Offsets.m_dwBoneMatrix = 28 + NetvarManager.GetOffsetByName("DT_BaseAnimating", "m_nForceBone");
            Offsets.m_fFlags = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_fFlags");
            Offsets.m_iTeamNum = NetvarManager.GetOffsetByName("DT_BasePlayer", "m_iTeamNum");
            Offsets.m_iHealth = NetvarManager.GetOffsetByName("DT_BasePlayer", "m_iHealth");
            Offsets.m_bSpotted = NetvarManager.GetOffsetByName("DT_BaseEntity", "m_bSpotted");
            Offsets.m_bSpottedByMask = NetvarManager.GetOffsetByName("DT_BaseEntity", "m_bSpottedByMask");
            Offsets.m_iGlowIndex = 24 + NetvarManager.GetOffsetByName("DT_CSPlayer", "m_flFlashDuration");
            Offsets.m_flFlashDuration = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_flFlashDuration");
            Offsets.m_vecViewOffset = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_vecViewOffset[0]");
            Offsets.m_aimPunchAngle = NetvarManager.GetOffsetByName("DT_BasePlayer", "m_aimPunchAngle");
            Offsets.m_hActiveWeapon = NetvarManager.GetOffsetByName("DT_BasePlayer", "m_hActiveWeapon");
            Offsets.m_iFOV = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_iFOV");
            Offsets.m_lifeState = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_lifeState");
            Offsets.m_vecOrigin = NetvarManager.GetOffsetByName("DT_BasePlayer", "m_vecOrigin");
            Offsets.m_iAccountID = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_iAccountID");
            Offsets.m_iItemDefinitionIndex = NetvarManager.GetOffsetByName("DT_BaseCombatWeapon", "m_iItemDefinitionIndex");
            Offsets.m_OriginalOwnerXuidHigh = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_OriginalOwnerXuidHigh");
            Offsets.m_OriginalOwnerXuidLow = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_OriginalOwnerXuidLow");
            Offsets.m_iItemIDHigh = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_iItemIDHigh");
            Offsets.m_nFallbackPaintKit = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_nFallbackPaintKit");
            Offsets.m_flFallbackWear = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_flFallbackWear");
            Offsets.m_nFallbackStatTrak = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_nFallbackStatTrak");
            Offsets.m_nFallbackSeed = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_nFallbackSeed");
            Offsets.m_szCustomName = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_szCustomName");
            Offsets.m_hMyWeapons = -256 + NetvarManager.GetOffsetByName("DT_BasePlayer", "m_hActiveWeapon");
            Offsets.m_hViewModel = NetvarManager.GetOffsetByName("DT_CSPlayer", "m_hViewModel[0]");
            Offsets.m_nModelIndex = NetvarManager.GetOffsetByName("DT_BaseViewModel", "m_nModelIndex");
            Offsets.m_nSequence = NetvarManager.GetOffsetByName("DT_BaseViewModel", "m_nSequence");
            Offsets.m_iViewModelIndex = NetvarManager.GetOffsetByName("DT_WeaponCSBase", "m_iViewModelIndex");
            Offsets.m_iEntityQuality = NetvarManager.GetOffsetByName("DT_BaseAttributableItem", "m_iEntityQuality");
            #endregion
        }
    }
}
