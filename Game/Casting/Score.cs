using System;

namespace cse210_05.Game.Casting
{
    public class Score : Actor
    {
        private int points = 0;

        public Score()
        {
            AddPoints(0);
        }

        public void AddPoints(int points)
        {
            this.points += points;
            SetText($"Score: {this.points}");
        }
    }
}
