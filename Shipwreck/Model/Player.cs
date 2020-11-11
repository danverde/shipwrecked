using System;
using Shipwreck.Model.Items;
using Shipwreck.View;

namespace Shipwreck.Model
{
    class Player : Character
    {
        public int Exp { get; private set; }
        public int Hunger { get; set; }
        public const int HungerLimit = 20; 
        public Player(string name, int hunger = 0)
            :base(name)
        {
            Hunger = hunger;
        }

        public void GainExperience(int experience)
        {
            Exp += experience;
            while (Exp >= 100)
            {
                LevelUp();
                Exp -= 100;
            }
        }

        private void LevelUp()
        {
            Level++;
            // I'll have to change stat growths later...
            BaseAttack += 1;
            BaseDefense += 1;
            MaxHealth += 1;
            Health += 1;
            
            new LevelUpView().Display();
        }

        // TODO should this be in a controller?
        public void Eat(Food food)
        {
            Health = Health + food.HealingPower < MaxHealth ? Health + food.HealingPower : MaxHealth;
            Hunger = Hunger - food.FillingPower > 0 ? Hunger - food.FillingPower : 0;
        }
    }
}
