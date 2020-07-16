using Shipwreck.Model;
using Shipwreck.View;
using System;

namespace Shipwreck.Control
{
    class GameController
    {
        public static void CreateNewGame(string characterName)
        {
            var player = new Player(characterName, 5);
            InventoryController.AddDefaultItemsToInventory(player.Inventory);

            Shipwreck.CurrentGame = new Game(player);
            new NewDayView().Display();
        }

        public static void Wait(int numDays)
        {
            for (var i = 0; i < numDays && Shipwreck.CurrentGame != null; i++)
            {
                AdvanceDay(true);
            }
        }

        public static void EndGame()
        {
            Shipwreck.CurrentGame.Player.Die();
            Shipwreck.CurrentGame = null;

            var gameOverView = new GameOverView();
            gameOverView.Display();
        }

        private static void AdvanceDay(bool waiting = false)
        {
            var player = Shipwreck.CurrentGame.Player;
            var exp = 25;

            // They get hungry
            player.Hunger += Day.HungerPerDay; // this probably ought to be a value somewhere
            if (Shipwreck.CurrentGame.Player.Hunger > 20) // also ought to be a value somewhere...
            {
                EndGame();
            }

            // Their fire burns
            FireController.Burn(Shipwreck.CurrentGame?.Fire);
            exp = Shipwreck.CurrentGame.Fire.Status == FireStatus.Burning ? exp + 15: exp;


            // let the player know the next day has started
            Shipwreck.CurrentGame?.Day.IncrementDay();
            // gain EXP
            // TODO EXP should be higher if a fire is burning
            player.GainExperience(exp);
            new NewDayView().Display();

            // TODO implement potential weather deaths

            var random = new Random();
            if (waiting && random.Next(100000) == 1)
            {
                var message = "\n You're Saved! What luck!" +
                              "\n A gang of local poachers found you on their way back to town." +
                              "\n Good thing their not picky about how they earn a living...";
                var gameOverView = new GameOverView(message);
                gameOverView.Display();
            }
        }
    }
}