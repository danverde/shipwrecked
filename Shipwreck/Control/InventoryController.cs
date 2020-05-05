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
            Weapon fists = new Weapon("Fists", 1);
            Food fish = new Food("Fish", 3);
            inventory.ActiveWeapon = fists;
            inventory.AddItem(fish);

        }
    }
}
