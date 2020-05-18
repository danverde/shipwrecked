using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class NewDayView
    {
        public void Display()
        {
            // string day = Shipwreck.CurrentGame != null ? Shipwreck.CurrentGame.Day.ToString() : "Unknown";
            Day day = Shipwreck.CurrentGame?.Day;

            Console.WriteLine("\n---------------------" +
                $"\n Day {day.Number}" +
                $"\n Weather: {day.Weather.Name}" +
                "\n---------------------");
        }
    }
}
