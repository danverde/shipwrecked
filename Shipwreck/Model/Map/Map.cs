using System.Collections.Generic;

namespace Shipwreck.Model.Map
{
    public class Map
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public int StartingRow { get; set; }
        public int StartingCol { get; set; }
        public Location[,] Locations { get; set; }
        

        // public Map(int numRows, int numCols)
        // {
        //     NumRows = numRows;
        //     NumCols = numCols;
        //     
        //     Locations = new Location[numRows, numCols];
        //     
        //     for (var row = 0; row < numRows; row++){
        //         for (var col = 0; col < numCols; col++)
        //         {
        //             var location = new Location(row, col);
        //             Locations[row, col] = location;
        //         }
        //     }
        // }
    }
}