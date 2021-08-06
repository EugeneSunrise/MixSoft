using System.Runtime.InteropServices;

namespace MixSoft.Classes
{
    [StructLayout(LayoutKind.Explicit)]
    public struct Input
    {
        [FieldOffset(0)] public SendInputEventType type;
        [FieldOffset(4)] public MouseInput mi;
        [FieldOffset(4)] public KeybdInput ki;
        [FieldOffset(4)] public HardwareInput hi;
    }
}
