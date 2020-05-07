using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Control
{
    class InventoryController
    {
        public static void AddDefaultItemsToInventory(Inventory inventory)
        {
            Weapon fists = new Weapon("Fists", "Fists of Fury", 1);
            Weapon spear = new Weapon("Spear", "Hunting Spear", 4);
            Food fish = new Food("Fish", "Fresh fish", 3);
            inventory.AddItem(fists);
            inventory.AddItem(spear);
            inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?
            inventory.AddItem(fish);
        }

        public static Item IsValidInventoryItem(Inventory inventory, string itemName)
        {
            Item match = inventory.Items.Find(x => x.Name == itemName);

            return match != null ? match: null;
        }
    }
}
