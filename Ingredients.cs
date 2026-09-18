using System.Collections.Generic;
using KitchenLib.Customs;
using KitchenLib.Utils;
using KitchenLib.References;
using UnityEngine;
using KitchenData;
using Kitchen;
using KitchenLib.Materials;
using System.Runtime.InteropServices;

namespace HotpotMod
{   
    public class FilledIngredientsBoard : CustomItemGroup
    {
        public override string UniqueNameID => "FilledIngredientsBoard";
        public override ItemStorage ItemStorageFlags => ItemStorage.Dish;
        public override Item DisposesTo => (Item)GDOUtils.GetExistingGDO(ItemReferences.ServingBoard);

        public override List<ItemGroup.ItemSet> Sets => new List<ItemGroup.ItemSet>
        {
            //Meat
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetCustomGameDataObject<BeefSlices>().GameDataObject
                }
            },   
            //Vegetables 
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.LettuceChopped)
                }
            },
            //Carbs
            new ItemGroup.ItemSet
            {
                Max = 1,
                Min = 1,
                IsMandatory = true,
                Items = new List<Item>
                {
                    (Item)GDOUtils.GetExistingGDO(ItemReferences.Rice)
                }
            } 
        };
    }
    public class BeefSlices : CustomItem
    {
        public override string UniqueNameID => "BeefSlices";
        public override ItemStorage ItemStorageFlags => ItemStorage.Small;
        public override GameObject Prefab => null;
    }
}
