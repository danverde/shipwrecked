using Shipwreck.Control;
using Shipwreck.Exceptions;
using Shipwreck.Model.Items;
using System;
using System.Text;

namespace Shipwreck.View
{
    class InventoryMenuView : View
    {
        public InventoryMenuView()
        {
            InGameView = true;
            Message = "\n\n----------------------------------"
                      + "\n| Inventory Menu"
                      + "\n----------------------------------"
                      + "\n A - View All Items"
                      + "\n G - View Gear"
                      + "\n F - View Food"
                      + "\n R - View Resources"
                      + "\n E - Eat Food"
                      + "\n Q - Equip Gear"
                      + "\n D - Drop Item"
                      + "\n C - View Character"
                      + "\n B - Build Weapon"
                      + "\n H - Inventory Help"
                      + "\n X - Close Inventory"
                      + "\n----------------------------------";
        }

        protected override bool HandleInput(string menuItem)
        {
            var done = false;

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
                case "R":
                    ViewResources();
                    break;
                case "E":
                    done = EatFood();
                    break;
                case "Q":
                    EquipGear();
                    break;
                case "D":
                    DropItem();
                    break;
                case "C":
                    new GameMenuView().ShowPlayerStats();
                    break;
                case "B":
                    BuildWeapon();
                    break;
                case "H":
                    ShowInventoryHelpView();
                    break;

            }
            return done;
        }

        private void ShowAllItems()
        {
            StringBuilder line;
            var inventory = Shipwreck.CurrentGame.Player.Inventory;

            Console.WriteLine("\n-------------------------\n Inventory:\n-------------------------");
            Console.WriteLine($" Active Weapon: {inventory.ActiveWeapon?.Name ?? "None"} +{inventory.ActiveWeapon?.AttackPower ?? 0}");
            Console.WriteLine($" Active Armor:  {inventory.ActiveArmor?.Name ?? "None"} +{inventory.ActiveArmor?.DefensePower ?? 0}");
            Console.WriteLine("");
            
            line = new StringBuilder("                                              ");
            line.Insert(1, "ITEM");
            line.Insert(16, "QTY");
            line.Insert(20, "DESC");
            Console.WriteLine(line);

            foreach (var itemRecord in inventory.Items)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, itemRecord.InventoryItem.Name);
                line.Insert(16, itemRecord.Quantity);
                line.Insert(20, itemRecord.InventoryItem.Description);
                Console.WriteLine(line);
            }
            Console.WriteLine("-------------------------");

            Continue();
        }

        private void ViewGear()
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            var gearItems = InventoryController.GetItemsByType<IGear>(inventory);

            Console.WriteLine("\n-------------------------\n Gear:\n-------------------------");

            var line = new StringBuilder("                                              ");
            line.Insert(1, "T");
            line.Insert(4, "ITEM");
            line.Insert(19, "QTY");
            line.Insert(23, "BONUS");
            Console.WriteLine(line);

            foreach (var gear in gearItems)
            {
                // Type itemType = gear.InventoryItem.GetType();
                var itemBonus = 0;
                var isActive = false;

                if (gear.InventoryItem.GetType() == typeof(Armor))
                {
                    itemBonus = ((Armor)gear.InventoryItem).DefensePower;
                    isActive = inventory.ActiveArmor.Name == gear.InventoryItem.Name;
                }
                else if (gear.InventoryItem.GetType().IsSubclassOf(typeof(Weapon)))
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

            Continue();
        }

        private void ViewFood()
        {
            StringBuilder line;
            var inventory = Shipwreck.CurrentGame?.Player.Inventory;
            var foodItems = InventoryController.GetItemsByType<Food>(inventory);

            Console.WriteLine("\n-------------------------\n Food:\n-------------------------");

            line = new StringBuilder("                                              ");
            line.Insert(1, "ITEM");
            line.Insert(16, "QTY");
            line.Insert(20, "HLTH");
            line.Insert(25, "HNGR");
            Console.WriteLine(line);

            foreach (var foodItem in foodItems)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, foodItem.InventoryItem.Name);
                line.Insert(16, foodItem.Quantity);
                line.Insert(20, ((Food)foodItem.InventoryItem).HealingPower);
                line.Insert(25, ((Food)foodItem.InventoryItem).FillingPower);
                Console.WriteLine(line);
            }

            Continue();
        }

        private void ViewResources()
        {
            StringBuilder line;
            var inventory = Shipwreck.CurrentGame?.Player.Inventory;
            var resources = InventoryController.GetItemsByType<Resource>(inventory);

            Console.WriteLine("\n-------------------------\n Resources:\n-------------------------");

            line = new StringBuilder("                                              ");
            line.Insert(1, "ITEM");
            line.Insert(16, "QTY");
            line.Insert(20, "DESC");
            Console.WriteLine(line);

            foreach (var resource in resources)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, resource.InventoryItem.Name);
                line.Insert(16, resource.Quantity);
                line.Insert(20, (resource.InventoryItem).Description);
                Console.WriteLine(line);
            }

            Continue();
        }

        private bool EatFood()
        { 
            var closeView = false;
            var player = Shipwreck.CurrentGame.Player;
            var inventory = player.Inventory;
            var itemToEat = GetInventoryItem("Which item would you like to eat?");
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
                    GameController.LoseGame();
                    closeView = true;
                }
            }
            else
            {
                Console.WriteLine($"That is not an item that exists in your inventory");
            }

            Continue();

            return closeView;
        }

        private void EquipGear()
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            var itemToEquip = GetInventoryItem("Which item would you like to equip?");
            if (itemToEquip != null)
            {
                if (itemToEquip.GetType().IsSubclassOf(typeof(Weapon)))
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

            Continue();
        }

        private void DropItem()
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            var itemToDrop = GetInventoryItem("Which item would you like to drop?");
            if (itemToDrop != null)
            {
                Console.WriteLine("how many would you like to drop?");
                var sQuantity = Console.ReadLine();
                int.TryParse(sQuantity, out var quantity);

                try
                {
                    var numDropped = inventory.DropItem(itemToDrop, quantity);
                    Console.WriteLine($"You dropped {numDropped} {itemToDrop.Name}(s)");
                }
                catch(InventoryException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine($"That is not an item that exists in your inventory");
            }

            Continue();
        }

        private void BuildWeapon()
        {
            var inventory = Shipwreck.CurrentGame?.Player.Inventory;
            string itemToBuild;

            Console.WriteLine("Which Weapon would you like to build?");
            itemToBuild = Console.ReadLine();

            try
            {
                InventoryController.BuildWeapon(inventory, itemToBuild);
                Console.WriteLine($"Successfully built 1 {itemToBuild}");
                Continue();
            }
            catch(InventoryException e)
            {
                Console.WriteLine(e.Message);
                Continue();
            }
        }

        private void ShowInventoryHelpView()
        {
            var inventoryHelpView = new InventoryHelpView(InGameView);
            inventoryHelpView.Display();
        }

        private IItem GetInventoryItem(string message)
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            Console.WriteLine(message);
            var itemName = Console.ReadLine();

            return InventoryController.GetItemFromInventory(inventory, itemName);
        }
    }
}
