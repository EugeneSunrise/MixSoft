

namespace MixSoft
{
    [Serializable]
    //[MiscellaneousBits(1)]
    public struct Vector2
    {
        public float X;

        public float Y;

        public static Vector2 Empty
        {
            get
            {
                Vector2 vector = default(Vector2);
                return new Vector2(0f, 0f);
            }
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe override bool Equals(object compare)
        {
            if (compare == null)
            {
                return false;
            }

            if ((object)compare.GetType() != typeof(Vector2))
            {
                return false;
            }

            Vector2 vector = (Vector2)((compare is Vector2) ? compare : null);
            Vector2 vector2 = this;
            int num = (*(float*)(&vector2) == *(float*)(&vector) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector2, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vector, 4)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator ==(Vector2 left, Vector2 right)
        {
            int num = (*(float*)(&left) == *(float*)(&right) && *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) == *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator !=(Vector2 left, Vector2 right)
        {
            int num = (*(float*)(&left) != *(float*)(&right) || *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) != *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)))) ? 1 : 0;
            return (num != 0) ? true : false;
        }

        public override int GetHashCode()
        {
            return (int)(double)Y ^ (int)(double)X;
        }

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
        //                string[] array = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_00245_0024];
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
        //            string[] array2 = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_00246_0024];
        //            array2[0] = fields[num2].Name;
        //            array2[1] = value.ToString();
        //            stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref ModuleOld._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array2));
        //            num2++;
        //        }
        //        while (num2 < (nint)fields.LongLength);
        //    }

        //    return stringBuilder.ToString();
        //}

        public unsafe static Vector2 operator -(Vector2 vec)
        {
            D3DXVECTOR2 d3DXVECTOR;
            *(float*)(&d3DXVECTOR) = 0f - *(float*)(&vec);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 4))) = 0f - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref vec, 4)));
            return *(Vector2*)(&d3DXVECTOR);
        }

        public unsafe static Vector2 operator +(Vector2 left, Vector2 right)
        {
            D3DXVECTOR2 result;
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            return *(Vector2*)(&result);

        }

        public unsafe static Vector2 operator -(Vector2 left, Vector2 right)
        {
            D3DXVECTOR2 result;
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            return *(Vector2*)(&result);
        }

        public unsafe static Vector2 operator *(float right, Vector2 left)
        {
            D3DXVECTOR2 result;
            *(float*)(&result) = *(float*)(&left) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * right;
            return *(Vector2*)(&result);
        }

        public unsafe static Vector2 operator *(Vector2 left, float right)
        {
            D3DXVECTOR2 result;
            *(float*)(&result) = *(float*)(&left) * right;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * right;
            return *(Vector2*)(&result);
        }

        public static Vector2 Multiply(Vector2 source, float s)
        {
            return source * s;
        }

        public unsafe void Multiply(float s)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                Vector2* ptr2 = ptr;
                D3DXVECTOR2 d3DXVECTOR;
                *(float*)(&d3DXVECTOR) = *(float*)ptr2 * s;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref d3DXVECTOR, 4))) = *(float*)(ptr2 + 4) * s;
                // IL cpblk instruction
                Unsafe.CopyBlock(ref *(byte*)(ptr), ref *(byte*)(&d3DXVECTOR), 8);
                //}
            }
        }

        public unsafe float Length()
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                Vector2* ptr2 = ptr;
                float num = *(float*)(ptr2 + 4);
                float num2 = *(float*)ptr2;
                return (float)Math.Sqrt(num2 * num2 + num * num);
                //}
            }
        }

        public unsafe static float Length(Vector2 source)
        {
            return (float)Math.Sqrt(*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) + *(float*)(&source) * *(float*)(&source));
        }

        public unsafe float LengthSq()
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                Vector2* ptr2 = ptr;
                float num = *(float*)(ptr2 + 4);
                float num2 = *(float*)ptr2;
                return num2 * num2 + num * num;
                //}
            }
        }

        public unsafe static float LengthSq(Vector2 source)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) + *(float*)(&source) * *(float*)(&source);
        }

        public unsafe static float Dot(Vector2 left, Vector2 right)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) * *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) + *(float*)(&right) * *(float*)(&left);
        }

        public unsafe static float Ccw(Vector2 left, Vector2 right)
        {
            return *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) * *(float*)(&left) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * *(float*)(&right);
        }

        public unsafe void Add(Vector2 v)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector2* ptr3 = ptr;
                Vector2* ptr2 = ptr;
                *(float*)ptr2 = *(float*)ptr3 + *(float*)(&v);
                *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref v, 4)));
                //    }
                //}
            }
        }

        public unsafe static Vector2 Add(Vector2 left, Vector2 right)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            return result;
        }

        public unsafe void Subtract(Vector2 source)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector2* ptr3 = ptr;
                Vector2* ptr2 = ptr;
                *(float*)ptr2 = *(float*)ptr3 - *(float*)(&source);
                *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)));
                //    }
                //}
            }
        }

        public unsafe static Vector2 Subtract(Vector2 left, Vector2 right)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            return result;
        }

        public unsafe void Minimize(Vector2 source)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector2* ptr3 = ptr;
                Vector2* ptr2 = ptr;
                float num = *(float*)ptr2 = ((!(*(float*)ptr3 < *(float*)(&source))) ? (*(float*)(&source)) : (*(float*)ptr3));
                float num2 = *(float*)(ptr2 + 4) = ((!(*(float*)(ptr3 + 4) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) : (*(float*)(ptr3 + 4))));
                //    }
                //}
            }
        }

        public unsafe static Vector2 Minimize(Vector2 left, Vector2 right)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            if (*(float*)(&left) < *(float*)(&right))
            {
                *(float*)(&result) = *(float*)(&left);
            }
            else
            {
                *(float*)(&result) = *(float*)(&right);
            }

            if (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) < *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))))
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            }
            else
            {
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            }

            return result;
        }

        public unsafe void Maximize(Vector2 source)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                Vector2* ptr3 = ptr;
                Vector2* ptr2 = ptr;
                float num = *(float*)ptr2 = ((!(*(float*)ptr3 > *(float*)(&source))) ? (*(float*)(&source)) : (*(float*)ptr3));
                float num2 = *(float*)(ptr2 + 4) = ((!(*(float*)(ptr3 + 4) > *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) ? (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4)))) : (*(float*)(ptr3 + 4))));
                //    }
                //}
            }
        }

        public unsafe static Vector2 Maximize(Vector2 left, Vector2 right)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
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

            return result;
        }

        public unsafe void Scale(float scalingFactor)
        {
            fixed (Vector2* ptr = &this)
            {
                //fixed ()
                //{
                //    fixed ()
                //    {
                        Vector2* ptr3 = ptr;
                        Vector2* ptr2 = ptr;
                        * (float*)ptr2 = *(float*)ptr3 * scalingFactor;
                        *(float*)(ptr2 + 4) = *(float*)(ptr3 + 4) * scalingFactor;
                //    }
                //}
            }
        }

        public unsafe static Vector2 Scale(Vector2 source, float scalingFactor)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            *(float*)(&result) = *(float*)(&source) * scalingFactor;
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref source, 4))) * scalingFactor;
            return result;
        }

        public unsafe static Vector2 Lerp(Vector2 left, Vector2 right, float interpolater)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            *(float*)(&result) = (*(float*)(&right) - *(float*)(&left)) * interpolater + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = (*(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) * interpolater + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))));
            return result;
        }

        public unsafe void Normalize()
        {
            fixed (Vector2* ptr = &this)
            {
                ModuleOld.D3DXVec2Normalize((D3DXVECTOR2*)ptr, (D3DXVECTOR2*)ptr);
            }
        }

        public unsafe static Vector2 Normalize(Vector2 source)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2Normalize((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&source));
            return result;
        }

        public unsafe static Vector2 Hermite(Vector2 position, Vector2 tangent, Vector2 position2, Vector2 tangent2, float weightingFactor)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2Hermite((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&position), (D3DXVECTOR2*)(&tangent), (D3DXVECTOR2*)(&position2), (D3DXVECTOR2*)(&tangent2), weightingFactor);
            return result;
        }

        public unsafe static Vector2 CatmullRom(Vector2 position1, Vector2 position2, Vector2 position3, Vector2 position4, float weightingFactor)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2CatmullRom((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&position1), (D3DXVECTOR2*)(&position2), (D3DXVECTOR2*)(&position3), (D3DXVECTOR2*)(&position4), weightingFactor);
            return result;
        }

        public unsafe static Vector2 BaryCentric(Vector2 v1, Vector2 v2, Vector2 v3, float f, float g)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2BaryCentric((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&v1), (D3DXVECTOR2*)(&v2), (D3DXVECTOR2*)(&v3), f, g);
            return result;
        }



        public unsafe void TransformCoordinate(Matrix sourceMatrix)
        {
            fixed (Vector2* ptr = &this)
            {
                ModuleOld.D3DXVec2TransformCoord((D3DXVECTOR2*)ptr, (D3DXVECTOR2*)ptr, (D3DXMATRIX*)(&sourceMatrix));
            }
        }

        public unsafe static Vector2[] TransformCoordinate(Vector2[] vector, Matrix sourceMatrix)
        {
            if (vector == null)
            {
                throw new ArgumentNullException();
            }

            if (vector.Length == 0)
            {
                Vector2[] array = new Vector2[0];
                array.Initialize();
                return array;
            }

            Vector2[] array2 = new Vector2[(nint)vector.LongLength];
            array2.Initialize();
            fixed (Vector2* ptr = &array2[0])
            {
                fixed (Vector2* ptr2 = &vector[0])
                {
                    ModuleOld.D3DXVec2TransformCoordArray((D3DXVECTOR2*)ptr, 8u, (D3DXVECTOR2*)ptr2, 8u, (D3DXMATRIX*)(&sourceMatrix), (uint)vector.Length);
                    return array2;
                }
            }
        }

        public unsafe static Vector2 TransformCoordinate(Vector2 source, Matrix sourceMatrix)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2TransformCoord((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&source), (D3DXMATRIX*)(&sourceMatrix));
            return result;
        }

        public unsafe void TransformNormal(Matrix sourceMatrix)
        {
            fixed (Vector2* ptr = &this)
            {
                ModuleOld.D3DXVec2TransformNormal((D3DXVECTOR2*)ptr, (D3DXVECTOR2*)ptr, (D3DXMATRIX*)(&sourceMatrix));
            }
        }

        public unsafe static Vector2[] TransformNormal(Vector2[] vector, Matrix sourceMatrix)
        {
            if (vector == null)
            {
                throw new ArgumentNullException();
            }

            if (vector.Length == 0)
            {
                Vector2[] array = new Vector2[0];
                array.Initialize();
                return array;
            }

            Vector2[] array2 = new Vector2[(nint)vector.LongLength];
            array2.Initialize();
            fixed (Vector2* ptr = &array2[0])
            {
                fixed (Vector2* ptr2 = &vector[0])
                {
                    ModuleOld.D3DXVec2TransformNormalArray((D3DXVECTOR2*)ptr, 8u, (D3DXVECTOR2*)ptr2, 8u, (D3DXMATRIX*)(&sourceMatrix), (uint)vector.Length);
                    return array2;
                }
            }
        }

        public unsafe static Vector2 TransformNormal(Vector2 source, Matrix sourceMatrix)
        {
            Vector2 result = default(Vector2);
            result = new Vector2();
            ModuleOld.D3DXVec2TransformNormal((D3DXVECTOR2*)(&result), (D3DXVECTOR2*)(&source), (D3DXMATRIX*)(&sourceMatrix));
            return result;
        }
    }
}