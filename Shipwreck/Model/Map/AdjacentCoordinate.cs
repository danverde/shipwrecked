namespace Shipwreck.Model.Map
{
    // TODO convert to adjacent location?
    public class AdjacentCoordinate
    {
        public Direction Direction { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
    }
}