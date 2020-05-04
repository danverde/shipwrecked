using Shipwreck.Model;
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
            Player player = new Player(characterName);
            AddDefaultItemsToInventory(player.Inventory);

            Shipwreck.currentGame = new Game(player);
        }

        private static void AddDefaultItemsToInventory(Inventory inventory)
        {
            Food fish = new Food("Fish", 3);
            inventory.AddItem(fish);
        }
    }
}