using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Shipwreck.Helpers;
using Shipwreck.Model.Map;

namespace Shipwreck.Control
{
    public static class MapController
    {
        public static Map LoadMapFromJson(string mapPath)
        {
            var map1Path = Path.Combine(Environment.CurrentDirectory, mapPath);
            return  FileHelper.LoadJson<Map>(map1Path);
        }

        public static Location GetPlayerLocation()
        {
            // TODO breaks single responsibility...
            var player = Shipwreck.CurrentGame.Player;
            return Shipwreck.CurrentGame.Map.Locations[player.Row, player.Col];
        }

        public static bool TryMove(Direction direction, out Location newLocation)
        {
            // TODO maybe this ought to take a current location & a new direction?
            var player = Shipwreck.CurrentGame.Player;
            var adjacentLocation =
                GetAdjacentCoordinates(GetPlayerLocation())
                    .FirstOrDefault(location => location.Direction == direction) ?? new AdjacentCoordinate();
            
            // get the new location safely
            if (!Shipwreck.CurrentGame.Map.TryGetLocation(adjacentLocation.Row, adjacentLocation.Col, out newLocation)) return false;

            // explore the new location
            newLocation.Visited = true;
            
            // if the explored location isn't traversable, quit
            if (!newLocation.IsTraversable) return false;

            // time passes
            GameController.AdvanceDays(newLocation.Scene.DaysToTraverse);
            
            // move character
            GetPlayerLocation().Characters.Remove(player);
            newLocation.Characters.Add(player);
            player.SetLocationCoordinates(newLocation);
            
            // win if necessary
            if (newLocation.Scene.Type == SceneType.Town)
            {
                GameController.WinGame();
            }
            
            return true;
        }

        public static List<Direction> GetValidMovableDirections()
        {
            var validDirections = new List<Direction>();
            var map = Shipwreck.CurrentGame.Map;
            var adjacentLocations = GetAdjacentCoordinates(GetPlayerLocation());

            foreach (var adjacentLocation in adjacentLocations)
            {
                if (map.TryGetLocation(adjacentLocation.Row, adjacentLocation.Col, out var location) && location.IsTraversable) validDirections.Add(adjacentLocation.Direction);
            }
            
            return validDirections;
        }

        public static bool TryExploreAdjacentLocations(Map map, Location location)
        {
            if (map == null || location == null) return false;
            
            var adjacentCoordinates = GetAdjacentCoordinates(location);
            foreach (var adjacentCoordinate in adjacentCoordinates)
            {
                map.Locations[adjacentCoordinate.Row, adjacentCoordinate.Col].Visited = true;
            }

            return true;
        }
        
        public static List<AdjacentCoordinate> GetAdjacentCoordinates(Location location)
        {
            return new List<AdjacentCoordinate>
            {
                new AdjacentCoordinate { Direction = Direction.North, Row = location.Row - 1, Col = location.Col},
                new AdjacentCoordinate { Direction = Direction.East, Row = location.Row, Col = location.Col + 1},
                new AdjacentCoordinate { Direction = Direction.South, Row = location.Row + 1, Col = location.Col},
                new AdjacentCoordinate { Direction = Direction.West, Row = location.Row, Col = location.Col - 1},
            };
        }
    }
}