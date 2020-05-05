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

            Shipwreck.CurrentGame = new Game(player);
        }

        public static void AdvanceDay()
        {
            
            Shipwreck.CurrentGame.IncrementDay();
            Shipwreck.CurrentGame.Player.Hunger += 3; // this probably ought to be a value somewhere
            if (Shipwreck.CurrentGame.Player.Hunger > 20) // also ought to be a value somewhere...
            {
                EndGame();
            }
            
        }

        public static void EndGame()
        {
            Shipwreck.CurrentGame = null;

            GameOverView gameOverView = new GameOverView();
            gameOverView.Display();
        }
    }
}