using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class HelpMenuView : View
    {
        public HelpMenuView()
            :base("Welcome to the help Menu!\nCome get some freaking help")
        {

        }
        public override bool DoAction(string value)
        {
            return false;
        }
    }
}
