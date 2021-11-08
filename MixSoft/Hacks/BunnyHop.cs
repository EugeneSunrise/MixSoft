namespace MixSoft.Hacks;

class BunnyHop
{
    [DllImport("user32.dll")]
    static extern bool GetAsyncKeyState(int vKey);
    public void Bhop(CancellationToken token)
    {
        while (true)
        {
            IntPtr localPlayer = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwLocalPlayer);
            int flag = Memory.Read<int>((int)localPlayer + Offsets.Offsets.m_fFlags);
            if (GetAsyncKeyState(32))
            {
                if (flag == 257)
                {
                    Memory.Write<IntPtr>(Memory.clientBase + Offsets.Offsets.dwForceJump, 6);
                }
                else { }
                Thread.Sleep(1);
            }
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
        }
    }
}
