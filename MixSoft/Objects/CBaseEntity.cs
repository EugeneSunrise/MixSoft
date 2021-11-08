namespace MixSoft.Objects;

class EntityList
{
    private CBaseEntity[] entities = new CBaseEntity[4096];

    public EntityList()
    {
        for (int i = 0; i < entities.Length; i++)
        {
            entities[i] = new CBaseEntity(i);
        }
    }

    public CBaseEntity this[int index]
    {
        get
        {
            try
            {
                return entities[index];
            }
            catch
            {
                return null;
            }
        }
    }
}

class CBaseEntity
{
    public int index;

    public CBaseEntity(int index)
    {
        this.index = index;
    }

    public int Base
    {
        get
        {
            return Memory.Read<int>(Memory.clientBase + Offsets.Offsets.dwEntityList + index * 0x10);
        }
    }
}
