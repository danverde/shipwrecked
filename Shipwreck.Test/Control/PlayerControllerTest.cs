using Shipwreck.Control;
using Shipwreck.Model.Character;
using Shipwreck.Model.Items;
using Shipwreck.Model.Settings;
using Shipwreck.Test.Fixtures;
using Xunit;

namespace Shipwreck.Test.Control
{
    public class PlayerControllerTest : IClassFixture<ShipwreckFixture>
    {
        private Shipwreck Shipwreck;
        
        [Fact]
        public void TestEat()
        {
        var player = new Player
        {
            Hunger = 10,
            Health = 10,
            MaxHealth = 15,
            HungerLimit = 15,
        };
        
        var food = new Food
        {
            HealingPower = 1,
            FillingPower = 1
        };
        
            PlayerController.Eat(player, food, 1);
            Assert.Equal(11, player.Health);   
            Assert.Equal(11, player.Hunger);
            
            PlayerController.Eat(player, food, 20);
            Assert.Equal(player.MaxHealth, player.Health);   
            Assert.Equal(player.HungerLimit, player.Hunger);
        }
        
        [Theory]
        [InlineData(0, 0, 1, 5, 10, 15, 1, 0)]
        [InlineData(-50, 0, 1, 5, 10, 15, 1, 0)]
        [InlineData(50, 50, 1, 5, 10, 15, 1, 0)]
        [InlineData(100, 0, 2, 6, 11, 15, 2, 1)]
        [InlineData(150, 50, 2, 6, 11, 15, 2, 1)]
        [InlineData(1500, 0, 16, 20, 25, 15, 16, 15)]
        public void TestGainExp(int exp, int expectedExp, int expectedLevel, int expectedHealth, int expectedMaxHealth, int expectedHunger, int expectedAttack, int expectedDefense)
        {
            Shipwreck.CurrentGame.GameSettings.Player = new PlayerSettings
            {
                BaseExpPerDay = 25,
                HungerPerDay = 3,
                InitialHunger = 15,
                HealthGrowth = 1,
                AttackGrowth = 1,
                DefenseGrowth = 1,
                MaxHunger = 20
            };
            
            const int hungerLimit = 20;
            
            var player = new Player
            {
                Level = 1,
                Exp = 0,
                MaxHealth = 10,
                HungerLimit = hungerLimit,
                Health = 5,
                BaseAttack = 1,
                BaseDefense = 0,
                Hunger = Shipwreck.CurrentGame.GameSettings.Player.InitialHunger,
            };
            
            PlayerController.GainExp(player, exp);
            
            Assert.Equal(expectedExp, player.Exp);
            Assert.Equal(expectedLevel, player.Level);
            
            
            Assert.Equal(expectedHealth, player.Health);
            Assert.Equal(expectedMaxHealth, player.MaxHealth);
            Assert.Equal(expectedHunger, player.Hunger);
            Assert.Equal(hungerLimit, player.HungerLimit);
            Assert.Equal(expectedAttack, player.BaseAttack);
            Assert.Equal(expectedDefense, player.BaseDefense);
        }
    }
}