

namespace MixSoft
{
    [Serializable]
    //[MiscellaneousBits(1)]
    public struct Vector3
    {
        public float X;

        public float Y;

        public float Z;

        public static Vector3 Empty
        {
            get
            {
                Vector3 vector = default(Vector3);
                return new Vector3(0f, 0f, 0f);
            }
        }

        public override int GetHashCode()
        {
            return (int)(double)Z ^ (int)(double)Y ^ (int)(double)X;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe override bool Equals(object compare)
        {
            if (compare == null)
            {
                return false;
            }

            if ((object)compare.GetType() != typeof(Vector3))
            {
                return false;
            }

            Vector3 vector = (Vector3)((compare is Vector3) ? compare : null);
            Vector3 vector2 = this;
            int num = (*(float*)(&vector2) == *(float*)(&vector) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector2, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector, 4))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector2, 8))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector, 8)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator ==(Vector3 left, Vector3 right)
        {
            int num = (*(float*)(&left) == *(float*)(&right) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator !=(Vector3 left, Vector3 right)
        {
            int num = (*(float*)(&left) != *(float*)(&right) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

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
        //                string[] array = new string[Module._0024ConstGCArrayBound_00240x33fa5e40_00247_0024];
        //                array[0] = properties[num].Name;
        //                string text = array[1] = ((obj2 == null) ? string.Empty : obj2.ToString());
        //                stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref Module._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array));
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
        //            string[] array2 = new string[Module._0024ConstGCArrayBound_00240x33fa5e40_00248_0024];
        //            array2[0] = fields[num2].Name;
        //            array2[1] = value.ToString();
        //            stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref Module._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array2));
        //            num2++;
        //        }
        //        while (num2 < (nint)fields.LongLength);
        //    }

        //    return stringBuilder.ToString();
        //}

        public unsafe static Vector3 operator -(Vector3 vec)
        {
            D3DXVECTOR3 d3DXVECTOR;
            *(float*)(&d3DXVECTOR) = 0f - *(float*)(&vec);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 4))) = 0f - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vec, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 8))) = 0f - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vec, 8)));
            return *(Vector3*)(&d3DXVECTOR);
        }

        public unsafe static Vector3 operator +(Vector3 left, Vector3 right)
        {
            D3DXVECTOR3 result;
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            return *(Vector3*)(&result);
        }

        public unsafe static Vector3 operator -(Vector3 left, Vector3 right)
        {
            D3DXVECTOR3 result;
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            return *(Vector3*)(&result);
        }

        public unsafe static Vector3 operator *(float right, Vector3 left)
        {
            D3DXVECTOR3 result;
            *(float*)(&result) = *(float*)(&left) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) * right;
            return *(Vector3*)(&result);
        }

        public unsafe static Vector3 operator *(Vector3 left, float right)
        {
            D3DXVECTOR3 result;
            *(float*)(&result) = *(float*)(&left) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) * right;
            return *(Vector3*)(&result);
        }

        public static Vector3 Multiply(Vector3 source, float f)
        {
            return source * f;
        }

        public unsafe void Multiply(float s)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                Vector3* ptr2 = ptr;
                D3DXVECTOR3 d3DXVECTOR;
                *(float*)(&d3DXVECTOR) = *(float*)ptr2 * s;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 4))) = *(float*)(ptr2 + 4) * s;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 8))) = *(float*)(ptr2 + 8) * s;
                // IL cpblk instruction
                Unsafe.CopyBlock(ref *(byte*)(ptr), ref *(byte*)(&d3DXVECTOR), 12);
                //}
            }
        }

        public unsafe float Length()
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                Vector3* ptr2 = ptr;
                float num = *(float*)(ptr2 + 8);
                float num2 = *(float*)(ptr2 + 4);
                float num3 = *(float*)ptr2;
                return (float)Math.Sqrt(num3 * num3 + num2 * num2 + num * num);
                //}
            }
        }

        public unsafe static float Length(Vector3 source)
        {
            return (float)Math.Sqrt(*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) + *(float*)(&source) * *(float*)(&source));
        }

        public unsafe float LengthSq()
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                Vector3* ptr2 = ptr;
                float num = *(float*)(ptr2 + 8);
                float num2 = *(float*)(ptr2 + 4);
                float num3 = *(float*)ptr2;
                return num3 * num3 + num2 * num2 + num * num;
                //}
            }
        }

        public unsafe static float LengthSq(Vector3 source)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) + *(float*)(&source) * *(float*)(&source);
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

        public unsafe void Add(Vector3 source)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector3* ptr3 = ptr;
                Vector3* ptr2 = ptr;
                *(float*)ptr2 = *(float*)ptr3 + *(float*)(&source);
                *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)));
                *(float*)(ptr2 + 8) = *(float*)(ptr3 + 8) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8)));
                //    }
                //}
            }
        }

        public unsafe static Vector3 Add(Vector3 left, Vector3 right)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            return result;
        }

        public unsafe void Subtract(Vector3 source)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed (Vector3* ptr3 = ptr)
                //{
                //    fixed (Vector3* ptr2 = ptr)
                //    {
                Vector3* ptr3 = ptr;
                Vector3* ptr2 = ptr;
                *(float*)ptr2 = *(float*)ptr3 - *(float*)(&source);
                *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)));
                *(float*)(ptr2 + 8) = *(float*)(ptr3 + 8) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8)));
                //    }
                //}
            }
        }

        public unsafe static Vector3 Subtract(Vector3 left, Vector3 right)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            return result;
        }

        public unsafe void Minimize(Vector3 source)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector3* ptr3 = ptr;
                Vector3* ptr2 = ptr;
                float num = *(float*)ptr2 = ((!(*(float*)ptr3 < *(float*)(&source))) ? (*(float*)(&source)) : (*(float*)ptr3));
                float num2 = *(float*)(ptr2 + 4) = ((!(*(float*)(ptr3 + 4) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) : (*(float*)(ptr3 + 4))));
                float num3 = *(float*)(ptr2 + 8) = ((!(*(float*)(ptr3 + 8) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8)))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8)))) : (*(float*)(ptr3 + 8))));
                //    }
                //}
            }
        }

        public unsafe static Vector3 Minimize(Vector3 left, Vector3 right)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            if (*(float*)(&left) < *(float*)(&right))
            {
                *(float*)(&result) = *(float*)(&left);
            }
            else
            {
                *(float*)(&result) = *(float*)(&right);
            }
            // (Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)))
            if (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))))
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            }
            else
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            }

            if (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))))
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            }
            else
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            }

            return result;
        }

        public unsafe void Maximize(Vector3 source)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector3* ptr3 = ptr;
                Vector3* ptr2 = ptr;
                float num = *(float*)ptr2 = ((!(*(float*)ptr3 > *(float*)(&source))) ? (*(float*)(&source)) : (*(float*)ptr3));
                float num2 = *(float*)(ptr2 + 4) = ((!(*(float*)(ptr3 + 4) > *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) : (*(float*)(ptr3 + 4)));
                float num3 = *(float*)(ptr2 + 8) = ((!(*(float*)(ptr3 + 8) > *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8)))) : (*(float*)(ptr3 + 8)));
                //    }
                //}
            }
        }

        public unsafe static Vector3 Maximize(Vector3 left, Vector3 right)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            if (*(float*)(&left) > *(float*)(&right))
            {
                *(float*)(&result) = *(float*)(&left);
            }
            else
            {
                *(float*)(&result) = *(float*)(&right);
            }

            if (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) > *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))))
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            }
            else
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            }

            if (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) > *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))))
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            }
            else
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            }

            return result;
        }

        public unsafe void Scale(float scalingFactor)
        {
            fixed (Vector3* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector3* ptr3 = ptr;
                Vector3* ptr2 = ptr;
                *(float*)ptr2 = *(float*)ptr3 * scalingFactor;
                *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) * scalingFactor;
                *(float*)(ptr2 + 8) = *(float*)(ptr3 + 8) * scalingFactor;
                //    }
                //}
            }
        }

        public unsafe static Vector3 Scale(Vector3 source, float scalingFactor)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            *(float*)(&result) = *(float*)(&source) * scalingFactor;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * scalingFactor;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 8))) * scalingFactor;
            return result;
        }

        public unsafe static Vector3 Lerp(Vector3 left, Vector3 right, float interpolater)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            *(float*)(&result) = (*(float*)(&right) - *(float*)(&left)) * interpolater + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)))) * interpolater + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)))) * interpolater + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            return result;
        }

        public unsafe void Normalize()
        {
            fixed (Vector3* ptr = &this)
            {
                ModuleOld.D3DXVec3Normalize((D3DXVECTOR3*)ptr, (D3DXVECTOR3*)ptr);
            }
        }

        public unsafe static Vector3 Normalize(Vector3 source)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3Normalize((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&source));
            return result;
        }

        public unsafe static Vector3 Hermite(Vector3 position, Vector3 tangent, Vector3 position2, Vector3 tangent2, float weightingFactor)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3Hermite((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&position), (D3DXVECTOR3*)(&tangent), (D3DXVECTOR3*)(&position2), (D3DXVECTOR3*)(&tangent2), weightingFactor);
            return result;
        }

        public unsafe static Vector3 CatmullRom(Vector3 position1, Vector3 position2, Vector3 position3, Vector3 position4, float weightingFactor)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3CatmullRom((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&position1), (D3DXVECTOR3*)(&position2), (D3DXVECTOR3*)(&position3), (D3DXVECTOR3*)(&position4), weightingFactor);
            return result;
        }

        public unsafe static Vector3 BaryCentric(Vector3 v1, Vector3 v2, Vector3 v3, float f, float g)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3BaryCentric((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&v1), (D3DXVECTOR3*)(&v2), (D3DXVECTOR3*)(&v3), f, g);
            return result;
        }



        public unsafe void TransformCoordinate(Matrix sourceMatrix)
        {
            fixed (Vector3* ptr = &this)
            {
                ModuleOld.D3DXVec3TransformCoord((D3DXVECTOR3*)ptr, (D3DXVECTOR3*)ptr, (D3DXMATRIX*)(&sourceMatrix));
            }
        }

        public unsafe static Vector3[] TransformCoordinate(Vector3[] vector, Matrix sourceMatrix)
        {
            if (vector == null)
            {
                throw new ArgumentNullException();
            }

            if (vector.Length == 0)
            {
                Vector3[] array = new Vector3[0];
                array.Initialize();
                return array;
            }

            Vector3[] array2 = new Vector3[(nint)vector.LongLength];
            array2.Initialize();
            fixed (Vector3* ptr = &array2[0])
            {
                fixed (Vector3* ptr2 = &vector[0])
                {
                    ModuleOld.D3DXVec3TransformCoordArray((D3DXVECTOR3*)ptr, 12u, (D3DXVECTOR3*)ptr2, 12u, (D3DXMATRIX*)(&sourceMatrix), (uint)vector.Length);
                    return array2;
                }
            }
        }

        public unsafe static Vector3 TransformCoordinate(Vector3 source, Matrix sourceMatrix)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3TransformCoord((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&source), (D3DXMATRIX*)(&sourceMatrix));
            return result;
        }

        public unsafe void TransformNormal(Matrix sourceMatrix)
        {
            fixed (Vector3* ptr = &this)
            {
                ModuleOld.D3DXVec3TransformNormal((D3DXVECTOR3*)ptr, (D3DXVECTOR3*)ptr, (D3DXMATRIX*)(&sourceMatrix));
            }
        }

        public unsafe static Vector3[] TransformNormal(Vector3[] vector, Matrix sourceMatrix)
        {
            if (vector == null)
            {
                throw new ArgumentNullException();
            }

            if (vector.Length == 0)
            {
                Vector3[] array = new Vector3[0];
                array.Initialize();
                return array;
            }

            Vector3[] array2 = new Vector3[(nint)vector.LongLength];
            array2.Initialize();
            fixed (Vector3* ptr = &array2[0])
            {
                fixed (Vector3* ptr2 = &vector[0])
                {
                    ModuleOld.D3DXVec3TransformNormalArray((D3DXVECTOR3*)ptr, 12u, (D3DXVECTOR3*)ptr2, 12u, (D3DXMATRIX*)(&sourceMatrix), (uint)vector.Length);
                    return array2;
                }
            }
        }

        public unsafe static Vector3 TransformNormal(Vector3 source, Matrix sourceMatrix)
        {
            Vector3 result = default(Vector3);
            result = new Vector3();
            ModuleOld.D3DXVec3TransformNormal((D3DXVECTOR3*)(&result), (D3DXVECTOR3*)(&source), (D3DXMATRIX*)(&sourceMatrix));
            return result;
        }
    }
}