using System;
using System.IO;
using Shipwreck.Helpers;
using Shipwreck.Model.Character;
using Shipwreck.Model.Settings;

namespace Shipwreck.Model.Game
{
    public class Game
    {
        public Player Player { get; set; }
        public Day Day { get; set; }
        public Fire Fire { get; set; }
        public GameStatus Status { get; set; }
        public Map.Map Map { get; set; }
        public GameSettings GameSettings { get; set; }
        public string SaveFileName { get; set; }

        public Game()
        {
            Status = GameStatus.Setup;
            var easyGamePath = Path.Combine(Environment.CurrentDirectory, Shipwreck.Settings.EasyGameSettingsPath);
            GameSettings = FileHelper.LoadJson<GameSettings>(easyGamePath);
        }
        
        public enum GameStatus
        {
            Over = 0,
            Setup = 1,
            Playing = 2,
        }
    }
}
