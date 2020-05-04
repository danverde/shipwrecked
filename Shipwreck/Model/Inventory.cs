using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Inventory
    {
        // public Character Character { get; }
        public Item ActiveWeapon { get; set; }
        public List<Item> Items { get; private set; }

        public Inventory ()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item newItem)
        {
            Items.Add(newItem);
        }
    }
}
