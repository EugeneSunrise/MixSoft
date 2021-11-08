namespace MixSoft.sys;

// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nc-winuser-hookproc
public delegate IntPtr HookProc(int nCode, IntPtr wParam, IntPtr lParam);
