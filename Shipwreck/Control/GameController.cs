using Shipwreck.Model;
using Shipwreck.View;
using System;

namespace Shipwreck.Control
{
    class GameController
    {
        public static void StartNewGame(string characterName)
        {
            // setup player
            var player = new Player(characterName, 5);
            InventoryController.AddDefaultItemsToInventory(player.Inventory);

            // setup game
            Shipwreck.CurrentGame.StartGame(player);
            
            // open view
            new NewDayView().Display();
        }
        
        public static void LoseGame()
        {
            Shipwreck.CurrentGame.Player.Die();
            Shipwreck.CurrentGame.Status = GameStatus.Over;

            new GameOverView().Display();
        }

        public static void WinGame(string message)
        {
            Shipwreck.CurrentGame.Status = GameStatus.Over;
            new GameOverView(message).Display();
        }
        
        public static void QuitGame()
        {
            Shipwreck.CurrentGame.Status = GameStatus.Over;
            new GameOverView("GAME OVER").Display();
        }

        public static void Wait(int numDays)
        {
            for (var i = 0; i < numDays && Shipwreck.CurrentGame.Status == GameStatus.Playing; i++)
            {
                AdvanceDay(true);
            }
        }

        private static void AdvanceDay(bool waiting = false)
        {
            var player = Shipwreck.CurrentGame.Player;
            var exp = 25;

            // They get hungry - TODO should this happen as they move instead of overnight?
            player.Hunger += Day.HungerPerDay;
            if (Shipwreck.CurrentGame.Player.Hunger > Player.HungerLimit)
            {
                LoseGame();
                return;
            }

            // Their fire burns
            FireController.Burn(Shipwreck.CurrentGame.Fire);
            exp = Shipwreck.CurrentGame.Fire.Status == FireStatus.Burning ? exp + 15: exp;


            // let the player know the next day has started
            Shipwreck.CurrentGame.Day.IncrementDay();
            // gain EXP
            // TODO EXP should be higher if a fire is burning
            player.GainExperience(exp);
            
            // BREAKS waiting b/c it opens the parent view...
            new NewDayView().Display();

            // TODO implement potential weather deaths

            if (waiting && new Random().Next(100000) == 1)
            {
                var message = "\n You're Saved! What luck!" +
                              "\n A gang of local poachers found you on their way back to town." +
                              "\n Good thing they're not picky about how they earn a living...";
                WinGame(message);
            }
        }
        
    }
}