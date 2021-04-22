using Shipwreck.Model.Character;
using Shipwreck.Model.Items;

namespace Shipwreck.Control
{
    public static class PlayerController
    {
        public static void Eat(Player player, Food food, int quantity)
        {
            player.Health += food.HealingPower * quantity;
            player.Hunger += food.FillingPower * quantity;

            if (player.Health > player.MaxHealth) player.Health = player.MaxHealth;
            if (player.Hunger > player.HungerLimit) player.Hunger = player.HungerLimit;
        }
        
        public static void GainExp(Player player, int experience)
        {
            player.Exp += experience;
            while (player.Exp >= 100)
            {
                LevelUp(player);
                player.Exp -= 100;
            }
        }
        
        private static void LevelUp(Player player)
        {
            var playerSettings = Shipwreck.CurrentGame.GameSettings.Player;
            
            player.Level++;
            player.BaseAttack += playerSettings.AttachGrowth;
            player.BaseDefense += playerSettings.DefenseGrowth;
            player.MaxHealth += playerSettings.HealthGrowth;
            player.Health += playerSettings.HealthGrowth;
        }
    }
}