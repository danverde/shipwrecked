using Shipwreck.Control;
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
                  + "\n W - View Weapons & Armor"
                  + "\n F - View Food"
                  // + "\n R - View Resources" // resources not implemented yet
                  + "\n E - Eat Food"
                  + "\n S - Set Active Weapon or Armor"
                  + "\n D - Drop Item"
                  + "\n C - View Character"
                  + "\n X - Close Inventory"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            string menuItem = value.ToUpper();

            switch(menuItem)
            {
                case "A":
                    ShowAllItems();
                    break;
                case "W":
                    ViewWeaponsAndArmor();
                    break;
                case "F":
                    ViewFood();
                    break;
                // case "R":
                //     break;
                case "E":
                    EatFood();
                    break;
                case "S":
                    SetActiveWeaponOrArmor();
                    break;
                case "D":
                    DropItem();
                    break;
                case "C":
                    GameMenuView.ShowPlayerStats();
                    break;

            }
            return false;
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

        private void ViewWeaponsAndArmor()
        {
            throw new NotImplementedException();
        }

        private void ViewFood()
        {
            throw new NotImplementedException();
        }

        private void EatFood()
        {
            throw new NotImplementedException();
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
            if (itemName.ToUpper() == "X")
            {
                return null;
            }

            return InventoryController.IsValidInventoryItem(inventory, itemName) ?? null;
        }
    }
}
