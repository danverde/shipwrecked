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

        public bool IsTraversable => !Visited && Shipwreck.CurrentGame.Settings.EnableFow || Scene.Traversable;
        
    }
}
