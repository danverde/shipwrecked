using Shipwreck.Model.Items;

namespace Shipwreck.Model.Factories
{
    class ArmorFactory
    {
        public Armor GetArmor(Armor.Type type)
        {
            Armor armor = null;

            switch (type)
            {
                case Armor.Type.Suit:
                    armor = new Armor("Suit", "A once fine suit", type, 0);
                    break;
                case Armor.Type.LeatherJacket:
                    armor = new Armor("Leather Jacket", " Old motorcycle jacket", type, 2);
                    break;
            }

            return armor;
        }
    }
}
