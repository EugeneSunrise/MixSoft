using MixSoft.Objects;
using System.Runtime.InteropServices;
using System.Threading;
using static MixSoft.Objects.GlobalLists;


namespace MixSoft.Hacks
{
    public class KnifeChanger
    {
        public void KnifeChangerThread(CancellationToken token) 
        {
            bool shouldReloadModelIndex = true;
            RuntimeGlobals.selectedKnifeModelIndex = 0;
            int selectedKnifeIndex = 0;

            while (true)
            {
                if (!Globals.KnifeChangerEnabled)
                {
                    //Thread.Sleep(Globals.IdleWait);
                    shouldReloadModelIndex = true;
                    continue;
                }
                if (!Engine.InGame)
                {
                    //Thread.Sleep(Globals.IdleWait);
                    shouldReloadModelIndex = true;
                    continue;
                }

                if (shouldReloadModelIndex || selectedKnifeIndex != (int)Constants.KnifeList[Globals.SelectedKnife].itemDefinitionIndex)
                {
                    RuntimeGlobals.selectedKnifeModelIndex = Engine.GetModelIndexByName(Constants.KnifeList[Globals.SelectedKnife].modelName);
                    selectedKnifeIndex = (int)Constants.KnifeList[Globals.SelectedKnife].itemDefinitionIndex;
                    shouldReloadModelIndex = false;
                }

                for (var i = 0; i < 12; i++)
                {
                    CBaseCombatWeapon currentWeapon = weaponList[i];

                    if (currentWeapon.IsKnife())
                    {
                        currentWeapon.ItemDefinitionIndex = (int)Constants.KnifeList[Globals.SelectedKnife].itemDefinitionIndex;
                        currentWeapon.EntityQuality = 3;
                        currentWeapon.ModelIndex = RuntimeGlobals.selectedKnifeModelIndex;
                        currentWeapon.ViewModelIndex = RuntimeGlobals.selectedKnifeModelIndex;
                    }
                }

                for (int i = 0; i < 10; i++) //Seems to be making it more stable
                    if (weaponList.ActiveWeapon.IsKnife()) weaponList.ActiveWeapon.ViewModelEntityModelIndex = RuntimeGlobals.selectedKnifeModelIndex;


                if (token.IsCancellationRequested)
                {
                    token.ThrowIfCancellationRequested();
                }
                //Thread.Sleep(Globals.UsageDelay);
            }
        }
    }
}
