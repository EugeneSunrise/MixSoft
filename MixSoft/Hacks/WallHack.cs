namespace MixSoft.Hacks;
class WallHack
{
    public struct GlowLines
    {
        public float r;
        public float g;
        public float b;
        public float a;
        public bool rwo;
        public bool rwuo;
    }
    public void Rendering(CancellationToken token)
    {
        GlowLines myTeam = new GlowLines()
        {
            r = 128,
            g = 0,
            b = 128,
            a = Offsets.Offsets.A,
            rwo = true,
            rwuo = false
        };
        GlowLines enemyTeam = new GlowLines()
        {
            r = 160,
            g = 60,
            b = 60,
            a = Offsets.Offsets.A,
            rwo = true,
            rwuo = false
        };

        while (true)
        {
            IntPtr localPlayer = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwLocalPlayer);
            int localTeam = Memory.Read<int>((int)(localPlayer + Offsets.Offsets.m_iTeamNum));

            for (int i = 1; i <= 64; i++)
            {
                IntPtr entityList = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwEntityList + i * 0x10);
                int glowIndex = Memory.Read<int>((int)(entityList + Offsets.Offsets.m_iGlowIndex));
                IntPtr glowObject = Memory.Read<IntPtr>(Memory.clientBase + Offsets.Offsets.dwGlowObjectManager);
                int enmHealth = Memory.Read<int>((int)(entityList + Offsets.Offsets.m_iHealth)); if (enmHealth < 1 || enmHealth > 100) continue;
                int entityTeam = Memory.Read<int>((int)(entityList + Offsets.Offsets.m_iTeamNum));

                if (localTeam == entityTeam)
                {
                    Render(glowObject, glowIndex, enemyTeam.r, enemyTeam.g, enemyTeam.b,
                        enemyTeam.a, enemyTeam.rwo, enemyTeam.rwuo);
                }
                else if (localTeam != entityTeam)
                {
                    Render(glowObject, glowIndex, myTeam.r, myTeam.g, myTeam.b,
                        myTeam.a, myTeam.rwo, myTeam.rwuo);
                }
            }
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
        }
    }

    public void Render(IntPtr glowObject, int glowIndex, float r, float g, float b,
        float a, bool rwo, bool rwuo)
    {
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0x8), r);
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0xC), g);
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0x10), b);
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0x14), a);
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0x28), rwo);
        Memory.Write<IntPtr>((int)(glowObject + (glowIndex * 0x38) + 0x30), rwuo);
    }
}
