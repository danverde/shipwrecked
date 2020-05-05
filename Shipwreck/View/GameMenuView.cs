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
                case "W":
                    WaitItOut();
                    done = true;
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

        private void WaitItOut()
        {
            // I think this is looping even when it should be done
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
