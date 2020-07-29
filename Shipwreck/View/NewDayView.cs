namespace Shipwreck.View
{
    class NewDayView : View
    {
        public NewDayView()
        {
            InGameView = true;
            Message = "\n---------------------" +
                      $"\n Day {Shipwreck.CurrentGame.Day.Number}" +
                      $"\n Weather: {Shipwreck.CurrentGame.Day.Weather.Name}" +
                      "\n---------------------";
        }
        
        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}
