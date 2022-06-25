using System;
using cse210_05.Game;
using cse210_05.Game.Scripting;
using cse210_05.Game.Casting;
using cse210_05.Game.Services;

namespace cse210_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Cast cast = new Cast();
            
            

            cast.AddActor("bikeone", new Bike());
            cast.AddActor("biketwo", new Bike());
            cast.AddActor("trailone", new Trail());
            cast.AddActor("trailtwo", new Trail());
            cast.AddActor("scoreone", new Score());
            cast.AddActor("scoretwo", new Score());


            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);

            Script script = new Script();
            script.AddAction("input", new ControlOneAction(keyboardService));
            script.AddAction("input", new ControlTwoAction(keyboardService));
            script.AddAction("update", new MoveActorsAction());
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("output", new DrawActorsAction(videoService));

            Director director = new Director(videoService);
            director.StartGame(cast, script);

        }
    }
}
