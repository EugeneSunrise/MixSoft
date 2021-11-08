namespace MixSoft.Classes;
public class GlobalHook :
     IDisposable
{
    #region Prop

    public HookType HookType { get; }


    // Hook callback delegate.
    private HookProc HookProc { get; set; }


    // Hook handle.
    public IntPtr HookHandle { get; private set; }

    #endregion

    #region Ctor & Dispose

    public GlobalHook(HookType hookType, HookProc hookProc)
    {
        HookType = hookType;
        HookProc = hookProc;
        HookHandle = Hook(HookType, HookProc);
    }

    public void Dispose()
    {
        ReleaseUnmanagedResources();

        // prevent destructor (since we already release unmanaged resources)
        GC.SuppressFinalize(this);
    }


    // Destructor. This should be called by finalized if Dispose is not called.
    ~GlobalHook()
    {
        ReleaseUnmanagedResources();
    }


    // Unhook. Should be called once.
    private void ReleaseUnmanagedResources()
    {
        // unhook and reset handle
        UnHook(HookHandle);
        HookHandle = default;

        // release callback reference, will let GC to collect it
        HookProc = default;
    }

    #endregion

    #region Un/Hook


    // Install an application-defined hook procedure into a hook chain.
    private static IntPtr Hook(HookType hookType, HookProc hookProc)
    {
        using (var currentProcess = Process.GetCurrentProcess())
        {
            using (var curModule = currentProcess.MainModule)
            {
                if (curModule is null)
                {
                    throw new ArgumentNullException(nameof(curModule));
                }

                var hHook = User32.SetWindowsHookEx((int)hookType, hookProc, Kernel32.GetModuleHandle(curModule.ModuleName), 0);
                if (hHook == IntPtr.Zero)
                {
                    throw new ArgumentException("Hook failed.");
                }

                return hHook;
            }
        }
    }


    // Remove a hook procedure installed in a hook chain.
    private static void UnHook(IntPtr hHook)
    {
        if (!User32.UnhookWindowsHookEx(hHook))
        {
            throw new ArgumentException("UnHook failed.");
        }
    }

    #endregion
}
