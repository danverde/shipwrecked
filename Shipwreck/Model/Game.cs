using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Game
    {
        public Player Player { get; private set; }
        public Day Day { get; private set; }

        public Game(Player player, Day day)
        {
            Player = player;
            Day = day;
        }

    }
}
