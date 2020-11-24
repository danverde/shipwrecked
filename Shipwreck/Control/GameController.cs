﻿using Shipwreck.Model;
using Shipwreck.View;
using System;
using Shipwreck.Model.Character;
using Shipwreck.Model.Game;

namespace Shipwreck.Control
{
    class GameController
    {
        public static void StartNewGame(string characterName)
        {
            // setup map
            var map = MapController.LoadMap1();
            var startingLocation = map.Locations[map.StartingRow, map.StartingCol];
            
            // setup player
            var player = new Player(characterName, 5, startingLocation);
            startingLocation.Characters.Add(player);
            InventoryController.AddDefaultItemsToInventory(player.Inventory);
            
            // start game
            Shipwreck.CurrentGame.StartGame(player, map);

            
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

        public static void AdvanceDays(int numDays, bool waiting = false)
        {
            for (var i = 0; i < numDays && Shipwreck.CurrentGame.Status == GameStatus.Playing; i++)
            {
                AdvanceDay(waiting);
            }
        }

        private static void AdvanceDay(bool waiting = false)
        {
            var player = Shipwreck.CurrentGame.Player;
            var exp = Shipwreck.CurrentGame.GameSettings.Player.BaseExpPerDay;
            
            // let the player know the next day has started
            Shipwreck.CurrentGame.Day.IncrementDay();
            new NewDayView().Display();

            
            /***************************
             * Game ending phenomenon
             ***************************/
            // TODO implement potential weather deaths
            
            // Hunger
            player.Hunger += Shipwreck.CurrentGame.GameSettings.Player.HungerPerDay;
            if (Shipwreck.CurrentGame.Player.Hunger > Player.HungerLimit)
            {
                LoseGame();
                return;
            }
            
            // Rescue (if waiting)
            if (waiting && new Random().Next(Shipwreck.CurrentGame.GameSettings.WaitSuccessRate) == 1)
            {
                const string message = "\n You're Saved! What luck!" +
                                       "\n A gang of local poachers found you on their way back to town." +
                                       "\n Good thing they're not picky about how they earn a living...";
                WinGame(message);
            }
            
            
            /***************************
             * Other phenomenon
             ***************************/
            // Their fire burns
            FireController.Burn(Shipwreck.CurrentGame.Fire);
            exp = Shipwreck.CurrentGame.Fire.Status == FireStatus.Burning ? exp + Shipwreck.CurrentGame.GameSettings.Fire.FireExpBoost: exp;
            
            
            /**********************************
             * Gain Exp for living another day
             **********************************/
            player.GainExperience(exp);
        }
        
    }
}