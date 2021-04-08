namespace Shipwreck.View
{
    public class LevelUpView : View
    {
        protected override string Message => "\n\n----------------------------------"
                                             + "\n| Level Up"
                                             + "\n----------------------------------"
                                             + $"\n Level {Shipwreck.CurrentGame.Player.Level}"
                                             + $"\n Max Health {Shipwreck.CurrentGame.Player.Health}"
                                             // + $"\n Base Attack {Shipwreck.CurrentGame.Player.BaseAttack}"
                                             // + $"\n Base Defense {Shipwreck.CurrentGame.Player.BaseDefense}"
                                             + "\n----------------------------------";

        protected override bool HandleInput(string input)
        {
            return true;
        }
    }
}