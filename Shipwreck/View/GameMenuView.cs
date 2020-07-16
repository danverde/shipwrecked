using System;

namespace Shipwreck.View
{
    class GameMenuView : View
    {
        public GameMenuView()
        {
            ParentView = new MainMenuView();
            Message = "\n"
                      + "\n----------------------------------"
                      + "\n| Game Menu"
                      + "\n----------------------------------"
                      + "\n C - View Character"
                      + "\n I - View Inventory"
                      + "\n W - Wait for rescue"
                      + "\n F - Tend Signal Fire"
                      + "\n H - Help Menu"
                      + "\n X - End it all (Exit Game)"
                      + "\n----------------------------------";
        }

        public static void ShowPlayerStats()
        {
            var player = Shipwreck.CurrentGame.Player;

            Console.WriteLine("\n-------------------------\n Character Stats:");
            Console.WriteLine($" Name: {player.Name}");
            Console.WriteLine($" level: {player.Level}");
            Console.WriteLine($" Exp: {player.Exp} / 100");
            Console.WriteLine($" Heath: {player.Health} / {player.MaxHealth}");
            Console.WriteLine($" Hunger: {player.Hunger}");
            Console.WriteLine($" Base Attack: {player.BaseAttack}");
            Console.WriteLine($" Base Defense: {player.BaseDefense}");
            Console.WriteLine("-------------------------");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            // Console.SetCursorPosition(0, Console.CursorTop - 1);
            // Console.Write(new string(' ', Console.WindowWidth));
        }

        protected override bool HandleInput(string input)
        {
            input = input.ToUpper();
            var closeView = false;
            switch(input)
            {
                case "C":
                    ShowPlayerStats();
                    break;
                case "I":
                    closeView = ShowInventory();
                    break;
                case "W":
                    closeView = WaitItOut();
                    break;
                case "F":
                    OpenFireMenu();
                    break;
                case "H":
                    OpenHelpView();
                    break;
            }
            return closeView;
        }

        private bool ShowInventory()
        {
            new InventoryMenuView().Display();
            
            // TODO I don't think I need this logic anymore!
            return Shipwreck.CurrentGame == null ? true : false;
        }

        private bool WaitItOut()
        {
            var waitView = new WaitView();
            waitView.Display();

            // TODO I don't think I need this logic anymore!
            return Shipwreck.CurrentGame == null ? true: false;
        }

        private void OpenFireMenu()
        {
            var fireMenuView = new FireMenuView();
            fireMenuView.Display();
        }

        private void OpenHelpView()
        {
            var helpMenuView = new HelpMenuView(new GameMenuView());
            helpMenuView.Display();
        }
    }
}
