using Shipwreck.Model;

namespace Shipwreck.Control
{
    class CharacterController
    {
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
    }
}
