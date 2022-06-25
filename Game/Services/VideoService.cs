using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Raylib_cs;
using cse210_05.Game.Casting;

namespace cse210_05.Game.Services
{
    public class VideoService
    {
        private bool debug = false;

        public VideoService(bool debug)
        {
            this.debug = debug;
        }

        public void CloseWindow()
        {
            Raylib.CloseWindow();
        }

        public void ClearBuffer()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Raylib_cs.Color.BLACK);
            if (debug)
            {
                DrawGrid();
            }
        }

        public void DrawActor(Actor actor)
        {
            string text = actor.GetText();
            int x = actor.GetPosition().GetX();
            int y = actor.GetPosition().GetY();
            int fontSize = actor.GetFontSize();
            Casting.Color c = actor.GetColor();
            Raylib_cs.Color color = ToRaylibColor(c);
            Raylib.DrawText(text, x, y, fontSize, color);
        }

        public void DrawActors(List<Actor> actors)
        {
            foreach (Actor actor in actors)
            {
                DrawActor(actor);
            }
        }

        public void FlushBuffer()
        {
            Raylib.EndDrawing();
        }

        public bool IsWindowOpen()
        {
            return !Raylib.WindowShouldClose();
        }

        public void OpenWindow()
        {
            Raylib.InitWindow(Constants.MAX_X, Constants.MAX_Y, Constants.CAPTION);
            Raylib.SetTargetFPS(Constants.FRAME_RATE);
        }

        private void DrawGrid()
        {
            for (int x = 0; x < Constants.MAX_X; x += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(x, 0, x, Constants.MAX_Y, Raylib_cs.Color.GRAY);
            }
            for (int y = 0; y < Constants.MAX_Y; y += Constants.CELL_SIZE)
            {
                Raylib.DrawLine(0, y, Constants.MAX_Y, y, Raylib_cs.Color.GRAY);
            }
        }

        private Raylib_cs.Color ToRaylibColor(Casting.Color color)
        {
            int r = color.GetRed();
            int g = color.GetGreen();
            int b = color.GetBlue();
            int a = color.GetAlpha();
            return new Raylib_cs.Color(r, g, b, a);
        }
    }
}
