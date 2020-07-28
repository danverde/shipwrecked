using System;
using Shipwreck.Exceptions;
using Shipwreck.Model.Factories;
using Shipwreck.Model.Items;
using System.Collections.Generic;

namespace Shipwreck.Control
{
    static class InventoryController
    {
        public static void AddDefaultItemsToInventory(Inventory inventory)
        {
            var armorFactory = new ArmorFactory();
            var foodFactory = new FoodFactory();
                                 
            // Spear spear = new Spear();
            var fists = new Fists();
            var suit = armorFactory.GetArmor(Armor.Type.Suit);

            var fish = foodFactory.GetFood(Food.Type.Fish);

            var match = Shipwreck.ResourceFactory.GetResource(Resource.Type.Match);
            var vine = Shipwreck.ResourceFactory.GetResource(Resource.Type.Vine);
            var branch = Shipwreck.ResourceFactory.GetResource(Resource.Type.Branch);

            inventory.AddItem(fists);
            // inventory.AddItem(spear);
            inventory.AddItem(suit);
            inventory.ActiveArmor = suit;
            inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?

            inventory.AddItem(match, 3);
            inventory.AddItem(vine, 6);
            inventory.AddItem(branch, 3);

            inventory.AddItem(fish, 3);
        }

        public static IItem GetItemFromInventory(Inventory inventory, string itemName)
        {
            var match = inventory.Items.Find(x => x.InventoryItem.Name == itemName);

            return match?.InventoryItem;
        }

        public static List<InventoryRecord> GetItemsByType<T>(Inventory inventory)
        {
            return inventory.Items.FindAll(x => x.InventoryItem.GetType() == typeof(T) || x.InventoryItem.GetType().IsSubclassOf(typeof(T)));
        }

        public static void BuildWeapon(Inventory inventory, string itemToBuild)
        {   
            // Build the weapon
            var weaponFactory = new WeaponFactory();
            var weapon = weaponFactory.GetWeapon(itemToBuild);
            if (weapon == null || !(weapon is ICraftable))
            {
                throw new InventoryException("You can't build that!");
            }

            // TODO broken
            var inventoryCopy = new List<InventoryRecord>(inventory.Items);

            // Get list of required items
            var requiredItems = (Dictionary<string, int>)weapon.GetType().GetProperty("RequiredItems").GetValue(null, null);
            
            // Check inventory for required materials
            foreach (var requiredItem in requiredItems)
            {
                var inventoryRecord = inventory.Items.Find(x => x.InventoryItem.Name == requiredItem.Key);
                if ( inventoryRecord == null || requiredItem.Value > inventoryRecord.Quantity)
                {
                    // not enough items!!
                    throw new InventoryException($"You need {requiredItem.Value} {requiredItem.Key}(s) to build that");
                }
                try
                {
                    // remove items from inventory
                    inventory.RemoveItems(inventoryRecord.InventoryItem, requiredItem.Value, true);
                }
                catch(InventoryException e)
                {
                    inventory.Items = inventoryCopy;
                    throw e;
                }
            }

            // add weapon to inventory
            inventory.AddItem(weapon);

            // equip weapon?
        }
    }
}
