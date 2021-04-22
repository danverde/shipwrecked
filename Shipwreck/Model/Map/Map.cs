namespace Shipwreck.Model.Map
{
    public class Map
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public int StartingRow { get; set; }
        public int StartingCol { get; set; }
        public Location[,] Locations { get; set; }
    }
}