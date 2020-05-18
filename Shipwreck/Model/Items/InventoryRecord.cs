using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class InventoryRecord
    {
        public IItem InventoryItem { get; set; }
        public int Quantity { get; set; }

        public InventoryRecord(IItem item, int quantity)
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
