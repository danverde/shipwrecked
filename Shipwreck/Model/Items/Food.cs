using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    class Food : IItem
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public bool Droppable { get; private set; }
        public int HealingPower { get; }
        public int FillingPower { get;  }

        public Food(string name, string description, int healingPower, int fillingPower, bool droppable = true)
        {
            Name = name;
            Description = description;
            Droppable = droppable;
            HealingPower = healingPower;
            FillingPower = fillingPower;
        }
    }
}
