using System.Runtime.InteropServices;

namespace MixSoft.sys
{
    // https://docs.microsoft.com/en-us/windows/win32/api/windef/ns-windef-rect
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left, Top, Right, Bottom;
    }
}
