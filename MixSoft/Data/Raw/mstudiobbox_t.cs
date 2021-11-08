using System.Runtime.InteropServices;
using Microsoft.DirectX;

namespace MixSoft.Data.Raw;

[StructLayout(LayoutKind.Sequential)]
public unsafe struct mstudiobbox_t
{
    public int bone;
    public int group;                   // intersection group
    public Vector3 bbmin;               // bounding box
    public Vector3 bbmax;
    public int szhitboxnameindex;       // offset to the name of the hitbox.
    public fixed int unused[3];
    public float radius;                // when radius is -1 it's box, otherwise it's capsule (cylinder with spheres on the end)
    public fixed int pad[4];
}