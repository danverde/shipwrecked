using Shipwreck.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shipwreck.Model.Items
{
    class Inventory
    {
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }
        public List<InventoryRecord> Items { get; set; }


        public Inventory()
        {
            Items = new List<InventoryRecord>();
        }

        public void AddItem(IItem newItem, int quantity = 1)
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

        public bool DropItem(IItem item, int quantity = 1)
        {
            bool dropped;
            if (item.Droppable)
            {
                RemoveItems(item, quantity);
                dropped = true;
            } 
            else
            {
                dropped = false;
            }

            return dropped;
        }

        public void RemoveItems(IItem item, int quantity = 1, bool strict = false)
        {
            for (int i = 0; i < quantity; i++)
            {
                InventoryRecord inventoryRecord = Items.Find(x => x.InventoryItem.Name.Equals(item.Name));
                if (inventoryRecord == null)
                {
                    if (strict)
                    {
                        throw new InventoryException("Insufficient items in inventory");
                    }
                    else
                    {
                        break;
                    }
                }

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
            }
        }
    }
}
