namespace MixSoft.Classes;

// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-keybdinput

[StructLayout(LayoutKind.Sequential)]
public struct KeybdInput
{
    public ushort wVk;
    public ushort wScan;
    public uint dwFlags;
    public uint time;
    public IntPtr dwExtraInfo;
}
