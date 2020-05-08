using Shipwreck.Control;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class GameOverView : View
    {
        public GameOverView(string message = "You Died. Sucks to suck")
            :base(message, true)
        {}
        public override bool DoAction(string value)
        {
            return true;
        }
    }
}
