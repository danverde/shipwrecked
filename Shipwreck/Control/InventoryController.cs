﻿using Shipwreck.Exceptions;
using Shipwreck.Model;
using Shipwreck.Model.Factories;
using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace Shipwreck.Control
{
    class InventoryController
    {
        public static void AddDefaultItemsToInventory(Inventory inventory)
        {
            ArmorFactory armorFactory = new ArmorFactory();
            FoodFactory foodFactory = new FoodFactory();
            ResourceFactory resourceFactory = new ResourceFactory();
                                 
            // Spear spear = new Spear();
            Fists fists = new Fists();
            Armor suit = armorFactory.GetArmor(Armor.Type.Suit);

            Food fish = foodFactory.GetFood(Food.Type.Fish);

            Resource match = resourceFactory.GetResource(Resource.Type.Match);
            Resource vine = resourceFactory.GetResource(Resource.Type.Vine);

            inventory.AddItem(fists);
            // inventory.AddItem(spear);
            inventory.AddItem(suit);
            inventory.ActiveArmor = suit;
            // inventory.ActiveWeapon = fists; // how do I make it so that the active weapon references an item in the inventory?

            inventory.AddItem(match, 3);
            inventory.AddItem(vine, 6);

            inventory.AddItem(fish, 3);
        }

        public static IItem GetItemFromInventory(Inventory inventory, string itemName)
        {
            InventoryRecord match = inventory.Items.Find(x => x.InventoryItem.Name == itemName);

            return match?.InventoryItem;
        }

        public static List<InventoryRecord> GetItemsByType<T>(Inventory inventory)
        {
            return inventory.Items.FindAll(x => x.InventoryItem.GetType() == typeof(T) || x.InventoryItem.GetType().IsSubclassOf(typeof(T)));
        }

        public static void BuildWeapon(Inventory inventory, string itemToBuild)
        {   
            // Build the weapon
            WeaponFactory weaponFactory = new WeaponFactory();
            Weapon weapon = weaponFactory.GetWeapon(itemToBuild);
            if (weapon == null || !(weapon is ICraftable))
            {
                throw new InventoryException("You can't build that!");
            }

            List<InventoryRecord> inventoryCopy = new List<InventoryRecord>(inventory.Items);

            // Get list of required items
            Dictionary<string, int> requiredItems = (Dictionary<string, int>)weapon.GetType().GetProperty("RequiredItems").GetValue(null, null);
            
            // Check inventory for required materials
            foreach (KeyValuePair<string, int> requiredItem in requiredItems)
            {
                InventoryRecord inventoryRecord = inventory.Items.Find(x => x.InventoryItem.Name == requiredItem.Key);
                if ( inventoryRecord == null || requiredItem.Value > inventoryRecord.Quantity)
                {
                    // not enough items!!
                    throw new InventoryException($"You need {requiredItem.Value} {requiredItem.Key}(s) to build that");
                }
                try
                {
                    // remove items from inventory
                    inventory.RemoveItems(inventoryRecord.InventoryItem, requiredItem.Value, true);
                }
                catch(InventoryException e)
                {
                    inventory.Items = inventoryCopy;
                    throw e;
                }
            }

            // add weapon to inventory
            inventory.AddItem(weapon);

            // equip weapon?
        }
    }
}
