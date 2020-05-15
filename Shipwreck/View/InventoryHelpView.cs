using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.View
{
    class InventoryHelpView : View
    {
        public InventoryHelpView()
            :base("\n"
                + "\n----------------------------------"
                + "\n| Inventory Help Menu"
                + "\n----------------------------------"
                + "\n C - View Item Catalog"
                + "\n X - Exit Inventory Help Menu"
                + "\n----------------------------------")
        { }

        public override bool DoAction(string value)
        {
            string menuItem = value.ToUpper();
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
            Console.WriteLine(" Spear");

            foreach (KeyValuePair<string, int> item in Spear.RequiredItems)
            {
                line = new StringBuilder("                                ");
                line.Insert(8, item.Key);
                line.Insert(24, item.Value);
                Console.WriteLine(line);
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
