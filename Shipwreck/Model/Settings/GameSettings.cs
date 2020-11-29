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
        public string MapPath { get; set; }
    }

    public class PlayerSettings
    {
        public int BaseExpPerDay { get; set; }
        public int HungerPerDay { get; set; }
        public int InitialHunger { get; set; }
        public int HealthGrowth { get; set; } 
        public int AttachGrowth { get; set; } 
        public int DefenseGrowth { get; set; } 
    }

    public class FireSettings
    {
        public int FireExpBoost { get; set; }
        public int WoodBurnPerDay { get; set; }
    }
}