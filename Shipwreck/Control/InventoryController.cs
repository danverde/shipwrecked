using System;
using Shipwreck.Model.Items;
using System.Collections.Generic;

namespace Shipwreck.Control
{
    static class InventoryController
    {
        public static void AddDefaultItemsToInventory(Inventory inventory)
        {
            var weaponFactory = Shipwreck.WeaponFactory;
            var armorFactory = Shipwreck.ArmorFactory;
            var foodFactory = Shipwreck.FoodFactory;
            var resourceFactory = Shipwreck.ResourceFactory;
                                 
            var spear = weaponFactory.GetWeapon(WeaponType.Spear);
            var fists = weaponFactory.GetWeapon(WeaponType.Fists);
            
            var suit = armorFactory.GetArmor(ArmorType.Suit);
            
            var fish = foodFactory.GetFood(FoodType.Fish);

            var match = resourceFactory.GetResource(ResourceType.Match);
            var vine = resourceFactory.GetResource(ResourceType.Vine);
            var branch = resourceFactory.GetResource(ResourceType.Branch);

            inventory.AddItem(fists);
            inventory.AddItem(spear);
            inventory.AddItem(suit);
            inventory.ActiveArmor = suit;
            inventory.ActiveWeapon = fists;

            inventory.AddItem(fish, 3);
            
            inventory.AddItem(match, 3);
            inventory.AddItem(vine, 6);
            inventory.AddItem(branch, 3);
        }

        public static Item GetItemFromInventory(Inventory inventory, string itemName)
        {
            var match = inventory.Items.Find(x => x.InventoryItem.Name == itemName);

            return match?.InventoryItem;
        }

        public static List<InventoryRecord> GetItemsByType<T>(Inventory inventory)
        {
            return inventory.Items.FindAll(x => x.InventoryItem.GetType() == typeof(T) || x.InventoryItem.GetType().IsSubclassOf(typeof(T)));
        }
    }
}
