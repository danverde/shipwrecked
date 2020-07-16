using System;

namespace Shipwreck.Model
{
    class Game
    {
        public Player Player { get; }
        public Day Day { get; }
        public Fire Fire { get;  }
        public GameStatus Status { get; set; }

        public Game(Player player)
        {
            Status = GameStatus.PreGame;
            Player = player;
            Day = new Day();
            Fire = new Fire();
        }
        
        // public void StartGame()
        // {
        //     Status = GameStatus.Playing;
        //     Console.WriteLine("The game has begun");
        // }

        public void EndGame()
        {
            Status = GameStatus.Over;
            Console.WriteLine("The game is over");
            
        }

    }
}
