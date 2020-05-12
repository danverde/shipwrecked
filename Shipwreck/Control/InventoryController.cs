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
            Weapon fists = new Weapon("Fists", "Fists of Fury", 1, false);
            // Spear spear = new Spear();
            Weapon spear = new Weapon("Spear", "Hunting Spear", 4);
            Armor suit = new Armor("Suit", "A Once Fine Business Suit", 0);
            Food fish = new Food("Fish", "Fresh fish", 2, 3);
            inventory.AddItem(fists);
            inventory.AddItem(spear);
            inventory.AddItem(suit);
            inventory.ActiveArmor = suit;
            inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?
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

        // I wonder how I could create 1 BuildItem() method, instead of creating a new method for every single item...
        // public Weapon BuildSpear()
        // {
            // check if the current inventory allows it
            // Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            // somehow we need to store all the required items & item quantities in order to build an item.
            // inventory.Items.Find(x => x.InventoryItem.Name == "");
            // return new Weapon("Spear", "Hunting Spear", 4);
        // }
    }
}
