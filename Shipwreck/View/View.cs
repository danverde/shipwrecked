using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    abstract class View : IView
    {

        protected string displayMessage;

        // so that you don't have to pass a message to the constructor of a view
        public View()
        {

        }

        public View(string message)
        {
            displayMessage = message;
        }

        // public override void Display()?
        public void Display()
        {
            var done = false;
            do
            {
                string value = GetInput();
                if (value.ToUpper() == "X")
                {
                    return;
                }
                done = DoAction(value);
            } while (!done);
        }

        // public override string GetInput()?
        public string GetInput()
        {
            string value = null;
            bool valid = false;

            while(!valid)
            {
                Console.WriteLine($"\n{displayMessage}");

                value = Console.ReadLine();
                value = value.Trim();

                if (value.Length < 1)
                {
                    Console.WriteLine("\nInvalid value. Entry cannot be blank");
                    continue;
                }
                break;
            }

            return value;
        }

        public abstract bool DoAction(string value);
    }
}
