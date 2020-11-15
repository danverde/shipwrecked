using System;
using Shipwreck.Model;
using Shipwreck.Model.Game;

namespace Shipwreck.View
{
    public abstract class View
    {
        protected string Message { get; set; }
        protected bool InGameView { get; set; }
        
        public void Display()
        {
            var closeView = false;
            while(closeView == false && (!InGameView || Shipwreck.CurrentGame.Status != GameStatus.Over))
            {
                closeView = true;
                Console.WriteLine(Message);
                var input = GetInput();
                if (input != "X")
                {
                    closeView = HandleInput(input);
                }
            }
        }

        protected virtual string GetInput()
        {
            var input = Console.ReadLine();

            input = FormatInput(input);
            
            return input;
        }

        protected string FormatInput(string input)
        {
            return input?.ToUpper() ?? "";
        }

        protected abstract bool HandleInput(string input);

        protected void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
