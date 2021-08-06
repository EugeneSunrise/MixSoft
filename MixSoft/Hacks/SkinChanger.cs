using MixSoft.Objects;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using static MixSoft.Objects.GlobalLists;


namespace MixSoft.Hacks
{
    public class SkinChanger
    {
        [DllImport("user32.dll")]
        static extern bool GetAsyncKeyState(int vKey);
        public void SkinChangerThread(CancellationToken token)
        {
            int lastLoadedModelIndexForSkin = 0;

            while (true)
            {
                if (!Globals.SkinChangerEnabled)
                {
                    Thread.Sleep(Globals.IdleWait);
                    continue;
                }
                if (!Engine.InGame)
                {
                    Thread.Sleep(Globals.IdleWait);
                    continue;
                }

                for (var i = 0; i < 10; i++) 
                {

                    CBaseCombatWeapon currentWeapon = weaponList[i];

                    bool contin = false;
                    Skin selected = null;
                    try
                    {
                        foreach (Skin s in Globals.LoadedPresets)
                        {
                            if (Convert.ToInt32(s.WeaponID) == currentWeapon.ItemDefinitionIndex)
                            {
                                contin = true;
                                selected = s;
                                break;
                            }
                        }
                    }
                    catch { continue; }

                    if (!contin) continue;
                   
                    if (currentWeapon.IsKnife())
                    {
                        if (selected.WeaponID == (int)Constants.KnifeList[Globals.SelectedKnife].itemDefinitionIndex)
                        {
                            if (currentWeapon.PaintKit != selected.PaintKit || lastLoadedModelIndexForSkin != RuntimeGlobals.selectedKnifeModelIndex)
                            {
                                currentWeapon.ItemIDHigh = -1;
                                currentWeapon.PaintKit = selected.PaintKit;
                                currentWeapon.Wear = 0.0001f;
                                lastLoadedModelIndexForSkin = RuntimeGlobals.selectedKnifeModelIndex;
                                if (selected.CustomName != null && selected.CustomName != "") currentWeapon.CustomName = selected.CustomName;

                                if (!Globals.ManualLoadEnabled) Engine.ForceReload = -1; ///////////
                            }
                        }
                        continue;
                    }

                    if (currentWeapon.PaintKit != selected.PaintKit &&
                        currentWeapon.ItemDefinitionIndex == selected.WeaponID)
                    {
                        currentWeapon.ItemIDHigh = -1;
                        currentWeapon.PaintKit = selected.PaintKit;
                        if (selected.Seed != -1) currentWeapon.Seed = selected.Seed;
                        currentWeapon.Wear = selected.Wear;
                        currentWeapon.AccountID = currentWeapon.XuIDLow;
                        if (selected.CustomName != null && selected.CustomName != "") currentWeapon.CustomName = selected.CustomName;
                    }
                }
                if (GetAsyncKeyState(118))
                {
                    Engine.ForceReload = -1;
                }
                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                Thread.Sleep(TimeSpan.FromMilliseconds(0.1));
            }
        }
    }
}
