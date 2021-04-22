using System;
using Shipwreck.Model.Items;
using System.Collections.Generic;
using System.Linq;

namespace Shipwreck.Control
{
    public static class InventoryController
    {
        public static Item GetItemFromInventory(Inventory inventory, string itemName)
        {
            var match = inventory.Items.Find(x => x.InventoryItem.Name == itemName);

            return match?.InventoryItem;
        }

        public static List<InventoryRecord> GetItemsByType<T>(Inventory inventory)
        {
            return inventory.Items.FindAll(x => x.InventoryItem.GetType() == typeof(T) || x.InventoryItem.GetType().IsSubclassOf(typeof(T)));
        }
        
        public static void AddItem(Inventory inventory, Item newItem, int quantity = 1)
        {
            var inventoryRecord = inventory.Items.FirstOrDefault(record => record.InventoryItem.Name == newItem.Name);
            if (inventoryRecord == null)
            {
                inventory.Items.Add(new InventoryRecord(newItem, quantity));
            } else
            {
                inventoryRecord.Quantity += quantity;
            }
        }

        public static bool TryRemoveItems(Inventory inventory, Item item, int quantity = 1)
        {
            try
            {
                RemoveItems(inventory, item, quantity);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
        public static int RemoveItems(Inventory inventory, Item item, int quantity = 1)
        {
            int quantityRemoved;
            var inventoryRecord = inventory.Items.FirstOrDefault(record => record.InventoryItem.Name.Equals(item.Name));
            if (inventoryRecord == null) return 0;

            // remove items from inventory
            if (quantity >= inventoryRecord.Quantity)
            {
                quantityRemoved = inventoryRecord.Quantity;
                inventory.Items.Remove(inventoryRecord);
            }
            else
            {
                quantityRemoved = quantity;
                inventoryRecord.Quantity -= quantity;
            }
            
            // remove active weapons/armor if applicable
            if (inventory.ActiveArmor?.Name == inventoryRecord.InventoryItem.Name)
            {
                inventory.ActiveArmor = null;
            }
            else if (inventory.ActiveWeapon?.Name == inventoryRecord.InventoryItem.Name)
            {
                inventory.ActiveWeapon = null;
            }
            

            return quantityRemoved;
        }
    }
}
