namespace MixSoft.Objects;
class CCSPlayer : CBaseEntity
{
    public CCSPlayer(int index) : base(index)
    {
    }

    public CCSPlayer(CBaseEntity baseEnt) : base(baseEnt.index)
    {
    }
}
