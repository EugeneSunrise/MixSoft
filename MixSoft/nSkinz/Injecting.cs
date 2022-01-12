namespace MixSoft.nSkinz;
class Injecting
{
    #region DllImport
    [DllImport("kernel32")]
    public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, UIntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

    [DllImport("kernel32.dll")]
    public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll")]
    public static extern int CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

    [DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
    public static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);

    [DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
    private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

    [DllImport("kernel32.dll")]
    private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, string lpBuffer, UIntPtr nSize, out IntPtr lpNumberOfBytesWritten);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr GetModuleHandle(string lpModuleName);

    [DllImport("kernel32", ExactSpelling = true, SetLastError = true)]
    #endregion
    internal static extern int WaitForSingleObject(IntPtr handle, int milliseconds);

    public static int GetProcessId(string proc)
    {
        return Process.GetProcessesByName(proc)[0].Id;
    }

    public static void InjectHuiDll(string process, string namedll)
    {
        int processId228 = Injecting.GetProcessId(process);
        IntPtr hProcess1337 = Injecting.OpenProcess(2035711U, 1, processId228);
        int num = namedll.Length + 1;
        IntPtr intPtr = Injecting.VirtualAllocEx(hProcess1337, (IntPtr)null, (uint)num, 4096U, 64U);
        IntPtr intPtr2;
        Injecting.WriteProcessMemory(hProcess1337, intPtr, namedll, (UIntPtr)((ulong)((long)num)), out intPtr2);
        UIntPtr procAddress = Injecting.GetProcAddress(Injecting.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
        IntPtr intPtr3 = Injecting.CreateRemoteThread(hProcess1337, (IntPtr)null, 0U, procAddress, intPtr, 0U, out intPtr2);
        int num2 = Injecting.WaitForSingleObject(intPtr3, 10000);
        if ((long)num2 == 128L || (long)num2 == 258L || (long)num2 == (long)((long)-1))
        {
            Injecting.CloseHandle(intPtr3);
            return;
        }
        Thread.Sleep(1000);
        Injecting.VirtualFreeEx(hProcess1337, intPtr, (UIntPtr)0UL, 32768U);
        Injecting.CloseHandle(intPtr3);
    }

    public static void StartFuckCs()
    {
        try
        {
            var proc = Process.GetProcesses().First(p => p.ProcessName == "csgo");
            if (proc == null)
            {
                Environment.Exit(0);
            }
        }
        catch (Exception)
        {
            //MessageBox.Show("Start CS:GO!");
            Environment.Exit(0);
        }
        File.WriteAllBytes(@"C:\Windows\gabenSucked.dll", Resources.hui.chlen);
        Injecting.InjectHuiDll("csgo", @"C:\Windows\gabenSucked");
        MessageBox.Show("Success! Press INSERT to open ingame menu");

    }
}
