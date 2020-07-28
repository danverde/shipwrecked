namespace Shipwreck.View
{
    class GameOverView : View
    {
        public GameOverView()
        {
            ParentView = new MainMenuView();
            Message = "You Died. Sucks to suck\n GAME OVER";
        }
        
        public GameOverView(string message)
        {
            ParentView = new MainMenuView();
            Message = message;
        }

        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}
