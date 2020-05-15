using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model.Items
{
    interface ICraftable
    {
        public static Dictionary<string, int> RequiredItems { get; }
    }
}
