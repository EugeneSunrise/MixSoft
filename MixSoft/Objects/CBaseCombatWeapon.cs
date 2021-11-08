namespace MixSoft.Objects;

#region WeaponList
class WeaponList
{
    private CBaseCombatWeapon[] weapons = new CBaseCombatWeapon[16];

    public WeaponList()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = new CBaseCombatWeapon(i);
        }
    }

    public CBaseCombatWeapon this[int index]
    {
        get
        {
            try
            {
                return weapons[index];
            }
            catch
            {
                return null;
            }
        }
    }

    public CBaseCombatWeapon ActiveWeapon
    {
        get
        {
            return new CBaseCombatWeapon((IntPtr)CBasePlayer.ActiveWeaponIndex);
        }
    }
}
#endregion

#region CBaseCombatWeapon
class CBaseCombatWeapon
{
    public int Index { get; private set; }

    public CBaseCombatWeapon(int index)
    {
        this.Index = index;
    }

    public CBaseCombatWeapon(IntPtr ptr)
    {
        this.Ptr = (int)ptr;
    }

    private int _Ptr = -1;
    private int Ptr
    {
        get
        {
            if (_Ptr != -1) return _Ptr;
            return Memory.Read<int>(CBasePlayer.LocalPlayerPtr + Offsets.Offsets.m_hMyWeapons + Index * 0x4) & 0xFFF;
        }
        set
        {
            _Ptr = value;
        }
    }

    public int Base
    {
        get
        {
            return Memory.Read<int>(Memory.clientBase + Offsets.Offsets.dwEntityList + (Ptr - 1) * 0x10);
        }
    }

    #region SkinSDK
    public int ItemDefinitionIndex
    {
        get
        {
            return Memory.Read<short>(Base + Offsets.Offsets.m_iItemDefinitionIndex);
        }
        set
        {
            Memory.Write<short>(Base + Offsets.Offsets.m_iItemDefinitionIndex, value);
        }

    }

    public int AccountID
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_iAccountID);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_iAccountID, value);
        }
    }

    public int XuIDLow
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_OriginalOwnerXuidLow);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_OriginalOwnerXuidLow, value);
        }
    }

    public int ItemIDHigh
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_iItemIDHigh);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_iItemIDHigh, value);
        }
    }

    public int PaintKit
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_nFallbackPaintKit);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_nFallbackPaintKit, value);
        }
    }

    public float Wear
    {
        get
        {
            return Memory.Read<float>(Base + Offsets.Offsets.m_flFallbackWear);
        }
        set
        {
            Memory.Write<float>(Base + Offsets.Offsets.m_flFallbackWear, value);
        }
    }

    public int StatTrak
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_nFallbackStatTrak);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_nFallbackStatTrak, value);
        }
    }

    public int Seed
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_nFallbackSeed);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_nFallbackSeed, value);
        }
    }

    public string CustomName
    {
        set
        {
            Memory.Write<char[]>(Base + Offsets.Offsets.m_szCustomName, value.ToCharArray());
        }
    }

    public int EntityQuality
    {
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_iEntityQuality, value);
        }
    }
    #endregion

    #region KnifeSDK
    public int ViewModelIndex
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_iViewModelIndex);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_iViewModelIndex, value);
        }
    }

    private int ViewModelBase
    {
        get
        {
            return Memory.Read<int>(Memory.clientBase + Offsets.Offsets.dwEntityList + (CBasePlayer.GetViewModelIndex(0) - 1) * 0x10);
        }
    }

    /**
     * USE ONLY ON ACTIVE WEAPON !!!
     */
    public int ViewModelEntityModelIndex
    {
        get
        {
            return Memory.Read<int>(ViewModelBase + Offsets.Offsets.m_nModelIndex);
        }
        set
        {
            Memory.Write<int>(ViewModelBase + Offsets.Offsets.m_nModelIndex, value);
        }
    }

    public int Sequence
    {
        get
        {
            return Memory.Read<int>(ViewModelBase + Offsets.Offsets.m_nSequence);
        }
        set
        {
            Memory.Write<int>(ViewModelBase + Offsets.Offsets.m_nSequence, value);
        }
    }

    public int ModelIndex
    {
        get
        {
            return Memory.Read<int>(Base + Offsets.Offsets.m_nModelIndex);
        }
        set
        {
            Memory.Write<int>(Base + Offsets.Offsets.m_nModelIndex, value);
        }
    }
    #endregion

    #region Checks 
    public bool IsKnife()
    {
        int index = ItemDefinitionIndex;
        return index == (int)Structs.ItemDefinitionIndex.CTKNIFE ||
            index == (int)Structs.ItemDefinitionIndex.TKNIFE ||
            index == (int)Structs.ItemDefinitionIndex.BAYONET ||
            index == (int)Structs.ItemDefinitionIndex.GUT ||
            index == (int)Structs.ItemDefinitionIndex.KARAMBIT ||
            index == (int)Structs.ItemDefinitionIndex.FLIP ||
            index == (int)Structs.ItemDefinitionIndex.BUTTERFLY ||
            index == (int)Structs.ItemDefinitionIndex.HUNTSMAN ||
            index == (int)Structs.ItemDefinitionIndex.FALCHION ||
            index == (int)Structs.ItemDefinitionIndex.M9BAYONET ||
            index == (int)Structs.ItemDefinitionIndex.URSUS ||
            index == (int)Structs.ItemDefinitionIndex.NAVAJA ||
            index == (int)Structs.ItemDefinitionIndex.STILETTO ||
            index == (int)Structs.ItemDefinitionIndex.TALON ||
            index == (int)Structs.ItemDefinitionIndex.CSS ||
            //index == (int)Structs.ItemDefinitionIndex.PUSH ||
            //index == (int)Structs.ItemDefinitionIndex.BOWIE ||
            index == (int)Structs.ItemDefinitionIndex.PARACORD ||
            index == (int)Structs.ItemDefinitionIndex.SURVIVAL ||
            index == (int)Structs.ItemDefinitionIndex.SKELETON ||
            index == (int)Structs.ItemDefinitionIndex.NOMAD;
    }

    public bool IsGrenade()
    {
        int WEAPON_FLASHBANG = 43;
        int WEAPON_HEGRENADE = 44;
        int WEAPON_INCGRENADE = 48;
        int WEAPON_MOLOTOV = 46;
        int WEAPON_SMOKEGRENADE = 45;
        int WEAPON_DECOY = 47;

        int index = ItemDefinitionIndex;
        return index == WEAPON_FLASHBANG ||
            index == WEAPON_HEGRENADE ||
            index == WEAPON_INCGRENADE ||
            index == WEAPON_MOLOTOV ||
            index == WEAPON_DECOY ||
            index == WEAPON_SMOKEGRENADE;
    }
    public bool IsC4orTaser()
    {
        int WEAPON_C4 = 49;
        int WEAPON_TASER = 31;

        int index = ItemDefinitionIndex;
        return index == WEAPON_C4 ||
            index == WEAPON_TASER;
    }

    #endregion
}
#endregion
