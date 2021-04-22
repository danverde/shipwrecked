namespace Shipwreck.Model.Character
{
    public class Player : Character
    {
        public int Hunger { get; set; }
        public int HungerLimit { get; set; }
        public int Level { get; set; }
        public int Exp { get; set; }
    }
}
