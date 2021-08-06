using System.Runtime.InteropServices;

namespace MixSoft.sys
{
    // https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-point
    [StructLayout(LayoutKind.Sequential)]
    public struct Point
    {
        public int X, Y;
    }
}
