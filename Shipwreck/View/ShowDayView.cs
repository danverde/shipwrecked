﻿using Shipwreck.Model.Character;

namespace Shipwreck.View
{
    class ShowDayView : View
    {
        public ShowDayView()
        {
            InGameView = true;
            Message = "\n---------------------" +
                      $"\n Day {Shipwreck.CurrentGame.Day.Number}" +
                      // $"\n Weather: {Shipwreck.CurrentGame.Day.Weather.Name}" +
                      $"\n Hunger: {Shipwreck.CurrentGame.Player.Hunger} / {Player.HungerLimit}" +
                      "\n---------------------";
        }
        
        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}