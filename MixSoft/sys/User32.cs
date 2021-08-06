using MixSoft.sys;
using System;
using System.Runtime.InteropServices;

namespace MixSoft.Classes
{
    public static class User32
    {
         
        /// Sets a new extended window style
        public const int GWL_EXSTYLE = -20;

         
        /// Use bAlpha to determine the opacity of the layered window. 
        public const int LWA_ALPHA = 0x2;

         
        /// The window is a layered window.
        /// This style cannot be used if the window has a class style of either CS_OWNDC or CS_CLASSDC.
        /// Windows 8: The WS_EX_LAYERED style is supported for top-level windows and child windows.
        /// Previous Windows versions support WS_EX_LAYERED only for top-level windows.
        public const int WS_EX_LAYERED = 0x80000;

         
        /// The window should not be painted until siblings beneath the window (that were created by the same thread) have been painted.
        /// The window appears transparent because the bits of underlying sibling windows have already been painted.
        /// To achieve transparency without these restrictions, use the SetWindowRgn function.
        public const int WS_EX_TRANSPARENT = 0x20;

         
        /// Passes the hook information to the next hook procedure in the current hook chain.
        /// A hook procedure can call this function either before or after processing the hook information.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr idHook, int nCode, IntPtr wParam, IntPtr lParam);

         
        /// The ClientToScreen function converts the client-area coordinates of a specified point to screen coordinates.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool ClientToScreen(IntPtr hWnd, out Point lpPoint);

         
        /// Determines whether a key is up or down at the time the function is called,
        /// and whether the key was pressed after a previous call to GetAsyncKeyState.
        /// If the function succeeds, the return value specifies whether the key was pressed since the last call to GetAsyncKeyState,
        /// and whether the key is currently up or down. If the most significant bit is set, the key is down,
        /// and if the least significant bit is set, the key was pressed after the previous call to GetAsyncKeyState.
        /// However, you should not rely on this last behavior; for more information, see the Remarks.
        /// The return value is zero for the following cases:
        /// * The current desktop is not the active desktop
        /// * The foreground thread belongs to another process and the desktop does not allow the hook or the journal record.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

         
        /// Retrieves the coordinates of a window's client area. The client coordinates
        /// specify the upper-left and lower-right corners of the client area.
        /// Because client coordinates are relative to the upper-left corner of
        /// a window's client area, the coordinates of the upper-left corner are (0,0).
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hWnd, out Rect lpRect);

         
        /// Retrieves a handle to the foreground window (the window with which the user is currently working).
        /// The system assigns a slightly higher priority to the thread that creates the foreground window than it does to other threads.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetForegroundWindow();

         
        /// Retrieves information about the specified window. The function also retrieves
        /// the 32-bit (DWORD) value at the specified offset into the extra window memory. 
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowLong(IntPtr hWnd, int nIndex);

         
        /// Retrieves a handle to the top-level window whose class name and window name match the specified strings.
        /// This function does not search child windows. This function does not perform a case-sensitive search.
        /// To search child windows, beginning with a specified child window, use the FindWindowEx function.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

         
        /// Synthesizes keystrokes, mouse motions, and button clicks.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint SendInput(uint nInputs, ref Input pInputs, int cbSize);

         
        /// Sets the opacity and transparency color key of a layered window.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hwnd, uint crKey, byte bAlpha, uint dwFlags);

         
        /// Installs an application-defined hook procedure into a hook chain.
        /// You would install a hook procedure to monitor the system for certain types of events.
        /// These events are associated either with a specific thread or with all threads in the same desktop as the calling thread.
        /// If the function succeeds, the return value is the handle to the hook procedure.
        /// If the function fails, the return value is NULL.To get extended error information, call GetLastError.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, HookProc callback, IntPtr hInstance, uint threadId);

         
        /// Changes an attribute of the specified window.
        /// The function also sets the 32-bit (long) value at the specified offset into the extra window memory.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

         
        /// Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnhookWindowsHookEx(IntPtr hInstance);
    }
}
