using System.Runtime.InteropServices;

namespace MixSoft.Data.Raw;

[StructLayout(LayoutKind.Sequential)]
public struct mstudiohitboxset_t
{
    public int sznameindex;
    public int numhitboxes;
    public int hitboxindex;
}