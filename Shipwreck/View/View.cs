using System;
using Shipwreck.Model;

namespace Shipwreck.View
{
    public abstract class View
    {
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

            if (Shipwreck.CurrentGame.Status == GameStatus.Playing)
            {
                OpenParentView();
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

        private void OpenParentView()
        {
            ParentView?.Display();
        }

        public void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
