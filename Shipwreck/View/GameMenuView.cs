using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Shipwreck.Control;
using Shipwreck.Model;
using Shipwreck.Model.Character;

namespace Shipwreck.View
{
    class GameMenuView : View
    {
        public GameMenuView()
        {
            InGameView = true;
            Message = "\n"
                      + "\n----------------------------------"
                      + "\n| Game Menu"
                      + "\n----------------------------------"
                      + "\n C - View Character"
                      + "\n I - View Inventory"
                      + "\n M - View Map"
                      + "\n W - Wait for rescue"
                      + "\n F - Tend Signal Fire"
                      + "\n H - Help Menu"
                      + "\n X - End it all (Exit Game)"
                      + "\n----------------------------------";
        }

        public void ShowPlayerStats()
        {
            var player = Shipwreck.CurrentGame.Player;

            Console.WriteLine("\n-------------------------\n Character Stats:");
            Console.WriteLine($" Name: {player.Name}");
            Console.WriteLine($" level: {player.Level}");
            Console.WriteLine($" Exp: {player.Exp} / 100");
            Console.WriteLine($" Heath: {player.Health} / {player.MaxHealth}");
            Console.WriteLine($" Hunger: {player.Hunger} / {Player.HungerLimit}");
            Console.WriteLine($" Base Attack: {player.BaseAttack}");
            Console.WriteLine($" Base Defense: {player.BaseDefense}");
            Console.WriteLine("-------------------------");

            Continue();
            
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
                    ShowInventory();
                    break;
                case "M":
                    ShowMap();
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
        }

        private void ShowMap()
        {
            // var mapJson = JsonConvert.SerializeObject(Shipwreck.CurrentGame.Map); 
            // Console.WriteLine(mapJson);
            
            var map = Shipwreck.CurrentGame.Map;
            
            Console.WriteLine("\n----------------Map----------------");
            
            for (var rowIndex = 0; rowIndex < map.NumRows; rowIndex++)
            {
                var row = "";
                
                for (var colIndex = 0; colIndex < map.NumCols; colIndex++)
                {
                    var location = map.Locations[rowIndex, colIndex];
                    var displaySymbol = location.Scene.DisplaySymbol;
                    if (Shipwreck.CurrentGame.Settings.EnableFOW && !location.Visited) displaySymbol = "?";
                    
                    if (Shipwreck.CurrentGame.Player.CurrentLocation == location) displaySymbol = "X";
                        
                    row += $" {displaySymbol}";
                }
                
                Console.WriteLine(row);
            }
            
            Console.WriteLine("\n-----------------------------------");
            Continue();
        }

        private void WaitItOut()
        {
            new WaitView().Display();
        }

        private void OpenFireMenu()
        {
            var fireMenuView = new FireMenuView();
            fireMenuView.Display();
        }

        private void OpenHelpView()
        {
            var helpMenuView = new HelpMenuView(InGameView);
            helpMenuView.Display();
        }
    }
}
