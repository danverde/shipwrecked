using System;
using System.IO;
using Shipwreck.Helpers;
using Shipwreck.Model.Character;
using Shipwreck.Model.Settings;

namespace Shipwreck.Model.Game
{
    class Game
    {
        public Player Player { get; set; }
        public Day Day { get; set; }
        public Fire Fire { get; set; }
        public GameStatus Status { get; set; }
        public Map.Map Map { get; set; }
        public GameSettings GameSettings { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
            // TODO move easyGamePath to shipwreck settings
            var easyGamePath = Path.Combine(Environment.CurrentDirectory, "Data/Settings/easyGame.json");
            GameSettings = FileHelper.LoadJson<GameSettings>(easyGamePath);
        }
        
        // TODO this looks like a really good idea...
        // public Game(Player player)
        // {
        //     Status = GameStatus.PreGame;
        //     Player = player;
        //     Day = new Day();
        //     Fire = new Fire();
        // }

        // public void SetupGame(Player player, Map.Map map)
        // {
        //     Player = player;
        //     Status = GameStatus.Playing;
        //     Fire = new Fire();
        //     Day = new Day();
        //     Map = map;
        // }

        public void EndGame()
        {
            Status = GameStatus.Over;
            Console.WriteLine("The game is over");
            
        }

    }
}
