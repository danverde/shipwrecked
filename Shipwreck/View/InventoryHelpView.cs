using System;
using System.Text;

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
                      + "\n X - Exit Inventory Help Menu"
                      + "\n----------------------------------";
        }

        protected override bool HandleInput(string menuItem)
        {
            switch (menuItem)
            {
            }

            return false;
        }
    }
}
