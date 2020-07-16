using System;

namespace Shipwreck.Exceptions
{
    class InventoryException : Exception
    {
        public InventoryException(string message) : base(message)
        {
        }
    }
}
