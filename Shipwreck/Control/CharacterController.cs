using Shipwreck.Model.Character;
using Shipwreck.Model.Map;

namespace Shipwreck.Control
{
    public static class CharacterController
    {
        public static void SetLocationCoordinates(Character character, Location location)
        {
            character.Row = location.Row;
            character.Col = location.Col;
        }
        
        public static int Attack(Character defendingCharacter, Character attackingCharacter)
        {
            var damageAmount = attackingCharacter.CalculatedAttack - defendingCharacter.CalculatedDefense;
            if (damageAmount <= 0)
            {
                damageAmount = 0;
            }
            
            defendingCharacter.Health -= damageAmount;
            return damageAmount;
        }
        
        public static void Die(Character character)
        {
            character.Status = CharacterStatus.Dead;
        }
    }
}
