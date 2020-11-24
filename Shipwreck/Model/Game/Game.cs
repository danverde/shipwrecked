﻿using System;
using Shipwreck.Helpers;
using Shipwreck.Model.Character;
using Shipwreck.Model.Settings;

namespace Shipwreck.Model.Game
{
    class Game
    {
        public Player Player { get; private set; }
        public Day Day { get; private set; }
        public Fire Fire { get; private set; }
        public GameStatus Status { get; set; }
        public Map.Map Map { get; set; }
        public GameSettings GameSettings { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
            GameSettings = JsonLoader.LoadJson<GameSettings>("Data/Settings/easyGame.json");
        }
        
        // TODO this looks like a really good idea...
        // public Game(Player player)
        // {
        //     Status = GameStatus.PreGame;
        //     Player = player;
        //     Day = new Day();
        //     Fire = new Fire();
        // }

        public void StartGame(Player player, Map.Map map)
        {
            Player = player;
            Status = GameStatus.Playing;
            Fire = new Fire();
            Day = new Day();
            Map = map;
        }

        public void EndGame()
        {
            Status = GameStatus.Over;
            Console.WriteLine("The game is over");
            
        }

    }
}
