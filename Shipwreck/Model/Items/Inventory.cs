using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shipwreck.Model.Items
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

        public void AddItem(Item newItem, int quantity = 1)
        {
            InventoryRecord inventoryRecord = Items.Find(x => x.InventoryItem.Name.Equals(newItem.Name));
            if (inventoryRecord == null)
            {
                Items.Add(new InventoryRecord(newItem, quantity));
            } else
            {
                inventoryRecord.Quantity += quantity;
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
                    // remove active item if necessary
                    if (ActiveArmor?.Name == inventoryRecord.InventoryItem.Name)
                    {
                        ActiveArmor = null;
                    }
                    else if (ActiveWeapon?.Name == inventoryRecord.InventoryItem.Name)
                    {
                        ActiveWeapon = null;
                    }

                    Items.Remove(inventoryRecord);
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
