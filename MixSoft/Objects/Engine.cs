namespace MixSoft.Objects;
static class Engine
{
    public static int ClientStatePtr
    {
        get
        {
            return Memory.Read<int>(Memory.engineBase + Offsets.Offsets.dwClientState);
        }
    }

    public static bool InGame
    {
        get
        {
            return Memory.Read<int>(ClientStatePtr + Offsets.Offsets.dwClientState_State) == 6;
        }
    }

    public static int ForceReload
    {
        get
        {
            return Memory.Read<int>(ClientStatePtr + Offsets.Offsets.clientstate_delta_ticks);
        }
        set
        {
            Memory.Write<int>(ClientStatePtr + Offsets.Offsets.clientstate_delta_ticks, value);
        }
    }

    //public static bool SendPackets
    //{
    //    get
    //    {
    //        return Memory.Read<byte>(Memory.engineBase + Offsets.Offsets.dwbSendPackets) == 1;
    //    }
    //    set
    //    {
    //        Memory.Write<byte>(Memory.engineBase + Offsets.Offsets.dwbSendPackets, value ? (byte)0x1 : (byte)0x0);
    //    }
    //}

    public static int GetModelIndexByName(string modelName)
    {
        int modelPrecacheTable = Memory.Read<int>(ClientStatePtr + Offsets.Offsets.dwClientState_ModelPrecacheTable);
        int modelPrecacheDict = Memory.Read<int>(modelPrecacheTable + 0x40);
        int modelPrecacheDictItems = Memory.Read<int>(modelPrecacheDict + 0xC);

        for (int i = 0; i < 1024; i++)
        {
            int modelPrecacheDictItem = Memory.Read<int>(modelPrecacheDictItems + 0xC + i * 0x34);
            string modelPrecacheDictItemName = Memory.ReadString(modelPrecacheDictItem, 128, Encoding.ASCII);
            if (modelPrecacheDictItemName == modelName)
            {
                return i;
            }
        }

        return -1;
    }
}
