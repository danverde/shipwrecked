namespace Shipwreck.Model.Settings
{
    public class GameSettings
    {
        public int WaitSuccessRate { get; set; }
        public MapSettings Map { get; set; }
        public PlayerSettings Player { get; set; }
        public FireSettings Fire { get; set; }
    }

    public class MapSettings
    {
        public bool EnableFow { get; set; }
    }

    public class PlayerSettings
    {
        public int BaseExpPerDay { get; set; }
        public int HungerPerDay { get; set; }
    }

    public class FireSettings
    {
        public int FireExpBoost { get; set; }
        public int WoodBurnPerDay { get; set; }
    }
}