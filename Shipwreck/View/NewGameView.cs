using Shipwreck.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class NewGameView : View
    {
        public NewGameView()
            :base("\nPlease Enter Your Character's Name:\n")
            {}

        public override bool DoAction(string value)
        {
            GameController.CreateNewGame(value);
            GameMenuView gameMenuView = new GameMenuView();
            gameMenuView.Display();
            return true;
        }
    }
}
