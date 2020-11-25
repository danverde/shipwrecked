using Shipwreck.Control;

namespace Shipwreck.View
{
    class NewGameView : View
    {
        public NewGameView()
        {
            InGameView = true;
            Message = "\nPlease Enter Your Character's Name:\n";
        }

        protected override bool HandleInput(string input)
        {
            if (input == "")
            {
                return false;
            }
            
            GameController.SetupNewGame(input);
            return true;
        }
    }
}
