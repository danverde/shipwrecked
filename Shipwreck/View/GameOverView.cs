using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class GameOverView : View
    {
        public GameOverView()
            :base("You Died. Sucks to suck", true)
        {}
        public override bool DoAction(string value)
        {
            // is this going to create memory leaks?
            Shipwreck.CurrentGame = null;
            MainMenuView mainMenuView = new MainMenuView();
            mainMenuView.Display();
            return true;
        }
    }
}
