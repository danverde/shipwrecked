using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class MainMenuView : View
    {
        public MainMenuView()
            :base("\n"
                  + "\n----------------------------------"
                  + "\n| Main Menu"
                  + "\n----------------------------------"
                  + "\nN - New Game"
                  + "\nS - Save Game"
                  + "\nC - Continue Game"
                  + "\nX - End it all (Exit Game)"
                  + "\nH - Help Menu"
                  + "\n----------------------------------")
        { }

        public override bool DoAction(string menuOption)
        {
            menuOption = menuOption.ToUpper();

            // not sure why this returns a boolean...
            return false;
        }
    }
}
