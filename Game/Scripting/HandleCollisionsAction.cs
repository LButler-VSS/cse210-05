using System;
using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;
using System.Data;

namespace cse210_05.Game.Scripting
{
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;

        public HandleCollisionsAction()
        {
        }

        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        private void HandleSegmentCollisions(Cast cast)
        {
            Bike bikeOne = (Bike)cast.GetFirstActor("bikeone");
            Bike bikeTwo = (Bike)cast.GetFirstActor("biketwo");
            Trail trailOne = (Trail)cast.GetFirstActor("trailone");
            Trail trailTwo = (Trail)cast.GetFirstActor("trailtwo");
            List<Actor> wallOne = trailOne.GetWall();
            List<Actor> wallTwo = trailTwo.GetWall();
            Score scoreOne = (Score)cast.GetFirstActor("scoreone");
            Score scoreTwo = (Score)cast.GetFirstActor("scoretwo");



            foreach (Actor segment in wallOne)
            {
                if (segment.GetPosition().Equals(bikeOne.GetPosition()))
                {
                    isGameOver = true;
                    scoreTwo.AddPoints(1);
                }
                else if (segment.GetPosition().Equals(bikeTwo.GetPosition()))
                {
                    isGameOver = true;
                    scoreOne.AddPoints(1);
                }
            }
        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Bike bikeOne = (Bike)cast.GetFirstActor("bikeone");
                Bike bikeTwo = (Bike)cast.GetFirstActor("biketwo");
                Trail trailOne = (Trail)cast.GetFirstActor("trailone");
                Trail trailTwo = (Trail)cast.GetFirstActor("trailtwo");
                List<Actor> wallOne = trailOne.GetWall();
                List<Actor> wallTwo = trailTwo.GetWall();

                int x = Constants.MAX_X / 2;
                int y = Constants.MAX_Y / 2;
                Point position = new Point(x, y);

                Actor message = new Actor();
                message.SetText("Game Over!");
                message.SetPosition(position);
                cast.AddActor("messages", message);

                foreach (Actor segment in wallOne)
                {
                    segment.SetColor(Constants.WHITE);
                }
                foreach (Actor segment in wallTwo)
                {
                    segment.SetColor(Constants.WHITE);
                }
                bikeOne.SetColor(Constants.WHITE);
                bikeTwo.SetColor(Constants.WHITE);
                trailOne.SetColor(Constants.WHITE);
                trailTwo.SetColor(Constants.WHITE);
            }
        }
    }
}
