using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Game
    {
        public Player Player { get; private set; }
        public int Day { get; private set; }

        public Game(Player player)
        {
            Player = player;
            Day = 1;
        }

        public void IncrementDay()
        {
            ++Day;
        }

    }
}
