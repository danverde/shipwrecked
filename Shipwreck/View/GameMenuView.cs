using System;
using System.Collections.Generic;
using System.Text;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Model.Character;
using Shipwreck.Model.Views;

namespace Shipwreck.View
{
    class GameMenuView : MenuView
    {
        protected override string Title => "Game Menu";
        
        // TODO menu items could be stored on a global list & pulled in as a view is created?
        // TODO inefficient...
        protected override List<MenuItem> MenuItems => new List<MenuItem>
        {
            new MenuItem
            {
                DisplayName = "C - View Character",
                Character = 'C'
            },
            new MenuItem
            {
                DisplayName = "I - View Inventory",
                Character = 'I'
            },
            new MenuItem
            {
                DisplayName = "M - View Map",
                Character = 'M'
            },
            new MenuItem
            {
                DisplayName = "L - Move",
                Character = 'M'
            },
            new MenuItem
            {
                DisplayName = "E - Explore",
                Character = 'E',
                IsActive  = () => false
            },
            new MenuItem
            {
                DisplayName = "W - Wait for rescue",
                Character = 'W'
            },
            new MenuItem
            {
                DisplayName = "S - Save Game",
                Character = 'S'
            },
            new MenuItem
            {
                DisplayName = "H - Help",
                Character = 'H'
            },
            new MenuItem
            {
                DisplayName = "X - End Game",
                Character = 'X'
            },
        };

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
                var playerLocation = MapController.GetPlayerLocation();
                
                for (var colIndex = 0; colIndex < map.NumCols; colIndex++)
                {
                    var location = map.Locations[rowIndex, colIndex];
                    var displaySymbol = location.Scene.DisplaySymbol;
                    if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !location.Visited) displaySymbol = " ? ";
                    
                    if (playerLocation == location) displaySymbol = $"X{displaySymbol.Trim()} ";
                        
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

        protected override bool HandleInput(MenuItem menuItem)
        {
            const bool closeView = false;

            if (!menuItem.IsActive()) return closeView;
            
            switch(menuItem.Character)
            {
                case 'C':
                    ShowPlayerStats();
                    Continue();
                    break;
                case 'I':
                    new InventoryMenuView().Display();
                    break;
                case 'M':
                    ShowMap();
                    Continue();
                    break;
                case 'L':
                    ShowMap();
                    Console.WriteLine();
                    new MoveView().Display();
                    break;
                case 'E':
                    ExploreArea();
                    ShowMap();
                    Continue();
                    break;
                case 'W':
                    new WaitView().Display();
                    break;
                case 'F':
                    new FireMenuView().Display();
                    break;
                case 'S':
                    SaveGame();
                    Continue();
                    break;
                case 'H':
                    // new HelpMenuView(InGameView).Display();
                    var helpMenu = new HelpMenuView
                    {
                        InGameView = InGameView
                    };
                    helpMenu.Display();
                    break;
                case 'X':
                    GameController.QuitGame();
                    return true;
            }
            return closeView;
        }
        
        private void ExploreArea()
        {
            var map = Shipwreck.CurrentGame.Map;
            var currentLocation = MapController.GetPlayerLocation();
            if (!MapController.TryExploreAdjacentLocations(map, currentLocation)) return;
            
            Console.WriteLine("\nYou begin searching the nearby area as the sun starts to fade into the horizon");
            Console.ReadLine();
            GameController.AdvanceDays(1);
            Console.WriteLine("After a day of exploration, adjacent locations on the map are now visible!");
        }
        
        private void SaveGame()
        {
            string fileName;
            
            if (string.IsNullOrEmpty(Shipwreck.CurrentGame.SaveFileName))
            {
                fileName = Prompt.Input<string>("File name");
                if (fileName == "x" || fileName == "X") return;
            }
            else
            {
                fileName = Shipwreck.CurrentGame.SaveFileName;
            }

            var success = ShipwreckController.TrySaveGame(fileName);
            
            Console.WriteLine(success
                ? "Your game was successfully saved"
                : "There was an error while trying to save your game");
        }
    }
}
