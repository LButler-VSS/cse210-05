using System;
using System.Collections.Generic;
using System.Linq;

namespace cse210_05.Game.Casting
{
    public class Trail : Actor
    {
        private List<Actor> wall = new List<Actor>();

        public Trail()
        {

        }

        public void AddWall(Point point)
        {
            Actor segment = new Actor();
            segment.SetPosition(point);
            segment.SetText("#");
            segment.SetColor(this.GetColor());
            wall.Add(segment);
        }

        public List<Actor> GetWall()
        {
            return wall;
        }
    }
}
