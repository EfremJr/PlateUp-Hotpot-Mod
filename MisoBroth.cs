using System.Collections.Generic;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using UnityEngine;
using KitchenData;
using Kitchen;
using KitchenLib.Materials;

namespace HotpotMod
{
    public class MisoPacket : CustomItem
    {
        public override string UniqueNameID => "MisoPacket";

        public override ItemCategory ItemCategory => ItemCategory.Generic;
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<MisoPacketShelf>().GameDataObject;
        public override GameObject Prefab => null;
    }

    public class MisoPacketShelf : CustomAppliance
    {
        public override string UniqueNameID => "MisoPacketShelf";

        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.None;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override bool SellOnlyAsDuplicate => true;
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                ProvidedItem = GDOUtils.GetCustomGameDataObject<MisoPacket>().ID
            }    
        };
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (
                Locale.English,
                new ApplianceInfo
                {
                    Name = "Miso Packet Shelf", 
                    Description = "Provides Miso Packets"
                }
            )
        };

        public override GameObject Prefab => null;
    }


    public class UncookedMisoBroth : CustomItemGroup
    {
        public override string UniqueNameID => "UncookedMisoBroth";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
          new ItemGroup.ItemSet
          {
              Max = 3,
              Min = 3,
              IsMandatory = true,
              Items = new List<Item>
              {
                  (Item)GDOUtils.GetExistingGDO(ItemReferences.Water),
                  (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot),
                  (Item)GDOUtils.GetCustomGameDataObject<MisoPacket>().GameDataObject
              }
          }  
        };

        public override List<Item.ItemProcess> Processes => new List<Item.ItemProcess>
        {
            new Item.ItemProcess
            {
                Process = (Process)GDOUtils.GetExistingGDO(ProcessReferences.Cook),
                Result = (Item)GDOUtils.GetCustomGameDataObject<CookedMisoBroth>().GameDataObject,
                Duration = 10f,
                IsBad = false
            }    
        };

        public override GameObject Prefab => null;
        //modeled as packet or pile in water
        public override void OnRegister(ItemGroup gameDataObject)
        {
            ItemGroup basePot = (ItemGroup)GDOUtils.GetExistingGDO(ItemReferences.Pot);

            GameObject clonedPot = GameObject.Instantiate(basePot.Prefab);
            clonedPot.name = "UncookedMisoBroth_Prefab";
            
            MeshRenderer[] renderers = clonedPot.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                if (renderer.gameObject.name.Contains("Water") || renderer.gameObject.name.Contains("Liquid"))
                {
                    renderer.material = MaterialManager.GetMaterial("Soup - Meat");
                }

            }
            gameDataObject.Prefab = clonedPot;
        }
    }
    public class CookedMisoBroth : CustomItem
    {
        public override string UniqueNameID => "CookedMisoBroth";

        public override ItemStorage ItemStorageFlags => ItemStorage.None;

        public override int SplitCount => 4;

        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.Pot);

        public override Item SplitSubItem => (Item)GDOUtils.GetCustomGameDataObject<MisoBrothPortion>().GameDataObject;

        public override GameObject Prefab => null;

        //figure out texture stuff later
        public override void OnRegister(Item gameDataObject)
        {
            ItemGroup basePot = (ItemGroup)GDOUtils.GetExistingGDO(ItemReferences.Pot);

            GameObject clonedPot = GameObject.Instantiate(basePot.Prefab);
            clonedPot.name = "CookedMisoBroth_Prefab";

            MeshRenderer[] renderers = clonedPot.GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer renderer in renderers)
            {
                if (renderer.gameObject.name.Contains("Water") || renderer.gameObject.name.Contains("Liquid"))
                {
                    renderer.material = MaterialManager.GetMaterial("Soup - Meat");
                }

            }
            gameDataObject.Prefab = clonedPot;
        }
    }
    public class MisoBrothPortion : CustomItem
    {
        public override string UniqueNameID => "MisoBrothPortion";
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override GameObject Prefab => null;
        //set up model and texture later
    }

}


