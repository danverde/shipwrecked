using System;
using Shipwreck.Helpers;
using Shipwreck.Model.Game;

namespace Shipwreck.Control
{
    public static class GameController
    {
        public static void WinGame(string message = "YOU WON")
        {
            Shipwreck.CurrentGame.Status = Game.GameStatus.Won;
            Shipwreck.CurrentGame.StatusDescription = message;
        }
        
        public static void LoseGame(string message = "You Died. Sucks to suck")
        {
            Shipwreck.CurrentGame.Status = Game.GameStatus.Lost;
            Shipwreck.CurrentGame.StatusDescription = message;
        }

        /* Advance Days *******************************************************
         * This method can end the game. you HAVE to check the game status after
         * calling this method and kick out of the game loop if the game ended
        */
        public static void AdvanceDays(int numDays, bool waiting = false)
        {
            for (var i = 0; i < numDays && Shipwreck.CurrentGame.Status == Game.GameStatus.Playing; i++)
            {
                AdvanceDay(waiting);
            }
        }
        
        private static void AdvanceDay(bool waiting = false)
        {
            var player = Shipwreck.CurrentGame.Player;
            var exp = Shipwreck.CurrentGame.GameSettings.Player.BaseExpPerDay;
            
            player.Hunger -= Shipwreck.CurrentGame.GameSettings.Player.HungerPerDay;
            if (player.Hunger < 0) player.Hunger = 0;
            
            // let the player know the next day has started
            Shipwreck.CurrentGame.Day++;
            ViewHelpers.ShowNewDay();

            
            /***************************
             * Game ending phenomenon
             ***************************/
            // ENHANCEMENT implement potential weather deaths
            
            // Hunger -> calc before new day starts
            if (Shipwreck.CurrentGame.Player.Hunger <= 0)
            {
                CharacterController.KillCharacter(player);
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
            
            /**********************************
             * Gain Exp for living another day
             **********************************/
            PlayerController.GainExp(player, exp);
        }
    }
}