using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Player : Character
    {
        public int Hunger { get; set; }
        public Player(string name, int hunger = 0)
            :base(name)
        {
            Hunger = hunger;
        }

        // maybe add an eat method? or does that break the MVC approach...?
    }
}
