﻿using Shipwreck.Exceptions;
using Shipwreck.Model.Factories;
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
            try 
            {
                Resource match = Shipwreck.ResourceFactory.GetResource(Resource.Type.Match);
                Inventory.RemoveItems(match, 1, true);
                IsBurning = true;
            }
            catch(InventoryException e)
            {
                throw (e);
            }
        }

        public void ExtinguishFire()
        {
            IsBurning = false;
        }

        public void AddWood(int quantity)
        {
            if (quantity == 0)
            {
                return;
            }
            ResourceFactory resourceFactory = new ResourceFactory();
            Resource wood = resourceFactory.GetResource(Resource.Type.Branch);
            Inventory.AddItem(wood, quantity);
        }
    }
}
