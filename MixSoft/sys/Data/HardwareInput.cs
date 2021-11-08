namespace MixSoft.Classes;

// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-hardwareinput
[StructLayout(LayoutKind.Sequential)]
public struct HardwareInput
{
    public int uMsg;
    public short wParamL;
    public short wParamH;
}
