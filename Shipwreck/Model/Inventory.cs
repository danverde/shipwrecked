using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Shipwreck.Model
{
    class Inventory
    {
        // public Character Character { get; }
        public Weapon ActiveWeapon { get; set; }
        public Armor ActiveArmor { get; set; }
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

        public bool DropItem(Item item)
        {
            bool dropped;
            if (item.Droppable)
            {
                // do crap 
                Item inventoryItem = Items.Find(x => x.Name.Equals(item.Name));
                if (inventoryItem.Quantity > 1)
                {
                    --inventoryItem.Quantity;
                } 
                else
                {
                    Items.Remove(inventoryItem);

                    // remove active item if necessary
                    if (ActiveArmor == inventoryItem)
                    {
                        ActiveArmor = null;
                    }
                    else if (ActiveWeapon == inventoryItem)
                    {
                        ActiveWeapon = null;
                    }
                }
                dropped = true;
            } 
            else
            {
                dropped = false;
            }

            return dropped;
        }
    }
}
