using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

// TODO read this. Use it
// https://scottlilly.com/how-to-build-stackable-inventory-for-a-game-in-c/

namespace Shipwreck.Model
{
    class Inventory
    {
        // public Character Character { get; }
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }
        public List<InventoryRecord> Items { get; private set; }


        public Inventory ()
        {
            Items = new List<InventoryRecord>();
        }

        public void AddItem(Item newItem)
        {
            InventoryRecord inventoryRecord = Items.Find(x => x.InventoryItem.Name.Equals(newItem.Name));
            if (inventoryRecord == null)
            {
                Items.Add(new InventoryRecord(newItem, 1));
            } else
            {
                ++inventoryRecord.Quantity;
            }
        }

        public bool DropItem(Item item)
        {
            bool dropped;
            if (item.Droppable)
            {
                InventoryRecord inventoryRecord = Items.Find(x => x.InventoryItem.Name.Equals(item.Name));
                if (inventoryRecord.Quantity > 1)
                {
                    --inventoryRecord.Quantity;
                } 
                else
                {
                    Items.Remove(inventoryRecord);

                    // remove active item if necessary
                    if (ActiveArmor.Name == inventoryRecord.InventoryItem.Name)
                    {
                        ActiveArmor = null;
                    }
                    else if (ActiveWeapon.Name == inventoryRecord.InventoryItem.Name)
                    {
                        ActiveWeapon = null;
                    }
                }
                dropped = true;
            } 
            else
            {
                dropped = false;
            }

            return dropped;
        }
    }
}
