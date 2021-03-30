using Shipwreck.Model.Items;
using Shipwreck.Model.Map;

namespace Shipwreck.Model.Character
{
    public class Player : Character
    {
        public int Exp { get; set; }
        public int Hunger { get; set; }
        public static int HungerLimit => 20; // TODO pull from game settings 
        public int Col { get; set; }
        public int Row { get; set; }

        public void SetLocationCoordinates(Location location)
        {
            Row = location.Row;
            Col = location.Col;
        }
        
        public void GainExperience(int experience)
        {
            Exp += experience;
            while (Exp >= 100)
            {
                LevelUp();
                Exp -= 100;
            }
        }

        private void LevelUp()
        {
            // var playerSettings = Shipwreck.CurrentGame.GameSettings.Player;
            //
            // Level++;
            // BaseAttack += playerSettings.AttachGrowth;
            // BaseDefense += playerSettings.DefenseGrowth;
            // MaxHealth += playerSettings.HealthGrowth;
            // Health += playerSettings.HealthGrowth;
            //
            // new LevelUpView().Display();
        }
    }
}
