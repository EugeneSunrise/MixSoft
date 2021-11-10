//using Microsoft.DirectX.PrivateImplementationDetails;
//using Microsoft.VisualC;

namespace MixSoft
{
    [Serializable]
    //[MiscellaneousBits(1)]
    public struct Matrix
    {
        public float M11;

        public float M12;

        public float M13;

        public float M14;

        public float M21;

        public float M22;

        public float M23;

        public float M24;

        public float M31;

        public float M32;

        public float M33;

        public float M34;

        public float M41;

        public float M42;

        public float M43;

        public float M44;

        public unsafe float Determinant
        {
            get
            {
                fixed (Matrix* ptr = &this)
                {
                    return ModuleOld.D3DXMatrixDeterminant((D3DXMATRIX*)ptr);
                }
            }
        }

        public unsafe static Matrix Identity
        {
            get
            {
                Matrix result = default(Matrix);
                result = new Matrix();
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 56))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 52))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 48))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 44))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 36))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 32))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 28))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 24))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 16))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = 0f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 60))) = 1f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 40))) = 1f;
                *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 20))) = 1f;
                *(float*)(&result) = 1f;
                return result;
            }
        }

        public static Matrix Zero
        {
            get
            {
                Matrix matrix = default(Matrix);
                return new Matrix();
            }
        }

        public unsafe Matrix()
        {
            fixed (Matrix* ptr = &this)
            {
                // IL initblk instruction
                Unsafe.InitBlock(ref *(byte*)(ptr), 0, (uint)sizeof(Matrix));
            }
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
        //                string[] array = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_00241_0024];
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
        //            string[] array2 = new string[ModuleOld._0024ConstGCArrayBound_00240x33fa5e40_00242_0024];
        //            array2[0] = fields[num2].Name;
        //            array2[1] = value.ToString();
        //            stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref ModuleOld._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array2));
        //            num2++;
        //        }
        //        while (num2 < (nint)fields.LongLength);
        //    }

        //    return stringBuilder.ToString();
        //}

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe override bool Equals(object compare)
        {
            if (compare == null)
            {
                return false;
            }

            if ((object)compare.GetType() != typeof(Matrix))
            {
                return false;
            }

            Matrix matrix = (Matrix)((compare is Matrix) ? compare : null);
            Matrix matrix2 = this;
            int num = ModuleOld.memcmp(&matrix2, &matrix, 64u);
            return 0 == num;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator ==(Matrix left, Matrix right)
        {
            int num = ModuleOld.memcmp(&left, &right, 64u);
            return 0 == num;
        }

        [return: MarshalAs(UnmanagedType.U1)]
        public unsafe static bool operator !=(Matrix left, Matrix right)
        {
            int num = ModuleOld.memcmp(&left, &right, 64u);
            return (0 != num) ? true : false;
        }

        public override int GetHashCode()
        {
            return (int)(double)M44 ^ (int)(double)M33 ^ (int)(double)M22 ^ (int)(double)M11;
        }

        public unsafe static Matrix operator +(Matrix left, Matrix right)
        {
            D3DXMATRIX result;
            *(float*)(&result) = *(float*)(&right) + *(float*)(&left);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 16))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 16))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 16)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 20))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 20))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 20)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 24))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 24))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 24)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 28))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 28))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 28)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 32))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 32))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 32)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 36))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 36))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 36)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 40))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 40))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 40)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 44))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 44))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 44)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 48))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 48))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 48)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 52))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 52))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 52)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 56))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 56))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 56)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 60))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 60))) + *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 60)));
            return *(Matrix*)(&result);

        }

        public unsafe static Matrix operator -(Matrix left, Matrix right)
        {
            D3DXMATRIX result;
            *(float*)(&result) = *(float*)(&left) - *(float*)(&right);
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 4))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 4))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 4)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 8))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 8))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 8)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 12))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 12))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 12)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 16))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 16))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 16)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 20))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 20))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 20)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 24))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 24))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 24)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 28))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 28))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 28)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 32))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 32))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 32)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 36))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 36))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 36)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 40))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 40))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 40)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 44))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 44))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 44)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 48))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 48))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 48)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 52))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 52))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 52)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 56))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 56))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 56)));
            *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref result, 60))) = *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref left, 60))) - *(float*)(Unsafe.AsPointer(ref Unsafe.AddByteOffset(ref right, 60)));
            return *(Matrix*)(&result);

        }

        public unsafe static Matrix operator *(Matrix left, Matrix right)
        {
            D3DXMATRIX result;
            ModuleOld.D3DXMatrixMultiply(&result, (D3DXMATRIX*)(&left), (D3DXMATRIX*)(&right));
            return *(Matrix*)(&result);

        }

        public static Matrix Add(Matrix left, Matrix right)
        {
            return left + right;
        }

        public static Matrix Subtract(Matrix left, Matrix right)
        {
            return left - right;
        }

        public unsafe void Multiply(Matrix source)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixMultiply((D3DXMATRIX*)ptr, (D3DXMATRIX*)ptr, (D3DXMATRIX*)(&source));
            }
        }

        public unsafe static Matrix Multiply(Matrix left, Matrix right)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixMultiply((D3DXMATRIX*)(&result), (D3DXMATRIX*)(&left), (D3DXMATRIX*)(&right));
            return result;
        }

        public unsafe void MultiplyTranspose(Matrix source)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixMultiplyTranspose((D3DXMATRIX*)ptr, (D3DXMATRIX*)ptr, (D3DXMATRIX*)(&source));
            }
        }

        public unsafe static Matrix MultiplyTranspose(Matrix left, Matrix right)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixMultiplyTranspose((D3DXMATRIX*)(&result), (D3DXMATRIX*)(&left), (D3DXMATRIX*)(&right));
            return result;
        }

        public unsafe void Invert()
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixInverse((D3DXMATRIX*)ptr, null, (D3DXMATRIX*)ptr);
            }
        }

        public unsafe static Matrix Invert(Matrix source)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixInverse((D3DXMATRIX*)(&result), null, (D3DXMATRIX*)(&source));
            return result;
        }

        public unsafe static Matrix Invert(ref float determinant, Matrix source)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            float num = 0f;
            ModuleOld.D3DXMatrixInverse((D3DXMATRIX*)(&result), &num, (D3DXMATRIX*)(&source));
            determinant = num;
            return result;
        }

        public static Matrix Scaling(Vector3 v)
        {
            return Scaling(v.X, v.Y, v.Z);
        }

        public unsafe static Matrix Scaling(float x, float y, float z)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixScaling((D3DXMATRIX*)(&result), x, y, z);
            return result;
        }

        public static Matrix Translation(Vector3 v)
        {
            return Translation(v.X, v.Y, v.Z);
        }

        public unsafe static Matrix Translation(float x, float y, float z)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixTranslation((D3DXMATRIX*)(&result), x, y, z);
            return result;
        }

        public unsafe static Matrix RotationX(float angle)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationX((D3DXMATRIX*)(&result), angle);
            return result;
        }

        public unsafe static Matrix RotationY(float angle)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationY((D3DXMATRIX*)(&result), angle);
            return result;
        }

        public unsafe static Matrix RotationZ(float angle)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationZ((D3DXMATRIX*)(&result), angle);
            return result;
        }

        public unsafe static Matrix RotationAxis(Vector3 axisRotation, float angle)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationAxis((D3DXMATRIX*)(&result), (D3DXVECTOR3*)(&axisRotation), angle);
            return result;
        }

        public unsafe static Matrix RotationQuaternion(Quaternion quat)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationQuaternion((D3DXMATRIX*)(&result), (D3DXQUATERNION*)(&quat));
            return result;
        }

        public unsafe static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixRotationYawPitchRoll((D3DXMATRIX*)(&result), yaw, pitch, roll);
            return result;
        }

        public unsafe static Matrix Transformation(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scalingFactor, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixTransformation((D3DXMATRIX*)(&result), (D3DXVECTOR3*)(&scalingCenter), (D3DXQUATERNION*)(&scalingRotation), (D3DXVECTOR3*)(&scalingFactor), (D3DXVECTOR3*)(&rotationCenter), (D3DXQUATERNION*)(&rotation), (D3DXVECTOR3*)(&translation));
            return result;
        }

        public unsafe static Matrix LookAtRH(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixLookAtRH((D3DXMATRIX*)(&result), (D3DXVECTOR3*)(&cameraPosition), (D3DXVECTOR3*)(&cameraTarget), (D3DXVECTOR3*)(&cameraUpVector));
            return result;
        }

        public unsafe static Matrix LookAtLH(Vector3 cameraPosition, Vector3 cameraTarget, Vector3 cameraUpVector)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixLookAtLH((D3DXMATRIX*)(&result), (D3DXVECTOR3*)(&cameraPosition), (D3DXVECTOR3*)(&cameraTarget), (D3DXVECTOR3*)(&cameraUpVector));
            return result;
        }

        public unsafe static Matrix PerspectiveRH(float width, float height, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveRH((D3DXMATRIX*)(&result), width, height, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix PerspectiveLH(float width, float height, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveLH((D3DXMATRIX*)(&result), width, height, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix PerspectiveFovRH(float fieldOfViewY, float aspectRatio, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveFovRH((D3DXMATRIX*)(&result), fieldOfViewY, aspectRatio, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix PerspectiveFovLH(float fieldOfViewY, float aspectRatio, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveFovLH((D3DXMATRIX*)(&result), fieldOfViewY, aspectRatio, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveOffCenterRH((D3DXMATRIX*)(&result), left, right, bottom, top, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixPerspectiveOffCenterLH((D3DXMATRIX*)(&result), left, right, bottom, top, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix OrthoRH(float width, float height, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixOrthoRH((D3DXMATRIX*)(&result), width, height, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix OrthoLH(float width, float height, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixOrthoLH((D3DXMATRIX*)(&result), width, height, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix OrthoOffCenterRH(float left, float right, float bottom, float top, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixOrthoOffCenterRH((D3DXMATRIX*)(&result), left, right, bottom, top, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix OrthoOffCenterLH(float left, float right, float bottom, float top, float znearPlane, float zfarPlane)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixOrthoOffCenterLH((D3DXMATRIX*)(&result), left, right, bottom, top, znearPlane, zfarPlane);
            return result;
        }

        public unsafe static Matrix Transformation2D(Vector2 scalingCenter, float scalingRotation, Vector2 scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixTransformation2D((D3DXMATRIX*)(&result), (D3DXVECTOR2*)(&scalingCenter), scalingRotation, (D3DXVECTOR2*)(&scaling), (D3DXVECTOR2*)(&rotationCenter), rotation, (D3DXVECTOR2*)(&translation));
            return result;
        }

        public unsafe static Matrix AffineTransformation2D(float scaling, Vector2 rotationCenter, float rotation, Vector2 translation)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixAffineTransformation2D((D3DXMATRIX*)(&result), scaling, (D3DXVECTOR2*)(&rotationCenter), rotation, (D3DXVECTOR2*)(&translation));
            return result;
        }
       
        public unsafe static Matrix TransposeMatrix(Matrix source)
        {
            Matrix result = default(Matrix);
            result = new Matrix();
            ModuleOld.D3DXMatrixTranspose((D3DXMATRIX*)(&result), (D3DXMATRIX*)(&source));
            return result;
        }

        public unsafe void Transpose(Matrix source)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixTranspose((D3DXMATRIX*)ptr, (D3DXMATRIX*)(&source));
            }
        }

        public void Scale(Vector3 v)
        {
            Scale(v.X, v.Y, v.Z);
        }

        public unsafe void Scale(float x, float y, float z)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixScaling((D3DXMATRIX*)ptr, x, y, z);
            }
        }

        public void Translate(Vector3 v)
        {
            Translate(v.X, v.Y, v.Z);
        }

        public unsafe void Translate(float x, float y, float z)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixTranslation((D3DXMATRIX*)ptr, x, y, z);
            }
        }

        public unsafe void RotateX(float angle)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationX((D3DXMATRIX*)ptr, angle);
            }
        }

        public unsafe void RotateY(float angle)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationY((D3DXMATRIX*)ptr, angle);
            }
        }

        public unsafe void RotateZ(float angle)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationZ((D3DXMATRIX*)ptr, angle);
            }
        }

        public unsafe void RotateAxis(Vector3 axisRotation, float angle)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationAxis((D3DXMATRIX*)ptr, (D3DXVECTOR3*)(&axisRotation), angle);
            }
        }

        public unsafe void RotateQuaternion(Quaternion quat)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationQuaternion((D3DXMATRIX*)ptr, (D3DXQUATERNION*)(&quat));
            }
        }

        public unsafe void RotateYawPitchRoll(float yaw, float pitch, float roll)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixRotationYawPitchRoll((D3DXMATRIX*)ptr, yaw, pitch, roll);
            }
        }

        public unsafe void Transform(Vector3 scalingCenter, Quaternion scalingRotation, Vector3 scalingFactor, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixTransformation((D3DXMATRIX*)ptr, (D3DXVECTOR3*)(&scalingCenter), (D3DXQUATERNION*)(&scalingRotation), (D3DXVECTOR3*)(&scalingFactor), (D3DXVECTOR3*)(&rotationCenter), (D3DXQUATERNION*)(&rotation), (D3DXVECTOR3*)(&translation));
            }
        }

        public unsafe void AffineTransformation(float scaling, Vector3 rotationCenter, Quaternion rotation, Vector3 translation)
        {
            fixed (Matrix* ptr = &this)
            {
                ModuleOld.D3DXMatrixAffineTransformation((D3DXMATRIX*)ptr, scaling, (D3DXVECTOR3*)(&rotationCenter), (D3DXQUATERNION*)(&rotation), (D3DXVECTOR3*)(&translation));
            }
        }

        //public unsafe void Shadow(Vector4 light, Plane plane)
        //{
        //    fixed (Matrix* ptr = &this)
        //    {
        //        ModuleOld.D3DXMatrixShadow((D3DXMATRIX*)ptr, (D3DXVECTOR4*)(&light), (D3DXPLANE*)(&plane));
        //    }
        //}

        //public unsafe void Reflect(Plane plane)
        //{
        //    fixed (Matrix* ptr = &this)
        //    {
        //        ModuleOld.D3DXMatrixReflect((D3DXMATRIX*)ptr, (D3DXPLANE*)(&plane));
        //    }
        //}
    }
}