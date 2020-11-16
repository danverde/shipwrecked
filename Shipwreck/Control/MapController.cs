using System.Collections.Generic;
using System.Linq;
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

        public static List<AdjacentCoordinate> GetAdjacentCoordinates()
        {
            var currentLocation = Shipwreck.CurrentGame.Player.CurrentLocation;
            return new List<AdjacentCoordinate>
            {
                new AdjacentCoordinate { Direction = "N", Row = currentLocation.Row - 1, Col = currentLocation.Col},
                new AdjacentCoordinate { Direction = "E", Row = currentLocation.Row, Col = currentLocation.Col + 1},
                new AdjacentCoordinate { Direction = "S", Row = currentLocation.Row + 1, Col = currentLocation.Col},
                new AdjacentCoordinate { Direction = "W", Row = currentLocation.Row, Col = currentLocation.Col - 1},
            };
        }

        public static bool TryMove(string direction, out Location newLocation)
        {
            var adjacentLocation = GetAdjacentCoordinates().FirstOrDefault(location => location.Direction == direction) ?? new AdjacentCoordinate();
            
            // get the new location safely
            if (!Shipwreck.CurrentGame.Map.TryGetLocation(adjacentLocation.Row, adjacentLocation.Col, out newLocation)) return false;

            // explore the new location
            newLocation.Visited = true;
            
            // if the explored location isn't traversable, quit
            if (!newLocation.IsTraversable) return false;

            // time passes
            GameController.AdvanceDays(newLocation.Scene.DaysToTraverse);
            
            // move character
            Shipwreck.CurrentGame.Player.CurrentLocation.Characters.Remove(Shipwreck.CurrentGame.Player);
            newLocation.Characters.Add(Shipwreck.CurrentGame.Player);
            Shipwreck.CurrentGame.Player.CurrentLocation = newLocation;
            
            return true;
        }

        public static List<string> GetValidMovableDirections()
        {
            var validDirections = new List<string>();
            var map = Shipwreck.CurrentGame.Map;
            var adjacentLocations = GetAdjacentCoordinates();

            foreach (var adjacentLocation in adjacentLocations)
            {
                if (map.TryGetLocation(adjacentLocation.Row, adjacentLocation.Col, out var location) && location.IsTraversable) validDirections.Add(adjacentLocation.Direction);
            }
            
            return validDirections;
        }
    }
}