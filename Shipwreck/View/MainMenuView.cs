using System;

namespace Shipwreck.View
{
    class MainMenuView : View
    {
        public MainMenuView()
        {
            // TODO breaks when closing b/c there's no parent view
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
            new HelpMenuView(new MainMenuView()).Display();
        }
    }
}
