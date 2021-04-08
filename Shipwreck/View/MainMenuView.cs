using System;
using Sharprompt;
using Shipwreck.Control;
using Shipwreck.Helpers;

namespace Shipwreck.View
{
    class MainMenuView : View
    {
        public MainMenuView()
        {
            InGameView = false;
            Message = "\n\n----------------------------------"
                      + "\n| Main Menu"
                      + "\n----------------------------------"
                      + "\n N - New Game"
                      + "\n L - Load Game"
                      + "\n H - Help Menu"
                      + "\n X - Close Shipwreck"
                      + "\n----------------------------------";
        }


        public static string GetPlayerName()
        {
            Console.WriteLine("\nPlease Enter Your Character's Name:\n");
            var name = Console.ReadLine() ?? "";
            
            return string.IsNullOrEmpty(name) ? GetPlayerName() : name;
        }

        protected override bool HandleInput(string input)
        {
            switch (input) 
            {
                case "N":
                    StartNewGame();
                    break;
                case "L":
                    LoadGame();
                    break;
                case "H":
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
                Continue();
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
