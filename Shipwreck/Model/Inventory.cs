﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shipwreck.Model
{
    class Inventory
    {
        // public Character Character { get; }
        public Weapon ActiveWeapon { get; set; }
        public List<Item> Items { get; private set; }

        // I want to save the full item, not just the item type...
        // public Dictionary<string, int> Items { get; private set; }

        public Inventory ()
        {
            Items = new List<Item>();
        }

        public void AddItem(Item newItem)
        {
            Item matchingItem = Items.Find(x => x.Name.Equals(newItem.Name));
            if (matchingItem == null)
            {
                Items.Add(newItem);
            } else
            {
                ++matchingItem.Quantity;
            }
            
        }
    }
}