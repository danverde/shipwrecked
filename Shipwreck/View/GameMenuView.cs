using System;
using System.Collections.Generic;
using System.Text;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Helpers;
using Shipwreck.Model.Character;
using Shipwreck.Model.Views;

namespace Shipwreck.View
{
    class GameMenuView : MenuView
    {
        protected override string Title => "Game Menu";
        
        protected override List<MenuItem> MenuItems => new List<MenuItem>
        {
            new MenuItem
            {
                DisplayName = "View Character",
                Type = MenuItemType.ViewCharacter
            },
            new MenuItem
            {
                DisplayName = "View Inventory",
                Type = MenuItemType.ViewInventory
            },
            new MenuItem
            {
                DisplayName = "View Map",
                Type = MenuItemType.ViewMap
            },
            new MenuItem
            {
                DisplayName = "Move",
                Type = MenuItemType.Move
            },
            new MenuItem
            {
                DisplayName = "Explore",
                Type = MenuItemType.Explore,
                IsActive  = () => false
            },
            new MenuItem
            {
                DisplayName = "Wait for rescue",
                Type = MenuItemType.Wait
            },
            new MenuItem
            {
                DisplayName = "Save Game",
                Type = MenuItemType.SaveGame
            },
            new MenuItem
            {
                DisplayName = "Help",
                Type = MenuItemType.HelpMenu
            },
            new MenuItem
            {
                DisplayName = "Close",
                Type = MenuItemType.Close
            }
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

            switch(menuItem.Type)
            {
                case MenuItemType.ViewCharacter:
                    ShowPlayerStats();
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.ViewInventory:
                    new InventoryMenuView().Display();
                    break;
                case MenuItemType.ViewMap:
                    ShowMap();
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.Move:
                    ShowMap();
                    Console.WriteLine();
                    new MoveView().Display();
                    break;
                case MenuItemType.Explore:
                    ExploreArea();
                    ShowMap();
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.Wait:
                    new WaitView().Display();
                    break;
                // case 'F':
                //     new FireMenuView().Display();
                //     break;
                case MenuItemType.SaveGame:
                    SaveGame();
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.HelpMenu:
                    var helpMenu = new HelpMenuView
                    {
                        InGameView = InGameView
                    };
                    helpMenu.Display();
                    break;
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
