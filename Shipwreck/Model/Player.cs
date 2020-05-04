using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Player : Character
    {
        public int Hunger { get; set; }
        public Player(string name)
            :base(name)
        {
            Hunger = 0;
        }

        // maybe add an eat method? or does that break the MVC approach...?
    }
}
