namespace MixSoft.Hacks;

class AntiFlash
{
    public void AntiFuckinFlash(CancellationToken token)
    {
        while (true)
        {
            IntPtr LocalPlayer = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwLocalPlayer);
            int flash = Memory.Read<int>((int)(LocalPlayer + Offsets.Offsets.m_flFlashDuration));
            if (flash > 0)
            {
                Memory.Write<int>((int)(LocalPlayer + Offsets.Offsets.m_flFlashDuration), 0);
            }
            else { }
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
            Thread.Sleep(10);
        }
    }
}