using System.Collections.Generic;

namespace Shipwreck.Model.Map
{
    public class Location
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public bool Visited { get; set; }
        public Scene Scene { get; set; }
        public List<Character.Character> Characters { get; set; }

        public Location(int row, int col, bool visited = false)
        {
            Row = row;
            Col = col;
            Visited = visited;
            Characters = new List<Character.Character>();

        }
    }
}
