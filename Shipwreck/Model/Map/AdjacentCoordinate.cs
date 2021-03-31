namespace Shipwreck.Model.Map
{
    // TODO convert to adjacent location
    public class AdjacentCoordinate
    {
        public string Direction { get; set; } // TODO should this be an enum or something?
        public int Row { get; set; }
        public int Col { get; set; }
    }
}