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
        public string StatusDescription { get; set; }
        public Map.Map Map { get; set; }
        public GameSettings GameSettings { get; set; }
        public string SaveFileName { get; set; }

        public Game()
        {
            Status = GameStatus.PendingSetup;
        }

        public enum GameStatus
        {
            // Over,
            PendingSetup,
            Playing,
            Lost,
            Won,
            Quit,
        }
    }
}
