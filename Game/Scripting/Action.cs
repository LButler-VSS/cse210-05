using System;
using cse210_05.Game.Casting;

namespace cse210_05.Game.Scripting
{
    public interface Action
    {
        void Execute(Cast cast, Script script);
    }
}
