namespace MixSoft;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 12)]
public struct D3DXVECTOR2 { }

public struct Vector2
{
    public float X;

    public float Y;

    public Vector2()
    {
        Y = 0f;
        X = 0f;
    }

    public Vector2(float valueX, float valueY)
    {
        X = valueX;
        Y = valueY;
    }

    public unsafe static Vector2 operator *(Vector2 left, float right)
    {
        D3DXVECTOR2 result;
        *(float*)(&result) = *(float*)(&left) * right;
        *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * right;
        return *(Vector2*)(&result);
    }
}