using Shipwreck.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Shipwreck.Model.Items
{
    public class Inventory
    {
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }
        public List<InventoryRecord> Items { get; set; }

        public void AddItem(Item newItem, int quantity = 1)
        {
            var inventoryRecord = Items.FirstOrDefault(record => record.InventoryItem.Name == newItem.Name);
            if (inventoryRecord == null)
            {
                Items.Add(new InventoryRecord(newItem, quantity));
            } else
            {
                inventoryRecord.Quantity += quantity;
            }
        }

        public int DropItem(Item item, int quantity = 1)
        {
            int numDropped;
            if (item.Droppable)
            {
                numDropped = RemoveItems(item, quantity);
            } 
            else
            {
                throw new InventoryRecordNotFoundException($"You can't drop your {item.Name}");
            }

            return numDropped;
        }

        /* Doesn't restore used items if errs out in strict mode */
        public int RemoveItems(Item item, int quantity = 1, bool strict = false)
        {
            var i = 0;
            for (; i < quantity; i++)
            {
                var inventoryRecord = Items.Find(x => x.InventoryItem.Name.Equals(item.Name));
                if (inventoryRecord == null)
                {
                    if (strict)
                    {
                        AddItem(item, i);
                        throw new InventoryRecordNotFoundException("Insufficient items in inventory");
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

            return i;
        }
    }
}
