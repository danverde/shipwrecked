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
                  + "\nC - View Character"
                  + "\nS - Starve to death"
                  + "\nX - End it all (Exit Game)"
                  + "\nH - Help Menu"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            value = value.ToUpper();
            switch(value)
            {
                case "C":
                    ShowPlayerStats();
                    break;
                case "S":
                    StarveToDeath();
                    break;
                case "H":
                    OpenHelpView();
                    break;
            }
            return false;
        }

        private void ShowPlayerStats()
        {
            Player player = Shipwreck.CurrentGame.Player;
            Console.WriteLine("Character Stats:");
            Console.WriteLine($"Name: {player.Name}");
            Console.WriteLine($"Heath: {player.Health}");
            Console.WriteLine($"Hunger: {player.Hunger}");
            Console.WriteLine($"Attack: {player.Attack}");
            Console.WriteLine($"Defense: {player.Defense}");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            // Console.SetCursorPosition(0, Console.CursorTop - 1);
            // Console.Write(new string(' ', Console.WindowWidth));
        }

        private void StarveToDeath()
        {
            while (Shipwreck.CurrentGame != null)
            {
                GameController.AdvanceDay();
            }
        }

        private void OpenHelpView()
        {
            HelpMenuView helpMenuView = new HelpMenuView();
            helpMenuView.Display();
        }
    }
}
