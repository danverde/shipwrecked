using Shipwreck.Control;

namespace Shipwreck.View
{
    class NewGameView : View
    {
        public NewGameView()
        {
            InGameView = true;
            // ParentView = new MainMenuView();
            Message = "\nPlease Enter Your Character's Name:\n";
        }

        protected override bool HandleInput(string input)
        {
            if (input == "")
            {
                return false;
            }
            
            GameController.StartNewGame(input);
            new GameMenuView().Display();
            return true;
        }
    }
}
