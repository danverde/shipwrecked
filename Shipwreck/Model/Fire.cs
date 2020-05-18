using Shipwreck.Exceptions;
using Shipwreck.Model.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shipwreck.Model
{
    class Fire
    {
        public static int BurnRate = 2;
        public bool IsBurning { get; private set; }
        public Inventory Inventory { get; }

        public Fire()
        {
            Inventory = new Inventory();
        }

        public void StartFire()
        {
            IsBurning = true;
        }

        public void ExtinguishFire()
        {
            IsBurning = false;
        }

        

        public void AddWood(int quantity)
        {

        }
    }
}
