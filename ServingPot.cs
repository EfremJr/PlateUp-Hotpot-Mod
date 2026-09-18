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
    public class ServingPot : CustomItem
    {
        public override string UniqueNameID => "ServingPot";
        public override ItemStorage ItemStorageFlags => ItemStorage.None;
        public override Appliance DedicatedProvider => (Appliance)GDOUtils.GetCustomGameDataObject<ServingPotRack>().GameDataObject;
        public override GameObject Prefab => null;
    }
    
    public class ServingPotRack : CustomAppliance
    {
        public override string UniqueNameID => "ServingPotRack";
        public override bool IsPurchasable => true;
        public override ShoppingTags ShoppingTags => ShoppingTags.None;
        public override PriceTier PriceTier => PriceTier.Cheap;
        public override bool SellOnlyAsDuplicate => true;
        public override List<IApplianceProperty> Properties => new List<IApplianceProperty>
        {
            new CItemProvider
            {
                ProvidedItem = GDOUtils.GetCustomGameDataObject<ServingPot>().ID
            }    
        };
        public override List<(Locale, ApplianceInfo)> InfoList => new List<(Locale, ApplianceInfo)>
        {
            (
                Locale.English,
                new ApplianceInfo
                {
                    Name = "Serving Pot Rack", 
                    Description = "Provides Serving Pots"
                }
            )
        };

        public override GameObject Prefab => null;
    }

    public class FilledServingPot: CustomItemGroup
    {
        public override string UniqueNameID => "FilledServingPot";

        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;

        public override int MaxOrderSharers => 4;
        public override Item DisposesTo => (Item)GDOUtils.GetCustomGameDataObject<ServingPot>().GameDataObject;
        public override Item DirtiesTo => (Item)GDOUtils.GetCustomGameDataObject<ServingPot>().GameDataObject;

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<ServingPot>().GameDataObject
                }
            },
            new ItemGroup.ItemSet
            {
                Max = 2,
                Min = 2,
                IsMandatory = true,
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<MisoBrothPortion>().GameDataObject
                    //add new broths
                }
            }
        };

        public override GameObject Prefab => null;
    }
}