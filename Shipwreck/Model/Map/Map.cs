using System;

namespace Shipwreck.Model.Map
{
    public class Map
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public int StartingRow { get; set; }
        public int StartingCol { get; set; }
        public Location[,] Locations { get; set; }
        
        public bool TryGetLocation(int row, int col, out Location location)
        {
            var validLocation = true;
            location = new Location();
            try
            {
                validLocation = Locations[row, col] != null;
                if (validLocation) location = Locations[row, col];
            }
            catch (Exception ex)
            {
                validLocation = false;
            }

            return validLocation;
        }
    }
}