using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Exceptions
{
    class InventoryException : Exception
    {
        public InventoryException(string message) : base(message)
        {
        }
    }
}
