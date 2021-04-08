using System;
using Shipwreck.Control;
using Shipwreck.Model.Game;
using Shipwreck.Model.Items;

namespace Shipwreck.View
{
    public abstract class View
    {
        protected virtual string Message => "";
        public virtual bool InGameView { get; set; }

        public void Display()
        {
            var closeView = false;
            while(closeView == false && (!InGameView || Shipwreck.CurrentGame.Status != GameStatus.Over))
            {
                closeView = true;
                Console.WriteLine(Message);
                var input = GetInput();
                if (input != "X")
                {
                    closeView = HandleInput(input);
                }
            }
        }

        protected virtual string GetInput()
        {
            var input = Console.ReadLine();

            input = FormatInput(input);
            
            return input;
        }

        protected string FormatInput(string input)
        {
            return input?.ToUpper() ?? "";
        }

        protected abstract bool HandleInput(string input);

        /* Helpers */
        
        protected void Continue()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
        
        protected static int GetQuantity(string message)
        {
            var valid = false;
            var quantity = 0;
            do
            {
                Console.WriteLine(message);
                var stringQuantity = Console.ReadLine();
                if (stringQuantity?.ToLower() == "x") continue;
                if (!int.TryParse(stringQuantity, out quantity)) continue;
                valid = true;

            } while (!valid);

            return quantity;
        }
        protected static int GetQuantity(string message, int maxQuantity)
        {
            var quantity = GetQuantity(message);
            return quantity > maxQuantity ? maxQuantity : quantity;
        }

        protected static Item GetInventoryItem(string message)
        {
            var inventory = Shipwreck.CurrentGame.Player.Inventory;
            Console.WriteLine(message);
            var itemName = Console.ReadLine();

            return InventoryController.GetItemFromInventory(inventory, itemName);
        }
    }
}
