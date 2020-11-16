using Shipwreck.Model.Character;
using Shipwreck.Model.Game;

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

        
        
        public static void KillPlayer(Player player, Game game)
        {
            player.Die();
            game.EndGame();
        }
    }
}
