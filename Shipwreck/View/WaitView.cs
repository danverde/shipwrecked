using Shipwreck.Control;
using System;

namespace Shipwreck.View
{
    class WaitView : View
    {
        public WaitView()
        {
            ParentView = new GameMenuView();
            Message = "How many days would you like to wait for?";
        }
        
        protected override bool HandleInput(string input)
        {
            if (int.TryParse(input, out var numDays))
            {
                // will this quit if we die?
                GameController.Wait(numDays);

                return true;
            }
            else
            {
                Console.WriteLine("Input must be a number");
                return false;
            }
        }
    }
}
