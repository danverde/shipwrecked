using System;
using Shipwreck.Model;

namespace Shipwreck.View
{
    public abstract class View
    {
        protected bool AllowEmpty { get; set; }
        protected View ParentView { get; set; }
        protected string Message { get; set; }

        public void Display()
        {
            var closeView = true;
            do
            {
                Console.WriteLine(Message);
                var input = GetInput();
                if (input != "X")
                {
                    closeView = HandleInput(input);
                }

            } while (closeView == false && Shipwreck.CurrentGame.Status != GameStatus.Over);

            // don't open the parent view if the game is over
            if (Shipwreck.CurrentGame?.Status != GameStatus.Over)
            {
                OpenParentView();
            }
        }

        // public override string GetInput()?
        protected virtual string GetInput()
        {
            // get input
            var input = Console.ReadLine();

            input = FormatInput(input);
            
            return input;
        }

        protected string FormatInput(string input)
        {
            // format input 
            return input?.ToUpper() ?? "";
        }

        protected abstract bool HandleInput(string input);

        private void OpenParentView()
        {
            ParentView?.Display();
        }

        protected void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
