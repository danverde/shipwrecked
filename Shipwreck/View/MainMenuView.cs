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
                default:
                    // might not do what I think it does
                    return true;
            }

            // not sure why this returns a boolean...
            return false;
        }

        private void StartNewGame()
        {
            // ideally I get the character name in the view...
            // maybe create a createCharacter view?
            // Shipwreck.currentGame = new Game();
            NewGameView newGameView = new NewGameView();
            newGameView.Display();
            // GameController.CreateNewGame();
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
