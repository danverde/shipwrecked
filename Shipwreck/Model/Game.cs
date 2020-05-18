using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Game
    {
        public Player Player { get; }
        public Day Day { get; }
        public Fire Fire { get;  }

        public Game(Player player)
        {
            Player = player;
            Day = new Day();
            Fire = new Fire();
        }

    }
}
