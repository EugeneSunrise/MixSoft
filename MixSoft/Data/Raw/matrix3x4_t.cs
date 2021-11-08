using System.Runtime.InteropServices;

namespace MixSoft.Data.Raw;

[StructLayout(LayoutKind.Sequential)]
public struct matrix3x4_t
{
    public float m00; // xAxis.x
    public float m10; // yAxis.x
    public float m20; // zAxis.x
    public float m30; // vecOrigin.x

    public float m01; // xAxis.y
    public float m11; // yAxis.y
    public float m21; // zAxis.y
    public float m31; // vecOrigin.y

    public float m02; // xAxis.z
    public float m12; // yAxis.z
    public float m22; // zAxis.z
    public float m32; // vecOrigin.z
}
