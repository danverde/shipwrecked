using Shipwreck.Control;
using Shipwreck.Model.Character;
using Shipwreck.Model.Map;
using Xunit;

namespace Shipwreck.Test.Control
{
    public class CharacterControllerTest
    {
        [Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(3, 4, 3, 4)]
        [InlineData(-1, -1, 1, 1)]
        public void TestSetLocationCoordinate(int row, int col, int expectedRow, int expectedCol)
        {
            var character = new Character
            {
                Row = 1,
                Col = 1
            };
            
            var location = new Location
            {
                Row = row,
                Col = col
            };
            
            CharacterController.SetCharacterLocation(character, location);
            
            Assert.Equal(expectedRow, character.Row);
            Assert.Equal(expectedCol, character.Col);
        }
        
        [Fact]
        public void TestKillCharacter()
        {
            var character = new Character
            {
                Status = CharacterStatus.Alive
            };
            
            CharacterController.KillCharacter(character);
            
            Assert.Equal(CharacterStatus.Dead, character.Status);
            
            // TODO test is lose game called if player is passed in instead of a character
        }
    }
}