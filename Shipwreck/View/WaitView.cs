using Shipwreck.Control;
using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class WaitView : View
    {

        public WaitView()
            :base("How many days would you like to wait for?")
        { }
        public override bool DoAction(string value)
        {
            int numDays;
            try
            {
                numDays = int.Parse(value);
            }
            catch(FormatException)
            {
                Console.WriteLine("Input must be a number");
                return false;
            }

            // will this quit if we die?
            GameController.Wait(numDays);

            return true;
        }
    }
}
