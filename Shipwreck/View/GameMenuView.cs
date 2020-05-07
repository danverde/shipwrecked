using Shipwreck.Control;
using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class GameMenuView : View
    {
        public GameMenuView()
            : base("\n"
                  + "\n----------------------------------"
                  + "\n| Game Menu"
                  + "\n----------------------------------"
                  + "\n C - View Character"
                  + "\n I - View Inventory"
                  + "\n W - Wait for rescue"
                  + "\n H - Help Menu"
                  + "\n X - End it all (Exit Game)"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            value = value.ToUpper();
            bool done = false;
            switch(value)
            {
                case "C":
                    ShowPlayerStats();
                    break;
                case "I":
                    ShowInventory();
                    break;
                case "W":
                    done = WaitItOut();
                    break;
                case "H":
                    OpenHelpView();
                    break;
            }
            return done;
        }

        private void ShowPlayerStats()
        {
            Player player = Shipwreck.CurrentGame.Player;

            Console.WriteLine("\n-------------------------\n Character Stats:");
            Console.WriteLine($" Name: {player.Name}");
            Console.WriteLine($" Heath: {player.Health}");
            Console.WriteLine($" Hunger: {player.Hunger}");
            Console.WriteLine($" Base Attack: {player.BaseAttack}");
            Console.WriteLine($" Base Defense: {player.BaseDefense}");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            // Console.SetCursorPosition(0, Console.CursorTop - 1);
            // Console.Write(new string(' ', Console.WindowWidth));
        }

        private void ShowInventory()
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

            foreach (Item item in inventory.Items)
            {
                line = new StringBuilder("                                              ");
                line.Insert(1, item.Name);
                line.Insert(16, item.Quantity);
                line.Insert(20, item.Description);
                Console.WriteLine(line);
            }
            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private bool WaitItOut()
        {
            WaitView waitView = new WaitView();
            waitView.Display();

            return Shipwreck.CurrentGame == null ? true: false;
        }

        private void OpenHelpView()
        {
            HelpMenuView helpMenuView = new HelpMenuView();
            helpMenuView.Display();
        }
    }
}
