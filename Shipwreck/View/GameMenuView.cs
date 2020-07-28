using System;
using Shipwreck.Control;

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

        protected override string GetInput()
        {
            // get input
            var input = Console.ReadLine();

            // format input 
            input = FormatInput(input);

            input = input == "X" ? "QUIT" : input;
            
            return input;
        }
        
        protected override bool HandleInput(string input)
        {
            var closeView = false;
            switch(input)
            {
                case "C":
                    ShowPlayerStats();
                    break;
                case "I":
                    // closeView = ShowInventory();
                    ShowInventory();
                    break;
                case "W":
                    WaitItOut();
                    break;
                case "F":
                    OpenFireMenu();
                    break;
                case "H":
                    OpenHelpView();
                    break;
                case "QUIT":
                    GameController.QuitGame();
                    closeView = true;
                    break;
            }
            return closeView;
        }

        private void ShowInventory()
        {
            new InventoryMenuView().Display();
            
            // TODO I don't think I need this logic anymore!
            // return Shipwreck.CurrentGame == null ? true : false;
        }

        private void WaitItOut()
        {
            new WaitView().Display();

            // TODO I don't think I need this logic anymore!
            // return Shipwreck.CurrentGame == null ? true: false;
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
