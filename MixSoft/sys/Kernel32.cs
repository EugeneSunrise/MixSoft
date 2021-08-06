using System;
using System.Runtime.InteropServices;

namespace MixSoft.Classes
{
    public static class Kernel32
    {
         
        // Reads data from an area of memory in a specified process.
        // The entire area to be read must be accessible or the operation fails.
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, [Out, MarshalAs(UnmanagedType.AsAny)] object lpBuffer, int dwSize, out int lpNumberOfBytesRead);

         
        // Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        // To avoid the race conditions described in the Remarks section, use the GetModuleHandleEx function.
        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

       
    }
}
