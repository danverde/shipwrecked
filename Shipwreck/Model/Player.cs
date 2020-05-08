using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Player : Character
    {
        public int Hunger { get; set; }
        public Player(string name, int hunger = 0)
            :base(name)
        {
            Hunger = hunger;
        }

        // should this be in a controller?
        public void Eat(Food food)
        {
            Health = Health + food.HealingPower < MaxHealth ? Health + food.HealingPower : MaxHealth;
            Hunger = Hunger - food.FillingPower > 0 ? Hunger - food.FillingPower : 0;
        }

    }
}
