using Shipwreck.Model;
using Shipwreck.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Shipwreck.Control
{
    class GameController
    {
        public static void CreateNewGame(string characterName)
        {
            Player player = new Player(characterName, 5);
            InventoryController.AddDefaultItemsToInventory(player.Inventory);
            Day day = new Day();

            Shipwreck.CurrentGame = new Game(player, day);
            Shipwreck.NewDayView.Display();
        }

        public static void Wait(int numDays)
        {
            for (int i = 0; i < numDays && Shipwreck.CurrentGame != null; i++)
            {
                AdvanceDay(true);
            }
        }

        public static void EndGame()
        {
            Shipwreck.CurrentGame.Player.Die();
            Shipwreck.CurrentGame = null;

            GameOverView gameOverView = new GameOverView();
            gameOverView.Display();
        }

        private static void AdvanceDay(bool waiting = false)
        {
            Shipwreck.CurrentGame?.Day.IncrementDay();
            Player player = Shipwreck.CurrentGame?.Player;
            player.GainExperience(25);

            Shipwreck.NewDayView.Display();

            player.Hunger += Day.HungerPerDay; // this probably ought to be a value somewhere
            if (Shipwreck.CurrentGame.Player.Hunger > 20) // also ought to be a value somewhere...
            {
                EndGame();
            }

            Random random = new Random();
            if (waiting && random.Next(100000) == 1)
            {
                string message = "\n You're Saved! What luck!" +
                    "\n A gang of local poachers found you on their way back to town." +
                    "\n Good thing their not picky about how they earn a living...";
                GameOverView gameOverView = new GameOverView(message);
                gameOverView.Display();
            }

        }
    }
}