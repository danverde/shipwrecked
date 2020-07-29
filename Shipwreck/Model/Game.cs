using System;

namespace Shipwreck.Model
{
    class Game
    {
        public Player Player { get; private set; }
        public Day Day { get; private set; }
        public Fire Fire { get; private set; }
        public GameStatus Status { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
        }
        
        // public Game(Player player)
        // {
        //     Status = GameStatus.PreGame;
        //     Player = player;
        //     Day = new Day();
        //     Fire = new Fire();
        // }

        public void StartGame(Player player)
        {
            Player = player;
            Status = GameStatus.Playing;
            Fire = new Fire();
            Day = new Day();
        }

        public void EndGame()
        {
            Status = GameStatus.Over;
            Console.WriteLine("The game is over");
            
        }

    }
}
