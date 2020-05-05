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
            Food fish = new Food("Fish", "Fresh fish", 3);
            inventory.AddItem(fists);
            inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?
            inventory.AddItem(fish);

        }
    }
}
