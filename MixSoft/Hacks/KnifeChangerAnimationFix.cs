﻿namespace MixSoft.Hacks;

class KnifeChangerAnimationFix
{
    #region Sequence's
    enum Sequence
    {
        SEQUENCE_DEFAULT_DRAW = 0,
        SEQUENCE_DEFAULT_IDLE1 = 1,
        SEQUENCE_DEFAULT_IDLE2 = 2,
        SEQUENCE_DEFAULT_LIGHT_MISS1 = 3,
        SEQUENCE_DEFAULT_LIGHT_MISS2 = 4,
        SEQUENCE_DEFAULT_HEAVY_MISS1 = 9,
        SEQUENCE_DEFAULT_HEAVY_HIT1 = 10,
        SEQUENCE_DEFAULT_HEAVY_BACKSTAB = 11,
        SEQUENCE_DEFAULT_LOOKAT01 = 12,

        SEQUENCE_BUTTERFLY_DRAW = 0,
        SEQUENCE_BUTTERFLY_DRAW2 = 1,
        SEQUENCE_BUTTERFLY_LOOKAT01 = 13,
        SEQUENCE_BUTTERFLY_LOOKAT03 = 15,

        SEQUENCE_FALCHION_IDLE1 = 1,
        SEQUENCE_FALCHION_HEAVY_MISS1 = 8,
        SEQUENCE_FALCHION_HEAVY_MISS1_NOFLIP = 9,
        SEQUENCE_FALCHION_LOOKAT01 = 12,
        SEQUENCE_FALCHION_LOOKAT02 = 13,

        SEQUENCE_CSS_LOOKAT01 = 12,
        SEQUENCE_CSS_LOOKAT02 = 15,

        SEQUENCE_DAGGERS_IDLE1 = 1,
        SEQUENCE_DAGGERS_LIGHT_MISS1 = 2,
        SEQUENCE_DAGGERS_LIGHT_MISS5 = 6,
        SEQUENCE_DAGGERS_HEAVY_MISS2 = 11,
        SEQUENCE_DAGGERS_HEAVY_MISS1 = 12,

        SEQUENCE_BOWIE_IDLE1 = 1,
    };
    #endregion
    public void KnifeChangerAnimationFixThread(CancellationToken token)
    {
        bool shouldReloadModelIndex = true;
        int butterflyModelIndex = 0;
        int falchionModelIndex = 0;
        int cssModelIndex = 0;
        int ursusModelIndex = 0;
        int cordModelIndex = 0;
        int canisModelIndex = 0;
        int outdoorModelIndex = 0;
        int skeletonModelIndex = 0;
        int stilettoModelIndex = 0;
        int widowmakerModelIndex = 0;

        while (true)
        {
            if (shouldReloadModelIndex)
            {
                butterflyModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_butterfly.mdl");
                falchionModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_falchion_advanced.mdl");
                cssModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_css.mdl");
                ursusModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_ursus.mdl");
                cordModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_cord.mdl");
                canisModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_canis.mdl");
                outdoorModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_outdoor.mdl");
                skeletonModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_skeleton.mdl");
                stilettoModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_stiletto.mdl");
                widowmakerModelIndex = Engine.GetModelIndexByName("models/weapons/v_knife_widowmaker.mdl");
                shouldReloadModelIndex = false;
            }

            CBaseCombatWeapon currentWeapon = weaponList.ActiveWeapon;

            if (currentWeapon.ViewModelEntityModelIndex == butterflyModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_DRAW:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_BUTTERFLY_DRAW, (int)Sequence.SEQUENCE_BUTTERFLY_DRAW2);
                        break;
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_BUTTERFLY_LOOKAT01, (int)Sequence.SEQUENCE_BUTTERFLY_LOOKAT03);
                        break;
                }
            }
            else if (currentWeapon.ViewModelEntityModelIndex == falchionModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_IDLE2:
                        currentWeapon.Sequence = (int)Sequence.SEQUENCE_FALCHION_IDLE1;
                        break;
                    case (int)Sequence.SEQUENCE_DEFAULT_HEAVY_MISS1:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_FALCHION_HEAVY_MISS1, (int)Sequence.SEQUENCE_FALCHION_HEAVY_MISS1_NOFLIP);
                        break;
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_FALCHION_LOOKAT01, (int)Sequence.SEQUENCE_FALCHION_LOOKAT02);
                        break;
                }
            }
            else if (currentWeapon.ViewModelEntityModelIndex == cssModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_CSS_LOOKAT02, (int)Sequence.SEQUENCE_CSS_LOOKAT02);
                        break;
                }
            }
            else if (currentWeapon.ViewModelEntityModelIndex == ursusModelIndex ||
                     currentWeapon.ViewModelEntityModelIndex == cordModelIndex ||
                     currentWeapon.ViewModelEntityModelIndex == canisModelIndex ||
                     currentWeapon.ViewModelEntityModelIndex == outdoorModelIndex ||
                     currentWeapon.ViewModelEntityModelIndex == skeletonModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_DRAW:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_BUTTERFLY_DRAW, (int)Sequence.SEQUENCE_BUTTERFLY_DRAW2);
                        break;
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence((int)Sequence.SEQUENCE_BUTTERFLY_LOOKAT01, 14);
                        break;
                }
            }
            else if (currentWeapon.ViewModelEntityModelIndex == stilettoModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence(12, 13);
                        break;
                }
            }
            else if (currentWeapon.ViewModelEntityModelIndex == widowmakerModelIndex)
            {
                switch (currentWeapon.Sequence)
                {
                    case (int)Sequence.SEQUENCE_DEFAULT_LOOKAT01:
                        currentWeapon.Sequence = RandomSequence(14, 15);
                        break;
                }
            }
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
            Thread.Sleep(TimeSpan.FromMilliseconds(0.1));
        }
    }
    public static int RandomSequence(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
}
