

namespace MixSoft
{
    [Serializable]
    //[MiscellaneousBits(1)]
    public struct Quaternion
    {
        public float X;

        public float Y;

        public float Z;

        public float W;

        public unsafe static Quaternion Identity
        {
            get
            {
                Quaternion result = default(Quaternion);
                result = new Quaternion();
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = 0f;
                *(float*)(&result) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = 1f;
                return result;
            }
        }

        public static Quaternion Zero
        {
            get
            {
                Quaternion quaternion = default(Quaternion);
                return new Quaternion();
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe override bool Equals(object compare)
        {
            if (compare == null)
            {
                return false;
            }

            if ((object)compare.GetType() != typeof(Quaternion))
            {
                return false;
            }

            Quaternion quaternion = (Quaternion)((compare is Quaternion) ? compare : null);
            Quaternion quaternion2 = this;
            int num = (*(float*)(&quaternion2) == *(float*)(&quaternion) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion2, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion, 4))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion2, 8))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion, 8))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion2, 12))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref quaternion, 12)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator ==(Quaternion left, Quaternion right)
        {
            int num = (*(float*)(&left) == *(float*)(&right) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator !=(Quaternion left, Quaternion right)
        {
            int num = (*(float*)(&left) != *(float*)(&right) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        public override int GetHashCode()
        {
            return (int)(double)W ^ (int)(double)Z ^ (int)(double)Y ^ (int)(double)X;
        }

        public Quaternion()
        {
            W = 0f;
            Z = 0f;
            Y = 0f;
            X = 0f;
        }

        public Quaternion(float valueX, float valueY, float valueZ, float valueW)
        {
            X = valueX;
            Y = valueY;
            Z = valueZ;
            W = valueW;
        }

        //public unsafe override string ToString()
        //{
        //    object obj = this;
        //    Type type = obj.GetType();
        //    StringBuilder stringBuilder = new StringBuilder();
        //    PropertyInfo[] properties = type.GetProperties();
        //    int num = 0;
        //    if (0 < (nint)properties.LongLength)
        //    {
        //        do
        //        {
        //            MethodInfo getMethod = properties[num].GetGetMethod();
        //            if ((object)getMethod != null && !getMethod.IsStatic)
        //            {
        //                object obj2 = getMethod.Invoke(obj, null);
        //                string[] array = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_002411_0024];
        //                array[0] = properties[num].Name;
        //                string text = array[1] = ((obj2 == null) ? string.Empty : obj2.ToString());
        //                stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref ModuleOld._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array));
        //            }

        //            num++;
        //        }
        //        while (num < (nint)properties.LongLength);
        //    }

        //    FieldInfo[] fields = type.GetFields();
        //    int num2 = 0;
        //    if (0 < (nint)fields.LongLength)
        //    {
        //        do
        //        {
        //            object value = fields[num2].GetValue(obj);
        //            string[] array2 = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_002412_0024];
        //            array2[0] = fields[num2].Name;
        //            array2[1] = value.ToString();
        //            stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref ModuleOld._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array2));
        //            num2++;
        //        }
        //        while (num2 < (nint)fields.LongLength);
        //    }

        //    return stringBuilder.ToString();
        //}

        public unsafe static Quaternion operator +(Quaternion left, Quaternion right)
        {
            D3DXQUATERNION result;
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12)));
            return *(Quaternion*)(&result);

        }

        public unsafe static Quaternion operator *(Quaternion left, Quaternion right)
        {
            D3DXQUATERNION result;
            ModuleOld.D3DXQuaternionMultiply(&result, (D3DXQUATERNION*)(&left), (D3DXQUATERNION*)(&right));
            return *(Quaternion*)(&result);
        }

        public unsafe static Quaternion operator -(Quaternion left, Quaternion right)
        {
            D3DXQUATERNION result;
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12)));
            return *(Quaternion*)(&result);
        }

        public static Quaternion Add(Quaternion m1, Quaternion m2)
        {
            return m1 + m2;
        }

        public static Quaternion Subtract(Quaternion m1, Quaternion m2)
        {
            return m1 - m2;
        }

        public unsafe float Length()
        {
            fixed (Quaternion* ptr = &this)
            {
                //fixed ()
                //{
                Quaternion* ptr2 = ptr;
                float num = *(float*)(ptr2 + 12);
                float num2 = *(float*)(ptr2 + 8);
                float num3 = *(float*)(ptr2 + 4);
                float num4 = *(float*)ptr2;
                return (float)Math.Sqrt(num4 * num4 + num3 * num3 + num2 * num2 + num * num);
                //}
            }
        }

        public unsafe static float Length(Quaternion v)
        {
            return (float)Math.Sqrt(*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 12))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 12))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 4))) + *(float*)(&v) * *(float*)(&v));
        }

        public unsafe float LengthSq()
        {
            fixed (Quaternion* ptr = &this)
            {
                //fixed ()
                //{
                Quaternion* ptr2 = ptr;
                float num = *(float*)(ptr2 + 12);
                float num2 = *(float*)(ptr2 + 8);
                float num3 = *(float*)(ptr2 + 4);
                float num4 = *(float*)ptr2;
                return num4 * num4 + num3 * num3 + num2 * num2 + num * num;
                //}
            }
        }

        public unsafe static float LengthSq(Quaternion v)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 12))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 12))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 4))) + *(float*)(&v) * *(float*)(&v);
        }

        public unsafe static float Dot(Quaternion v1, Quaternion v2)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v2, 12))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v1, 12))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v2, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v1, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v2, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v1, 4))) + *(float*)(&v2) * *(float*)(&v1);
        }

        public unsafe static Quaternion Conjugate(Quaternion q)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            *(float*)(&result) = 0f - *(float*)(&q);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = 0f - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref q, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = 0f - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref q, 8)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref q, 12)));
            return result;
        }

        public unsafe static void ToAxisAngle(Quaternion q, ref Vector3 axis, ref float angle)
        {
            Vector3 vector = default(Vector3);
            vector = new Vector3();
            float num;
            ModuleOld.D3DXQuaternionToAxisAngle((D3DXQUATERNION*)(&q), (D3DXVECTOR3*)(&vector), &num);
            axis = vector;
            angle = num;
        }

        public unsafe static Quaternion RotationMatrix(Matrix m)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionRotationMatrix((D3DXQUATERNION*)(&result), (D3DXMATRIX*)(&m));
            return result;
        }

        public unsafe static Quaternion RotationAxis(Vector3 v, float angle)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionRotationAxis((D3DXQUATERNION*)(&result), (D3DXVECTOR3*)(&v), angle);
            return result;
        }

        public unsafe static Quaternion RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionRotationYawPitchRoll((D3DXQUATERNION*)(&result), yaw, pitch, roll);
            return result;
        }

        public unsafe void Multiply(Quaternion q)
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionMultiply((D3DXQUATERNION*)ptr, (D3DXQUATERNION*)ptr, (D3DXQUATERNION*)(&q));
            }
        }

        public unsafe static Quaternion Multiply(Quaternion m1, Quaternion m2)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionMultiply((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&m1), (D3DXQUATERNION*)(&m2));
            return result;
        }

        public unsafe void Normalize()
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionNormalize((D3DXQUATERNION*)ptr, (D3DXQUATERNION*)ptr);
            }
        }

        public unsafe static Quaternion Normalize(Quaternion q)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionNormalize((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q));
            return result;
        }

        public unsafe void Invert()
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionInverse((D3DXQUATERNION*)ptr, (D3DXQUATERNION*)ptr);
            }
        }

        public unsafe static Quaternion Invert(Quaternion q)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionInverse((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q));
            return result;
        }

        public unsafe void Ln()
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionLn((D3DXQUATERNION*)ptr, (D3DXQUATERNION*)ptr);
            }
        }

        public unsafe static Quaternion Ln(Quaternion q)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionLn((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q));
            return result;
        }

        public unsafe void Exp()
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionExp((D3DXQUATERNION*)ptr, (D3DXQUATERNION*)ptr);
            }
        }

        public unsafe static Quaternion Exp(Quaternion q)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionExp((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q));
            return result;
        }

        public unsafe static Quaternion Slerp(Quaternion q1, Quaternion q2, float t)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionSlerp((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q1), (D3DXQUATERNION*)(&q2), t);
            return result;
        }

        public unsafe static Quaternion Squad(Quaternion q1, Quaternion a, Quaternion b, Quaternion c, float t)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionSquad((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q1), (D3DXQUATERNION*)(&a), (D3DXQUATERNION*)(&b), (D3DXQUATERNION*)(&c), t);
            return result;
        }

        public unsafe static Quaternion BaryCentric(Quaternion q1, Quaternion q2, Quaternion q3, float f, float g)
        {
            Quaternion result = default(Quaternion);
            result = new Quaternion();
            ModuleOld.D3DXQuaternionBaryCentric((D3DXQUATERNION*)(&result), (D3DXQUATERNION*)(&q1), (D3DXQUATERNION*)(&q2), (D3DXQUATERNION*)(&q3), f, g);
            return result;
        }

        public unsafe static void SquadSetup(ref Quaternion outA, ref Quaternion outB, ref Quaternion outC, Quaternion q0, Quaternion q1, Quaternion q2, Quaternion q3)
        {
            Quaternion quaternion = default(Quaternion);
            quaternion = new Quaternion();
            Quaternion quaternion2 = default(Quaternion);
            quaternion2 = new Quaternion();
            Quaternion quaternion3 = default(Quaternion);
            quaternion3 = new Quaternion();
            ModuleOld.D3DXQuaternionSquadSetup((D3DXQUATERNION*)(&quaternion), (D3DXQUATERNION*)(&quaternion2), (D3DXQUATERNION*)(&quaternion3), (D3DXQUATERNION*)(&q0), (D3DXQUATERNION*)(&q1), (D3DXQUATERNION*)(&q2), (D3DXQUATERNION*)(&q3));
            outA = quaternion;
            outB = quaternion2;
            outC = quaternion3;
        }

        public unsafe void RotateMatrix(Matrix m)
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionRotationMatrix((D3DXQUATERNION*)ptr, (D3DXMATRIX*)(&m));
            }
        }

        public unsafe void RotateAxis(Vector3 v, float angle)
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionRotationAxis((D3DXQUATERNION*)ptr, (D3DXVECTOR3*)(&v), angle);
            }
        }

        public unsafe void RotateYawPitchRoll(float yaw, float pitch, float roll)
        {
            fixed (Quaternion* ptr = &this)
            {
                ModuleOld.D3DXQuaternionRotationYawPitchRoll((D3DXQUATERNION*)ptr, yaw, pitch, roll);
            }
        }
    }
}