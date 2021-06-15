using Shipwreck.Model.Character;
using Shipwreck.Model.Map;

namespace Shipwreck.Control
{
    public static class CharacterController
    {
        public static void SetCharacterLocation(Character character, Location location)
        {
            if (location.Row < 0 || location.Col < 0) return;
            
            character.Row = location.Row;
            character.Col = location.Col;
        }
        
        public static void KillCharacter(Character character)
        {
            character.Status = CharacterStatus.Dead;

            // TODO separate these into separate methods/ controllers???
            if (character.GetType() == typeof(Player))
            {
                GameController.LoseGame();
            }
        }
    }
}
