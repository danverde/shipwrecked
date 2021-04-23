using Shipwreck.Control;
using Shipwreck.Model.Game;
using Shipwreck.Test.Fixtures;
using Xunit;

namespace Shipwreck.Test.Control
{
    public class GameControllerTest : IClassFixture<ShipwreckFixture>
    {
        private Shipwreck Shipwreck;
        
        [Theory]
        [InlineData("da Message", "da Message")]
        [InlineData("", "")]
        public void TestWinGame(string message, string expectedMessage)
        {
            GameController.WinGame(message);
            
            Assert.Equal(Game.GameStatus.Won, Shipwreck.CurrentGame.Status);
            Assert.Equal(expectedMessage, Shipwreck.CurrentGame.StatusDescription);
        }
        
        [Fact]
        public void TestWinGameDefaultMessage()
        {
            GameController.WinGame();
            
            Assert.Equal(Game.GameStatus.Won, Shipwreck.CurrentGame.Status);
            Assert.False(string.IsNullOrEmpty(Shipwreck.CurrentGame.StatusDescription));
        }
        
        
        [Theory]
        [InlineData("da Message", "da Message")]
        [InlineData("", "")]
        public void TestLoseGame(string message, string expectedMessage)
        {
            GameController.LoseGame(message);
            
            Assert.Equal(Game.GameStatus.Lost, Shipwreck.CurrentGame.Status);
            Assert.Equal(expectedMessage, Shipwreck.CurrentGame.StatusDescription);
        }
        
        [Fact]
        public void TestLoseGameDefaultMessage()
        {
            GameController.LoseGame();
            
            Assert.Equal(Game.GameStatus.Lost, Shipwreck.CurrentGame.Status);
            Assert.False(string.IsNullOrEmpty(Shipwreck.CurrentGame.StatusDescription));
        }
        
        // TODO test advance day
        // figure out how to test a controller that calls a view...
    }
}