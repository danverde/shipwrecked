using System;
using System.Collections.Generic;
using Sharprompt;
using Sharprompt.Validations;
using Shipwreck.Control;
using Shipwreck.Helpers;
using Shipwreck.Model.Views;

namespace Shipwreck.View
{
    class MainMenuView : MenuView
    {
        public override bool InGameView => false;
        protected override string Title => "Main Menu";

        protected override List<MenuItem> MenuItems => new List<MenuItem>
        {
            new MenuItem
            {
                DisplayName = "New Game",
                Type = MenuItemType.NewGame
            },
            new MenuItem
            {
                DisplayName = "Load Game",
                Type = MenuItemType.LoadGame
            },
            new MenuItem
            {
                DisplayName = "Help Menu",
                Type = MenuItemType.HelpMenu
            },
            new MenuItem
            {
                DisplayName = "Close Shipwreck",
                Type = MenuItemType.Close
            },
        };
        
        public static string GetPlayerName()
        {
            return Prompt.Input<string>("Please Enter Your Character's Name", null, new[] {Validators.Required()});
        }

        protected override bool HandleInput(MenuItem menuItem)
        {
            switch (menuItem.Type) 
            {
                case MenuItemType.NewGame:
                    StartNewGame();
                    break;
                case MenuItemType.LoadGame:
                    LoadGame();
                    break;
                case MenuItemType.HelpMenu:
                    new HelpMenuView().Display();
                    break;
            }

            return false;
        }

        private void StartNewGame()
        {
            ShipwreckController.SetupNewGame();
        }

        private void LoadGame()
        {
            // list available save files
            var existingFiles = ShipwreckController.GetExistingSaveFileNames();
            if (existingFiles.Count == 0)
            {
                Console.WriteLine("There are no saved games");
                ViewHelpers.Continue();
                return;
            }
            
            existingFiles.Add("Exit");
            
            var fileToLoad = Prompt.Select("Which game would you like to load?", existingFiles);
            if (fileToLoad == "Exit") return;
            fileToLoad = FileHelper.AddExtension(fileToLoad, ".json");
            
            // try load file
            if (ShipwreckController.TryLoadGame(fileToLoad, out var game))
            {
               ShipwreckController.StartGame(game);
            }
            else
            {
                Console.WriteLine($"Unable to load {fileToLoad}");
            }
        }
    }
}
