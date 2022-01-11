namespace MixSoft;

public struct D3DXVECTOR3 { }

public struct Vector3
{
    public float X;

    public float Y;

    public float Z;

    public Vector3()
    {
        Z = 0f;
        Y = 0f;
        X = 0f;
    }

    public Vector3(float valueX, float valueY, float valueZ)
    {
        X = valueX;
        Y = valueY;
        Z = valueZ;
    }

    public unsafe static Vector3 operator +(Vector3 left, Vector3 right)
    {
        Vector3 zak;
        zak.X = left.X + right.X;
        zak.Y = left.Y + right.Y;
        zak.Z = left.Z + right.Z;
        return zak;
    }

    public unsafe static Vector3 operator -(Vector3 left, Vector3 right)
    {
        Vector3 zak;
        zak.X = left.X - right.X;
        zak.Y = left.Y - right.Y;
        zak.Z = left.Z - right.Z;
        return zak;
    }

    public unsafe static Vector3 operator *(float right, Vector3 left)
    {
        Vector3 zak;
        zak.X = left.X * right;
        zak.Y = left.Y * right;
        zak.Z = left.Z * right;
        return zak;
    }

    public unsafe static float Dot(Vector3 left, Vector3 right)
    {
        return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) + *(float*)(&right) * *(float*)(&left);
    }

    public unsafe static Vector3 Cross(Vector3 left, Vector3 right)
    {
        Vector3 vector = default(Vector3);
        vector = new Vector3();
        D3DXVECTOR3 result;
        *(float*)(&result) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
        *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) * *(float*)(&right) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) * *(float*)(&left);
        *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) * *(float*)(&left) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * *(float*)(&right);
        return *(Vector3*)(&result);
    }

    public unsafe static Vector3 Normalize(Vector3 source)
    {
        float quickMath = (float)Math.Sqrt((source.X * source.X) + (source.Y * source.Y) + (source.Z * source.Z));
        source.X /= quickMath;
        source.Y /= quickMath;
        source.Z /= quickMath;
        return source;
    }
}