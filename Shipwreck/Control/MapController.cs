using System;
using Shipwreck.Helpers;
using Shipwreck.Model.Map;

namespace Shipwreck.Control
{
    public static class MapController
    {
        public static Map LoadMap1()
        {
            return  JsonLoader.LoadJson<Map>("Data/Maps/map1.json");
        }

        public static void Move()
        {
            throw new NotImplementedException();
            // TODO remember to update location characters list & players location
        }
    }
}