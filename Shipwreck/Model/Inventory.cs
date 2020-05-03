using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Inventory
    {
        private Character Character { get; }
        private List<Item> Items { get; set; }
    }
}
