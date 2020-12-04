using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Shipwreck.Control.Interfaces;
using Shipwreck.Helpers;
using Shipwreck.Model;
using Shipwreck.Model.Character;
using Shipwreck.Model.Game;
using Shipwreck.Model.Items;
using Shipwreck.View;

namespace Shipwreck.Control
{
    public static class ShipwreckController
    {
        public static void StartGame(Game game)
        {
            Shipwreck.CurrentGame = game;
            
            new ShowDayView().Display();
            new GameMenuView().Display();
        }

        public static void StartNewGame()
        {
            // get character name
            var playerName = MainMenuView.GetPlayerName();
            
            var game = new Game();
            
            // setup map
            var map = MapController.LoadMapFromJson(game.GameSettings.Map.MapPath);
            var startingLocation = map.Locations[map.StartingRow, map.StartingCol];
            
            // setup player
            var player = new Player
            {
                Name = playerName,
                Hunger = game.GameSettings.Player.InitialHunger,
                Row = startingLocation.Row,
                Col = startingLocation.Col,
                Inventory = new Inventory
                {
                    Items = new List<InventoryRecord>()
                }
            };
            startingLocation.Characters.Add(player);
            InventoryController.AddDefaultItemsToInventory(player.Inventory);
            
            // setup game
            game.Player = player;
            game.Status = GameStatus.Playing;
            game.Fire = new Fire();
            game.Day = new Day();
            game.Map = map;

            StartGame(game);
        }

        public static bool TrySaveGame(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName)) return false;
                
                var savePath = Shipwreck.Settings.SavePath;
            
                // validate name & extension
                fileName = FileHelper.AddExtension(fileName, ".json");
            
                // check for existing file & ask to override
                var fileExists = FileHelper.FileExists(savePath, fileName);
                if (fileExists)
                {
                    var overwrite = GameMenuView.OverwriteFileName(fileName);
                    if (!overwrite) return false;
                }

                // write the file
                var gameString = JsonConvert.SerializeObject(Shipwreck.CurrentGame);
                var filePath =  Path.Combine(savePath, fileName);
                File.WriteAllText(filePath, gameString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public static bool TryLoadGame(string fileName, out Game game)
        {
            game = null;
            try
            {
                var filePath = Path.Combine(Shipwreck.Settings.SavePath, fileName);
                game = FileHelper.LoadJson<Game>(filePath);
                Shipwreck.CurrentGame = game;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}