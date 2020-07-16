using System.Collections.Generic;

namespace Shipwreck.Model.Items
{
    interface ICraftable
    {
        public static Dictionary<string, int> RequiredItems { get; }
    }
}
