namespace Shipwreck.Model.Character
{
    public class Player : Character
    {
        public int Exp { get; set; }
        public int Hunger { get; set; }
        public static int HungerLimit => 20; // TODO pull from game settings 
    }
}
