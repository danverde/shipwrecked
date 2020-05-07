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

        public static void ShowPlayerStats()
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

        private void ShowInventory()
        {
            Shipwreck.InventoryView.Display();
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
