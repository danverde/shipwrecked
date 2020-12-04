using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class ArmorFactory
    {
        public Armor GetArmor(ArmorType armorType)
        {
            Armor armor = null;
        
            switch (armorType)
            {
                case ArmorType.Suit:
                    armor = new Armor
                    {
                        Name = "Suit",
                        Description = "A once fine suit",
                        Droppable = true,
                        DefensePower = 0
                    };
                    break;
                case ArmorType.LeatherJacket:
                    armor = new Armor
                    {
                        Name = "Leather Jacket",
                        Description = "Old motorcycle jacket",
                        Droppable = true,
                        DefensePower = 2
                    };
                    break;
            }
        
            return armor;
        }
    }
}
