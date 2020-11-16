using System;
using Shipwreck.Model.Game;

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
                      + "\n S - Save Game"
                      + "\n C - Continue Game"
                      + "\n H - Help Menu"
                      + "\n X - Close Shipwreck"
                      + "\n----------------------------------";
        }

        protected override bool HandleInput(string input)
        {
            switch (input) 
            {
                case "N":
                    StartNewGame();
                    break;
                case "S":
                    SaveGame();
                    break;
                case "C":
                    ContinueGame();
                    break;
                case "H":
                    OpenHelpView();
                    break;
            }

            return false;
        }

        private void StartNewGame()
        {
            Shipwreck.CurrentGame = new Game();
            new NewGameView().Display();
        }

        private void SaveGame()
        {
            throw new NotImplementedException();
        }

        private void ContinueGame()
        {
            throw new NotImplementedException();
        }

        private void OpenHelpView()
        {
            new HelpMenuView().Display();
        }
    }
}
