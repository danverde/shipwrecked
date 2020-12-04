using System;

namespace Shipwreck.Exceptions
{
    class InventoryRecordNotFoundException : Exception
    {
        public InventoryRecordNotFoundException(string message) : base(message)
        {
        }
    }
}
