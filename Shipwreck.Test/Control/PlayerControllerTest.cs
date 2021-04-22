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
        [InlineData(1, 0, 0, 1)]
        [InlineData(1, -50, 0, 1)]
        [InlineData(1, 50, 50, 1)]
        [InlineData(1, 100, 0, 2)]
        [InlineData(1, 150, 50, 2)]
        [InlineData(1, 1500, 0, 16)]
        public void TestGainExp(int level, int exp, int expectedExp, int expectedLevel)
        {
            Shipwreck.CurrentGame.GameSettings.Player = new PlayerSettings();
            
            var player = new Player
            {
                Level = level,
                Exp = 0,
                MaxHealth = 5,
                Health = 5,
                HungerLimit = 5
            };
            
            PlayerController.GainExp(player, exp);
            
            Assert.Equal(expectedExp, player.Exp);
            Assert.Equal(expectedLevel, player.Level);
        }
    }
}