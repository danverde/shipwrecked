namespace Shipwreck.View
{
    class GameOverView : View
    {
        public GameOverView()
        {
            Message = "You Died. Sucks to suck";
        }
        
        public GameOverView(string message)
        {
            Message = message;
        }

        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}
