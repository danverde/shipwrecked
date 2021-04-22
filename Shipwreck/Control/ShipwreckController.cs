using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
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

        public static void SetupNewGame()
        {
            // get character name
            var playerName = MainMenuView.GetPlayerName();
            
            var game = new Game();
            
            // setup map
            var map = MapController.LoadMapFromJson(game.GameSettings.Map.MapPath);
            var startingLocation = map.Locations[map.StartingRow, map.StartingCol];
            if (game.GameSettings.Map.EnableFow)
            {
                MapController.TryExploreAdjacentLocations(map, startingLocation);
            }
            
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
            AddDefaultItemsToInventory(player.Inventory);
            
            // setup game
            game.Player = player;
            game.Status = Game.GameStatus.Playing;
            game.Fire = new Fire();
            game.Day = new Day();
            game.Map = map;

            StartGame(game);
        }
        
        public static List<string> GetExistingSaveFileNames()
        {
            return FileHelper.GetFilesInDir(Shipwreck.Settings.SavePath);
        }

        public static bool TrySaveGame(string fileName)
        {
            if (string.IsNullOrEmpty(fileName)) return false;
            
            try
            {
                // add extension
                fileName = FileHelper.AddExtension(fileName, ".json");
                
                // save filename to game
                Shipwreck.CurrentGame.SaveFileName = fileName;
                
                // write the file
                var gameString = JsonConvert.SerializeObject(Shipwreck.CurrentGame);
                var filePath =  Path.Combine(Shipwreck.Settings.SavePath, fileName);
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
        
        private static void AddDefaultItemsToInventory(Inventory inventory)
        {
            // var weaponFactory = Shipwreck.WeaponFactory;
            // var armorFactory = Shipwreck.ArmorFactory;
            var foodFactory = Shipwreck.FoodFactory;
            // var resourceFactory = Shipwreck.ResourceFactory;
                                 
            // var spear = weaponFactory.GetWeapon(WeaponType.Spear);
            // var fists = weaponFactory.GetWeapon(WeaponType.Fists);
            //
            // var suit = armorFactory.GetArmor(ArmorType.Suit);
            
            // var fish = foodFactory.GetFood(FoodType.Fish);
            var meat = foodFactory.GetFood(FoodType.Meat);

            // var match = resourceFactory.GetResource(ResourceType.Match);
            // var vine = resourceFactory.GetResource(ResourceType.Vine);
            // var branch = resourceFactory.GetResource(ResourceType.Branch);

            // inventory.AddItem(fists);
            // inventory.AddItem(spear);
            // inventory.AddItem(suit);
            // inventory.ActiveArmor = suit;
            // inventory.ActiveWeapon = fists;

            // inventory.AddItem(fish, 3);
            InventoryController.AddItem(inventory, meat, 10);
            
            // inventory.AddItem(match, 3);
            // inventory.AddItem(vine, 6);
            // inventory.AddItem(branch, 3);
        }
    }
}