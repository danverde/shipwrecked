using Shipwreck.Model.Character;

namespace Shipwreck.View
{
    class ShowDayView : Model.Views.View
    {
        protected override string Message => "\n---------------------" +
                                             $"\n Day {Shipwreck.CurrentGame.Day.Number}" +
                                             // $"\n Weather: {Shipwreck.CurrentGame.Day.Weather.Name}" +
                                             $"\n Hunger: {Shipwreck.CurrentGame.Player.Hunger} / {Shipwreck.CurrentGame.Player.HungerLimit}" +
                                             "\n---------------------";

        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}
