using Shipwreck.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Control
{
    class CharacterController
    {
        public static int Attack(Character defendingCharacter, Character attackingCharacter)
        {
            int damageAmount = attackingCharacter.CalculatedAttack - defendingCharacter.CalculatedDefense;
            if (damageAmount <= 0)
            {
                damageAmount = 0;
            }
            
            defendingCharacter.Health -= damageAmount;
            return damageAmount;
        }
    }
}
