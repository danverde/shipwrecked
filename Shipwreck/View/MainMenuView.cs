using Shipwreck.Control;
using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class MainMenuView : View
    {
        public MainMenuView()
            :base("\n\n----------------------------------"
                  + "\n| Main Menu"
                  + "\n----------------------------------"
                  + "\n N - New Game"
                  + "\n S - Save Game"
                  + "\n C - Continue Game"
                  + "\n H - Help Menu"
                  + "\n X - Close Shipwreck"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string menuOption)
        {
            menuOption = menuOption.ToUpper();

            switch (menuOption) 
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
            NewGameView newGameView = new NewGameView();
            newGameView.Display();
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
            HelpMenuView helpMenuView = new HelpMenuView();
            helpMenuView.Display();
        }
    }
}
