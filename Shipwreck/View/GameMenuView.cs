using System;
using System.Text;
using Shipwreck.Control;
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
                      + "\n L - Move"
                      + "\n W - Wait for rescue"
                      // + "\n F - Tend Signal Fire"
                      + "\n S - Save Game"
                      + "\n H - Help Menu"
                      + "\n X - End it all (Exit Game)"
                      + "\n----------------------------------";
        }

        public static bool OverwriteFileName(string fileName)
        {
            Console.WriteLine($"{fileName} already exists. Would you like to overwrite it? (Y/n)");
            var input = Console.ReadLine() ?? "n";
            return input == "y" || input.ToUpper() == "Y";
        }

        public static void ShowMap()
        {
            var map = Shipwreck.CurrentGame.Map;
            
            Console.WriteLine("\n--------------- Map ---------------\n");
            
            for (var rowIndex = 0; rowIndex < map.NumRows; rowIndex++)
            {
                var line = new StringBuilder("                             ");
                
                for (var colIndex = 0; colIndex < map.NumCols; colIndex++)
                {
                    var location = map.Locations[rowIndex, colIndex];
                    var displaySymbol = location.Scene.DisplaySymbol;
                    if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !location.Visited) displaySymbol = " ? ";
                    
                    if (MapController.GetPlayerLocation() == location) displaySymbol = " X ";
                        
                    var lineLocation = colIndex * 4 + 1;
                    line.Insert(lineLocation, displaySymbol);
                }
                
                Console.WriteLine(line);
            }
            
            Console.WriteLine("\n-----------------------------------");
        }
        
        public static void ShowPlayerStats()
        {
            var player = Shipwreck.CurrentGame.Player;

            Console.WriteLine("\n-------------------------\n Character Stats:");
            Console.WriteLine($" Name: {player.Name}");
            // Console.WriteLine($" level: {player.Level}");
            // Console.WriteLine($" Exp: {player.Exp} / 100");
            // Console.WriteLine($" Heath: {player.Health} / {player.MaxHealth}");
            Console.WriteLine($" Hunger: {player.Hunger} / {Player.HungerLimit}");
            // Console.WriteLine($" Base Attack: {player.BaseAttack}");
            // Console.WriteLine($" Base Defense: {player.BaseDefense}");
            Console.WriteLine("-------------------------");

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
                    Continue();
                    break;
                case "I":
                    new InventoryMenuView().Display();
                    break;
                case "M":
                    ShowMap();
                    Continue();
                    break;
                case "L":
                    new MoveView().Display();
                    break;
                case "W":
                    new WaitView().Display();
                    break;
                case "F":
                    new FireMenuView().Display();
                    break;
                case "S":
                    SaveGame();
                    break;
                case "H":
                    new HelpMenuView(InGameView).Display();
                    break;
                case "QUIT":
                    GameController.QuitGame();
                    closeView = true;
                    break;
            }
            return closeView;
        }
        
        private void SaveGame()
        {
            Console.WriteLine("File name:");
            var fileName = Console.ReadLine() ?? "";

            if (fileName == "x" || fileName == "X") return;

            var success = ShipwreckController.TrySaveGame(fileName);

            Console.WriteLine(success
                ? "Your game was successfully saved"
                : "There was an error while trying to save your game");
            
            Continue();
        }
    }
}
