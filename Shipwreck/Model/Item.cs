using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Item
    {
        private string ItemType { get; }
        private int Quantity { get; }
        private bool Droppable { get; set; }
    }
}
