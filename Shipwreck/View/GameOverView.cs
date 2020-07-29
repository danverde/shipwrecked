namespace Shipwreck.View
{
    class GameOverView : View
    {
        public GameOverView()
        {
            // called after the game is set to over 
            InGameView = false; 
            Message = "You Died. Sucks to suck\n GAME OVER";
        }
        
        public GameOverView(string message)
        {
            InGameView = false;
            Message = message;
        }

        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}
