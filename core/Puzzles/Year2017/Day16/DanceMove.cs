using System.Collections.Generic;

namespace Core.Puzzles.Year2017.Day16;

public abstract class DanceMove
{
    public abstract void Execute(IDictionary<char, int> programs);
}