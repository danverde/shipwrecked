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
                case "H":
                    OpenHelpView();
                    break;
            }
            return false;
        }

        private void ShowPlayerStats()
        {
            Player player = Shipwreck.currentGame.Player;
            Console.WriteLine("\nCharacter Stats:"
                + $"\nName:{player.Name}"
                + $"\nHealth:{player.Health}"
                + "\n------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private void OpenHelpView()
        {
            HelpMenuView helpMenuView = new HelpMenuView();
            helpMenuView.Display();
        }
    }
}
