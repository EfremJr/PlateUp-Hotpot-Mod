using KitchenMods;
using KitchenLib;
using UnityEngine;
using System.Reflection;
using KitchenLib.Logging;
using System.Linq;
using KitchenData;
using KitchenLib.Utils;
using Kitchen;
using KitchenLib.References;

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
            AddGameDataObject<MisoPacketShelf>();
            AddGameDataObject<MisoBrothPortion>();

            AddGameDataObject<ServingPot>();
            AddGameDataObject<ServingPotRack>();
            AddGameDataObject<FilledServingPot>();

            AddGameDataObject<BeefSlices>();
            
            AddGameDataObject<FilledIngredientsBoard>();
        }

        //internal static AssetBundleModPack bundle;
        internal static KitchenLogger Logger;

        protected override void OnPostActivate(Mod mod)
        {
            Logger = InitLogger();

            Item thinMeat = (Item)GDOUtils.GetExistingGDO(ItemReferences.MeatThin);

            thinMeat.DerivedProcesses.Add(new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Chop),
                Result = (Item)GDOUtils.GetCustomGameDataObject<BeefSlices>().GameDataObject,
                Duration = 3f,
                IsBad = false
            });
            
            //bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
        }
    }
}