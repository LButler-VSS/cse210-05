using System;
using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class MoveActorsAction : Action
    {
        public MoveActorsAction()
        {
        }

        public void Execute(Cast cast, Script script)
        {
            List<Actor> actors = cast.GetAllActors();
            Bike bikeOne = (Bike)cast.GetFirstActor("bikeone");
            Bike bikeTwo = (Bike)cast.GetFirstActor("biketwo");
            Trail trailOne = (Trail)cast.GetFirstActor("trailone");
            Trail trailTwo = (Trail)cast.GetFirstActor("trailtwo");

            bikeOne.SetOldPosition();
            bikeTwo.SetOldPosition();

            foreach (Actor actor in actors)
            {
                actor.MoveNext();
            }
        }
    }
}
