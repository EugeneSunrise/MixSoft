using MixSoft.Objects.Structs;
using System;
using System.Collections.Generic;
using System.Drawing;


namespace MixSoft.Objects
{
    class KnifeObj
    {
        public ItemDefinitionIndex itemDefinitionIndex;
        public string modelName;

        public KnifeObj(ItemDefinitionIndex i, string m)
        {
            this.itemDefinitionIndex = i;
            this.modelName = m;
        }
    }

    static class Constants
    {
        public static Dictionary<string, KnifeObj> KnifeList = InitializeList();

        private static Dictionary<string, KnifeObj> InitializeList()
        {
            Dictionary<string, KnifeObj> res = new Dictionary<string, KnifeObj>();

            string[] listNames =    {"BAYONET",
                                    "FLIP",
                                    "GUT",
                                    "KARAMBIT",
                                    "M9BAYONET",
                                    "HUNTSMAN",
                                    "FALCHION",
                                    "BUTTERFLY",
                                    "URSUS",
                                    "NAVAJA",
                                    "STILETTO",
                                    "TALON",
                                    "CSS",
                                    //"PUSH",
                                    //"BOWIE",
                                    "PARACORD",
                                    "SURVIVAL",
                                    "NOMAD",
                                    "SKELETON"};

            string[] itemDefNames = {"BAYONET",
                                    "FLIP",
                                    "GUT",
                                    "KARAMBIT",
                                    "M9BAYONET",
                                    "HUNTSMAN",
                                    "FALCHION",
                                    "BUTTERFLY",
                                    "URSUS",
                                    "NAVAJA",
                                    "STILETTO",
                                    "TALON",
                                    "CSS",
                                    //"PUSH",
                                    //"BOWIE",
                                    "PARACORD",
                                    "SURVIVAL",
                                    "NOMAD",
                                    "SKELETON"};

            string[] knifeModels = {"models/weapons/v_knife_bayonet.mdl",
                                    "models/weapons/v_knife_flip.mdl",
                                    "models/weapons/v_knife_gut.mdl",
                                    "models/weapons/v_knife_karam.mdl",
                                    "models/weapons/v_knife_m9_bay.mdl",
                                    "models/weapons/v_knife_tactical.mdl",
                                    "models/weapons/v_knife_falchion_advanced.mdl",
                                    "models/weapons/v_knife_butterfly.mdl",
                                    "models/weapons/v_knife_ursus.mdl",
                                    "models/weapons/v_knife_gypsy_jackknife.mdl",
                                    "models/weapons/v_knife_stiletto.mdl",
                                    "models/weapons/v_knife_widowmaker.mdl",
                                    "models/weapons/v_knife_css.mdl",
                                    //"models/weapons/v_knife_push.mdl",
                                    //"models/weapons/v_knife_survival_bowie.mdl",
                                    "models/weapons/v_knife_cord.mdl",
                                    "models/weapons/v_knife_canis.mdl",
                                    "models/weapons/v_knife_outdoor.mdl",
                                    "models/weapons/v_knife_skeleton.mdl" };

            for (int i = 0; i < 17; i++)
            {
                res.Add(listNames[i], new KnifeObj((ItemDefinitionIndex)Enum.Parse(typeof(ItemDefinitionIndex), itemDefNames[i]), knifeModels[i]));
            }

            return res;
        }
    }

    static class Globals
    {
        public static bool SkinChangerEnabled = false;
        public static bool KnifeChangerEnabled = false;
        public static bool KnifeChangerAnimFixEnabled = false;
        public static bool ManualLoadEnabled = false;
        public static string SelectedKnife = "BAYONET";

        private static int _IdleWait = 10;
        public static int IdleWait
        {
            get
            {
                return _IdleWait;
            }
            set
            {
                _IdleWait = 10;
            }
        }

        public static Dictionary<string, SkinObj> CsgoSkinList = new Dictionary<string, SkinObj>();
        public static List<Skin> LoadedPresets = new List<Skin>();
    }

    static class GlobalLists
    {
        public static EntityList entityList = new EntityList();
        public static WeaponList weaponList = new WeaponList();
    }
     
    static class RuntimeGlobals
    {
        public static int selectedKnifeModelIndex = 0;
    }
}
