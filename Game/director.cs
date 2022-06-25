using System.Collections.Generic;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;
using cse210_05.Game.Scripting;

namespace cse210_05.Game
{
    public class Director
    {
        private VideoService videoService = null;

        public Director(VideoService videoService)
        {
            this.videoService = videoService;
        }

        public void StartGame(Cast cast, Script script)
        {
            SetStartingValues(cast);

            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                ExecuteActions("input", cast, script);
                ExecuteActions("update", cast, script);
                ExecuteActions("output", cast, script);
            }
            videoService.CloseWindow();
        }

        public void SetStartingValues(Cast cast)
        {
            Bike bikeOne = (Bike)cast.GetFirstActor("bikeone");
            Bike bikeTwo = (Bike)cast.GetFirstActor("biketwo");
            Trail trailOne = (Trail)cast.GetFirstActor("trailone");
            Trail trailTwo = (Trail)cast.GetFirstActor("trailtwo");
            Score scoreTwo = (Score)cast.GetFirstActor("scoretwo");

            bikeOne.SetColor(Constants.RED);
            bikeOne.SetPosition(new Point((Constants.MAX_X / 4), Constants.MAX_Y / 2));
            bikeTwo.SetColor(Constants.GREEN);
            bikeTwo.SetPosition(new Point(Constants.MAX_X / 4 * 3, Constants.MAX_Y / 2));
            trailOne.SetColor(Constants.RED);
            trailTwo.SetColor(Constants.GREEN);
            scoreTwo.SetPosition(new Point(Constants.MAX_X / 4 * 3, 0));
        }
        private void ExecuteActions(string group, Cast cast, Script script)
        {
            List<Action> actions = script.GetActions(group);
            foreach(Action action in actions)
            {
                action.Execute(cast, script);
            }
        }
    }
}
