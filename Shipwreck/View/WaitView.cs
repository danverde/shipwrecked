using Shipwreck.Control;
using System;

namespace Shipwreck.View
{
    class WaitView : Model.Views.View
    {
        protected override string Message => "How many days would you like to wait for?";

        protected override bool HandleInput(string input)
        {
            var closeView = false;
            
            if (int.TryParse(input, out var numDays))
            {
                GameController.AdvanceDays(numDays, true);
                closeView = true;
            }
            else
            {
                Console.WriteLine("Input must be a number");
            }

            return closeView;
        }
    }
}
