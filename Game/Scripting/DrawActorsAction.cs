using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05.Game.Scripting
{
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void Execute(Cast cast, Script script)
        {
            Bike bikeOne = (Bike)cast.GetFirstActor("bikeone");
            Bike bikeTwo = (Bike)cast.GetFirstActor("biketwo");
            Trail trailOne = (Trail)cast.GetFirstActor("trailone");
            Trail trailTwo = (Trail)cast.GetFirstActor("trailtwo");
            List<Actor> wallOne = trailOne.GetWall();
            List<Actor> wallTwo = trailTwo.GetWall();
            Actor scoreOne = cast.GetFirstActor("scoreone");
            Actor scoreTwo = cast.GetFirstActor("scoretwo");
            List<Actor> messages = cast.GetActors("messages");

            trailOne.AddWall(bikeOne.GetOldPosition());
            trailTwo.AddWall(bikeTwo.GetOldPosition());

            videoService.ClearBuffer();
            videoService.DrawActors(wallOne);
            videoService.DrawActors(wallTwo);
            videoService.DrawActor(bikeOne);
            videoService.DrawActor(bikeTwo);
            videoService.DrawActor(scoreOne);
            videoService.DrawActor(scoreTwo);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}
