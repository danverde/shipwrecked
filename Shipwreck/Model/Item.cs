using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Item
    {
        public string ItemType { get; protected set; }
        // private int Quantity { get; } // Pretty sure the inventory should handle this...
        // private bool Droppable { get; set; }

        public Item(string itemType)
        {
            ItemType = itemType;
        }
    }
}
