namespace Shipwreck.Model.Game
{
    public class GameSettings
    {
        public bool EnableFow { get; set; }
        public int BaseExpPerDay { get; set; }
        public int FireExpBoost { get; set; }
        public int HungerPerDay { get; set; }
        public int WoodBurnPerDay { get; set; }
        public int WaitSuccessRate { get; set; }
    }
}