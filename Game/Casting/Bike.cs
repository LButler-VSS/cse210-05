using System;

namespace cse210_05.Game.Casting
{
    public class Bike : Actor
    {
        private Point oldPosition = new Point(0,0);
        public Bike()
        {
            SetVelocity(new Point(1 * Constants.CELL_SIZE, 0));
        }
        public void SetOldPosition()
        {
            oldPosition = GetPosition();
        }

        public Point GetOldPosition()
        {
            return oldPosition;
        }

        public void Turn(Point direction)
        {
            SetVelocity(direction);
        }
    }
}
