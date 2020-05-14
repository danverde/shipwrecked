using Shipwreck.Model;
using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Shipwreck.Control
{
    class InventoryController
    {
        public static void AddDefaultItemsToInventory(Inventory inventory)
        {
            // Spear spear = new Spear();
            Fists fists = new Fists();
            Armor suit = new Armor("Suit", "A Once Fine Business Suit", 0);

            Food fish = new Food("Fish", "Fresh fish", 2, 3);

            Resource match = new Resource("Match", "A waterproof match");
            Resource vine = new Resource("Vine", "Jungle Vines");

            inventory.AddItem(fists);
            // inventory.AddItem(spear);
            inventory.AddItem(suit);
            inventory.ActiveArmor = suit;
            inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?

            inventory.AddItem(match, 3);
            inventory.AddItem(vine, 6);

            inventory.AddItem(fish, 3);
        }

        public static Item IsValidInventoryItem(Inventory inventory, string itemName)
        {
            InventoryRecord match = inventory.Items.Find(x => x.InventoryItem.Name == itemName);

            return match?.InventoryItem ?? null;
        }

        public static List<InventoryRecord> GetItemsByType<T>(Inventory inventory)
        {
            return inventory.Items.FindAll(x => x.InventoryItem.GetType() == typeof(T) || x.InventoryItem.GetType().IsSubclassOf(typeof(T)));
        }

        public static void BuildWeapon(Inventory inventory, string itemToBuild)
        {
            // I'll have to implement custom exceptions in order to pass errors to the view
            
            // Build the weapon
            ConcreteWeaponFactory weaponFactory = new ConcreteWeaponFactory();
            Weapon weapon = weaponFactory.GetWeapon(itemToBuild);
            if (weapon == null)
            {
                throw new Exception($"{itemToBuild} is not a buildable item");
            }


            // Check inventory for required materials
            foreach (KeyValuePair<string, int> requiredItem in ((ICraftable)weapon).RequiredItems)
            {
                InventoryRecord inventoryItem = inventory.Items.Find(x => x.InventoryItem.Name == requiredItem.Key);
                if ( inventoryItem == null || requiredItem.Value > inventoryItem.Quantity)
                {
                    // not enough items!!
                    throw new Exception($"You need {requiredItem.Value} {requiredItem.Key}(s) to build a(n) {itemToBuild}");
                }
            }


            // remove items from inventory
            foreach (KeyValuePair<string, int> requiredItem in ((ICraftable)weapon).RequiredItems)
            {
                InventoryRecord inventoryRecord = inventory.Items.Find(x => x.InventoryItem.Name == requiredItem.Key);
                
                for (int i = 0; i < requiredItem.Value; i++)
                {
                    inventory.RemoveItem(inventoryRecord.InventoryItem);
                }
            }

            // add weapon to inventory
            inventory.AddItem(weapon);

            // equip weapon?
        }
    }
}
