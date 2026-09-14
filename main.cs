using KitchenMods;
using KitchenLib;
using UnityEngine;
using System.Reflection;
using KitchenLib.Logging;
using System.Linq;

namespace HotpotMod
{
    public class Main : BaseMod, IModSystem
    {
        // Mod Metadata
        public const string MOD_GUID = "com.night.hotpotmod";
        public const string MOD_NAME = "Hotpot Mod";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "Night";
        public const string MOD_GAMEVERSION = ">=1.5.0";

        public Main() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly())
        {
            AddGameDataObject<MisoPacket>();
            AddGameDataObject<UncookedMisoBroth>();
            AddGameDataObject<CookedMisoBroth>();
        }

        //internal static AssetBundleModPack bundle;
        internal static KitchenLogger Logger;

        protected override void OnPostActivate(Mod mod)
        {
            Logger = InitLogger();
            
            //bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
        }
    }
}