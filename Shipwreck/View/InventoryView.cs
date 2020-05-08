﻿using Shipwreck.Control;
using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class InventoryView : View
    {
        public InventoryView()
            :base("\n\n----------------------------------"
                  + "\n| Inventory Menu"
                  + "\n----------------------------------"
                  + "\n A - View All Items"
                  + "\n G - View Gear"
                  + "\n F - View Food"
                  // + "\n R - View Resources" // resources not implemented yet
                  + "\n E - Eat Food"
                  + "\n Q - Equip Gear"
                  + "\n D - Drop Item"
                  + "\n C - View Character"
                  + "\n X - Close Inventory"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            string menuItem = value.ToUpper();
            bool done = false;

            switch(menuItem)
            {
                case "A":
                    ShowAllItems();
                    break;
                case "G":
                    ViewGear();
                    break;
                case "F":
                    ViewFood();
                    break;
                // case "R":
                //     break;
                case "E":
                    done = EatFood();
                    break;
                case "Q":
                    SetActiveWeaponOrArmor();
                    break;
                case "D":
                    DropItem();
                    break;
                case "C":
                    GameMenuView.ShowPlayerStats();
                    break;

            }
            return done;
        }

        private void ShowAllItems()
        {
            StringBuilder line;
            Inventory inventory = Shipwreck.CurrentGame.Player.Inventory;

            Console.WriteLine("\n-------------------------\n Inventory:\n-------------------------");
            Console.WriteLine($" Active Weapon: {inventory.ActiveWeapon?.Name ?? "None"} +{inventory.ActiveWeapon?.AttackPower ?? 0}");
            Console.WriteLine($" Active Armor:  {inventory.ActiveArmor?.Name ?? "None"} +{inventory.ActiveArmor?.DefensePower ?? 0}");

            line = new StringBuilder("                                              ");
            line.Insert(1, "ITEM");
            line.Insert(16, "QTY");
            line.Insert(20, "DESC");
            Console.WriteLine(line);

            foreach (InventoryRecord itemRecord in inventory.Items)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, itemRecord.InventoryItem.Name);
                line.Insert(16, itemRecord.Quantity);
                line.Insert(20, itemRecord.InventoryItem.Description);
                Console.WriteLine(line);
            }
            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ViewGear()
        {
            StringBuilder line;
            Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            List<InventoryRecord> gearItems = InventoryController.GetItemsByType<Weapon>(inventory);
            gearItems.AddRange(InventoryController.GetItemsByType<Armor>(inventory));

            Console.WriteLine("\n-------------------------\n Gear:\n-------------------------");

            line = new StringBuilder("                                              ");
            line.Insert(1, "T");
            line.Insert(4, "ITEM");
            line.Insert(19, "QTY");
            line.Insert(23, "BONUS");
            Console.WriteLine(line);

            foreach (InventoryRecord gear in gearItems)
            {
                // Type itemType = gear.InventoryItem.GetType();
                int itemBonus = 0;
                bool isActive = false;

                if (gear.InventoryItem.GetType() == typeof(Armor))
                {
                    itemBonus = ((Armor)gear.InventoryItem).DefensePower;
                    isActive = inventory.ActiveArmor.Name == gear.InventoryItem.Name;
                }
                else if (gear.InventoryItem.GetType() == typeof(Weapon))
                {
                    itemBonus = ((Weapon)gear.InventoryItem).AttackPower;
                    isActive = inventory.ActiveWeapon.Name == gear.InventoryItem.Name;
                }

                line = new StringBuilder("                                              ");
                line.Insert(1, gear.InventoryItem.GetType() == typeof(Armor) ? "A" : "W");
                line.Insert(3, isActive ? "*" : "");
                line.Insert(4, gear.InventoryItem.Name);
                line.Insert(19, gear.Quantity);
                line.Insert(23, $"+{itemBonus}");
                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void ViewFood()
        {
            StringBuilder line;
            Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            List<InventoryRecord> foodItems = InventoryController.GetItemsByType<Food>(inventory);

            Console.WriteLine("\n-------------------------\n Food:\n-------------------------");

            line = new StringBuilder("                                              ");
            line.Insert(1, "ITEM");
            line.Insert(16, "QTY");
            line.Insert(20, "HLTH");
            line.Insert(25, "HNGR");
            Console.WriteLine(line);

            foreach (InventoryRecord foodItem in foodItems)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, foodItem.InventoryItem.Name);
                line.Insert(16, foodItem.Quantity);
                line.Insert(20, ((Food)foodItem.InventoryItem).HealingPower);
                line.Insert(25, ((Food)foodItem.InventoryItem).FillingPower);
                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private bool EatFood()
        { 
            bool done = false;
            Player player = Shipwreck.CurrentGame?.Player;
            Inventory inventory = player.Inventory;
            Item itemToEat = GetInventoryItem("Which item would you like to eat?");
            if (itemToEat != null)
            {
                if (itemToEat.Droppable == false)
                {
                    Console.WriteLine($"You can't eat your {itemToEat.Name}");
                }
                else if (itemToEat.GetType() == typeof(Food))
                {
                    // should this be happening in a controller?
                    player.Eat((Food)itemToEat);
                    inventory.DropItem(itemToEat);

                    Console.WriteLine("Delicious!");

                }
                else
                {
                    Console.WriteLine("Oops. That wasn't edible...");
                    GameController.EndGame();
                    done = true;
                }
            }
            else
            {
                Console.WriteLine($"That is not an item that exists in your inventory");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();

            return done;
        }

        private void SetActiveWeaponOrArmor()
        {
            Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            Item itemToEquip = GetInventoryItem("Which item would you like to equip?");
            if (itemToEquip != null)
            {
                if (itemToEquip.GetType() == typeof(Weapon))
                {
                    inventory.ActiveWeapon = (Weapon)itemToEquip;
                }
                else if (itemToEquip.GetType() == typeof(Armor))
                {
                    inventory.ActiveArmor = (Armor)itemToEquip;
                }
                Console.WriteLine($"Your {itemToEquip.Name} has been equipped");
            }
            else
            {
                Console.WriteLine($"That is not an item that exists in your inventory");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void DropItem()
        {
            Inventory inventory = Shipwreck.CurrentGame?.Player.Inventory;
            Item itemToDrop = GetInventoryItem("Which item would you like to drop?");
            if (itemToDrop != null)
            {
                bool dropped = inventory.DropItem(itemToDrop);
                if (dropped)
                {
                    Console.WriteLine($"You dropped your {itemToDrop.Name}");
                }
                else
                {
                    Console.WriteLine($"You can't drop your {itemToDrop.Name}");
                }
            }
            else
            {
                Console.WriteLine($"That is not an item that exists in your inventory");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private Item GetInventoryItem(string message)
        {
            Inventory inventory = Shipwreck.CurrentGame.Player.Inventory;
            Console.WriteLine(message);
            string itemName = Console.ReadLine();

            return InventoryController.IsValidInventoryItem(inventory, itemName) ?? null;
        }
    }
}
