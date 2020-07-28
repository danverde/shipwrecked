using Shipwreck.Control;

namespace Shipwreck.View
{
    class NewGameView : View
    {
        public NewGameView()
        {
            ParentView = new GameMenuView();
            Message = "\nPlease Enter Your Character's Name:\n";
        }

        protected override bool HandleInput(string input)
        {
            if (input == "")
            {
                return false;
            }
            
            GameController.StartCurrentGame(input);
            new GameMenuView().Display();
            return true;
        }
    }
}
