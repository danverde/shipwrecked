using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;
using Shipwreck.Model.Items.Weapons;

namespace Shipwreck.View
{
    class InventoryHelpView : View
    {
        public InventoryHelpView(bool inGameView = false)
        {
            InGameView = inGameView;
            Message = "\n"
                      + "\n----------------------------------"
                      + "\n| Inventory Help Menu"
                      + "\n----------------------------------"
                      + "\n C - View Item Catalog"
                      + "\n X - Exit Inventory Help Menu"
                      + "\n----------------------------------";
        }

        protected override bool HandleInput(string menuItem)
        {
            switch (menuItem)
            {
                case "C":
                    ShowItemCatalog();
                    break;
            }

            return false;
        }

        private void ShowItemCatalog()
        {
            StringBuilder line;
            Console.WriteLine("\n---------------------------\n Item Catalog:\n---------------------------");

            line = new StringBuilder("                            ");
            line.Insert(1, "ITEM");
            line.Insert(8, "MATERIALS");
            line.Insert(24, "QTY");
            Console.WriteLine(line);

            // for each weapon
            var itemTypes = new List<Type> { typeof(Spear) };
            
            foreach(var type in itemTypes)
            {
                // TODO YIKES!
                var requiredItems = (Dictionary<string, int>)type.GetProperty("RequiredItems").GetValue(null, null);
            
                Console.WriteLine($" {type.Name}");

                foreach (var item in requiredItems)
                {
                    line = new StringBuilder("                                ");
                    line.Insert(8, item.Key);
                    line.Insert(24, item.Value);
                    Console.WriteLine(line);
                }
            }

            Continue();
        }
    }
}
