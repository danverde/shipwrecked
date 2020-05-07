using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class InventoryRecord
    {
        public Item InventoryItem { get; set; }
        public int Quantity { get; set; }

        public InventoryRecord(Item item, int quantity)
        {
            InventoryItem = item;
            Quantity = quantity;
        }

        public void AddToQuantity(int amountToAdd)
        {
            Quantity += amountToAdd;
        }
    }
}
