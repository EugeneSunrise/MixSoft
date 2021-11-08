namespace MixSoft.Hacks;
class RadarHack
{
    public void Radar(CancellationToken token)
    {
        while (true)
        {
            for (int i = 1; i <= 64; i++)
            {
                IntPtr player = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwEntityList + i * 0x10);

                bool isPlayerDormant = Memory.Read<bool>((int)(player + Offsets.Offsets.m_bDormant)); // Active ?
                if (isPlayerDormant)
                    continue;

                bool isPlayerSpotted = Memory.Read<bool>((int)(player + Offsets.Offsets.m_bSpotted)); // Spotted ?
                if (isPlayerSpotted)
                    continue;

                Memory.Write<bool>((int)(player + Offsets.Offsets.m_bSpotted), true);

                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
            }
            Thread.Sleep(1);
        }
    }
}
