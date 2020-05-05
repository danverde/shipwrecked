using Shipwreck.Control;
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
            // GameController.EndGame();
            // this ought to be part of game control
            Shipwreck.CurrentGame = null;

            // how to kick out of the current view loops?
            // Shipwreck.GameMenuView.Close();
            // Shipwreck.MainMenuView.Display();
            return true;
        }
    }
}
