using System;

namespace Shipwreck.Model.Views
{
    public abstract class View
    {
        protected virtual string Message => "";
        private bool InGameView { get; set; }

        public void Display()
        {
            var closeView = false;
            while (closeView == false && (!InGameView || Shipwreck.CurrentGame.Status != Game.Game.GameStatus.Over))
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
    }
}
