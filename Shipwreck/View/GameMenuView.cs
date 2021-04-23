using System;
using System.Collections.Generic;
using System.Text;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Helpers;
using Shipwreck.Model.Game;
using Shipwreck.Model.Views;

namespace Shipwreck.View
{
    class GameMenuView : MenuView
    {
        public override bool InGameView => true;
        protected override string Title => "Game Menu";
        
        // setup as a singleton & inject via startup file
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
                IsActive  = () => Shipwreck.CurrentGame.GameSettings.Map.EnableFow
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
                DisplayName = "Close Game",
                Type = MenuItemType.Close
            }
        };

        public static void ShowPlayerStats()
        {
            var player = Shipwreck.CurrentGame.Player;

            Console.WriteLine("\n-------------------------\n Character Stats:");
            Console.WriteLine($" Name: {player.Name}");
            // Console.WriteLine($" level: {player.Level}");
            // Console.WriteLine($" Exp: {player.Exp} / 100");
            // Console.WriteLine($" Heath: {player.Health} / {player.MaxHealth}");
            Console.WriteLine($" Hunger: {player.Hunger} / {player.HungerLimit}");
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
                    Move();
                    if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return true;
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.Explore:
                    ExploreArea();
                    if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return true;
                    ShowMap();
                    ViewHelpers.Continue();
                    break;
                case MenuItemType.Wait:
                    Wait();
                    if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return true;
                    ViewHelpers.Continue();
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

        private static void ShowMap()
        {
            var map = Shipwreck.CurrentGame.Map;
            
            Console.WriteLine("\n--------------- Map ---------------\n");
            
            for (var rowIndex = 0; rowIndex < map.NumRows; rowIndex++)
            {
                var line = new StringBuilder("                             ");
                var playerLocation = MapController.GetCharacterLocation(Shipwreck.CurrentGame.Player);
                
                for (var colIndex = 0; colIndex < map.NumCols; colIndex++)
                {
                    var location = map.Locations[rowIndex, colIndex];
                    var displaySymbol = location.Scene.DisplaySymbol;
                    if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !location.Explored) displaySymbol = " ? ";
                    
                    if (playerLocation == location) displaySymbol = $"X{displaySymbol.Trim()} ";
                        
                    var lineLocation = colIndex * 4 + 1;
                    line.Insert(lineLocation, displaySymbol);
                }
                
                Console.WriteLine(line);
            }
            
            Console.WriteLine("\n-----------------------------------");
        }
        
        private void Move()
        {
            var player = Shipwreck.CurrentGame.Player;
            var validDirections = MapController.GetValidMovableDirections(Shipwreck.CurrentGame.Map, player);
            var direction = Prompt.Select("Which direction would you like to travel?", validDirections);
            
            var newCoordinate = MapController.GetAdjacentCoordinates(MapController.GetCharacterLocation(player), Shipwreck.CurrentGame.Map)
                .Find(coordinate => coordinate.Direction == direction);
            if (newCoordinate == null) return;
            
            var newLocationVisited = Shipwreck.CurrentGame.Map.Locations[newCoordinate.Row, newCoordinate.Col].Explored;
            
            var success = MapController.TryMove(Shipwreck.CurrentGame.Map, Shipwreck.CurrentGame.Player, direction, out var location);
            // check if the game ended (found town or ran out of hunger) 
            if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return;
            
            ShowMap();
            
            if (success)
            {
                var successMsg = $"You successfully moved moved {direction.ToString()}";
                // TODO give more details about the new location?
                if (Shipwreck.CurrentGame.GameSettings.Map.EnableFow && !newLocationVisited) successMsg += $" and discovered {location.Scene.Description}";
                
                Log.Success(successMsg);
            }
            else
            {
                Log.Warning($"You were unable to move {direction.ToString()}");
            }
        }
        
        private void ExploreArea()
        {
            var map = Shipwreck.CurrentGame.Map;
            var currentLocation = MapController.GetCharacterLocation(Shipwreck.CurrentGame.Player);
            if (!MapController.TryExploreAdjacentLocations(map, currentLocation)) return;
            
            Console.WriteLine("\nAs you search the nearby area the sun begins to fade into the horizon...");
            Console.ReadKey();
            
            GameController.AdvanceDays(1);
            if (Shipwreck.CurrentGame.Status != Game.GameStatus.Playing) return;

            Log.Success("After a day of exploration, nearby locations are now visible on the map!");
        }
        
        private void SaveGame()
        {
            // get filename
            var fileName = Prompt.Input<string>("File Name", Shipwreck.CurrentGame.SaveFileName);

            // validate filename
            if (string.IsNullOrEmpty(fileName)) return;
            if (!FileHelper.ValidFileName(fileName))
            {
                Console.WriteLine("Invalid file name");
                return;
            }
            
            // check for duplicates & ask to override
            var fileExists = FileHelper.FileExists(Shipwreck.Settings.SavePath, fileName);
            if (fileExists)
            {
                var overwrite = fileName == Shipwreck.CurrentGame.SaveFileName ||
                                Prompt.Confirm($"{fileName} already exists. Would you like to overwrite it?", true);
                if (!overwrite) return;
            }
            
            // save file
            var success = ShipwreckController.TrySaveGame(fileName);
            if (success)
            {
                Log.Success("Your game was successfully saved");
            }
            else
            {
                Log.Warning("The game was not saved");
            }
        }

        private void Wait()
        {
            var numDays = Prompt.Input<int>("How many days would you like to wait for?", 0, new[] {CustomValidators.IsGreaterOrEqualTo(0)});
            if (numDays == 0) return;
            
            GameController.AdvanceDays(numDays, true);
        }
    }
}
