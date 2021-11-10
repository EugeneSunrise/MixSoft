
namespace MixSoft
{
    //
    // Сводка:
    //     Defines the window dimensions of a render target surface onto which a 3-D volume
    //     projects.
    //[MiscellaneousBits(1)]
    public struct Viewport
    {
        private int m_X;

        private int m_Y;

        private int m_Width;

        private int m_Height;

        private float m_MinZ;

        private float m_MaxZ;

        //
        // Сводка:
        //     Retrieves or sets the maximum value of the clip volume.
        public float MaxZ
        {
            get
            {
                return m_MaxZ;
            }
            set
            {
                m_MaxZ = value;
            }
        }

        //
        // Сводка:
        //     Retrieves or sets the minimum value of the clip volume.
        public float MinZ
        {
            get
            {
                return m_MinZ;
            }
            set
            {
                m_MinZ = value;
            }
        }

        //
        // Сводка:
        //     Retrieves or sets the height dimension of the viewport on the render target surface,
        //     in pixels.
        public int Height
        {
            get
            {
                return m_Height;
            }
            set
            {
                m_Height = value;
            }
        }

        //
        // Сводка:
        //     Retrieves or sets the width dimension of the viewport on the render target surface,
        //     in pixels.
        public int Width
        {
            get
            {
                return m_Width;
            }
            set
            {
                m_Width = value;
            }
        }

        //
        // Сводка:
        //     Retrieves or sets the pixel coordinate of the upper-left corner of the viewport
        //     on the render target surface.
        public int Y
        {
            get
            {
                return m_Y;
            }
            set
            {
                m_Y = value;
            }
        }

        //
        // Сводка:
        //     Retrieves or sets the pixel coordinate of the upper-left corner of the viewport
        //     on the render target surface.
        public int X
        {
            get
            {
                return m_X;
            }
            set
            {
                m_X = value;
            }
        }

        //
        // Сводка:
        //     Obtains a string representation of the current instance.
        //
        // Возврат:
        //     String that represents the object.
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
        //                object obj2 = getMethod.Invoke(obj, (object[])null);
        //                string[] array = new string[ModuleOld._0024ConstGCArrayBound_00240x092d518d_002484_0024];
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
        //            string[] array2 = new string[ModuleOld._0024ConstGCArrayBound_00240x092d518d_002485_0024];
        //            array2[0] = fields[num2].Name;
        //            array2[1] = value.ToString();
        //            stringBuilder.Append(string.Format(CultureInfo.CurrentUICulture, new string((sbyte*)Unsafe.AsPointer(ref ModuleOld._003F_003F_C_0040_09GAFEAPMM_0040_003F_0024HL0_003F_0024HN_003F3_003F5_003F_0024HL1_003F_0024HN_003F6_003F_0024AA_0040)), array2));
        //            num2++;
        //        }
        //        while (num2 < (nint)fields.LongLength);
        //    }

        //    return stringBuilder.ToString();
        //}

        //
        // Сводка:
        //     Initializes a new instance of the Microsoft.DirectX.Direct3D.Viewport class.
        public unsafe Viewport()
        {
            fixed (Viewport* ptr = &this)
            {
                // IL initblk instruction
                Unsafe.InitBlock(ptr, 0, 24);
            }
        }
    }
}