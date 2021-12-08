using System.Collections.Generic;

namespace App.Puzzles.Year2017.Day16
{
    public abstract class DanceMove
    {
        public abstract void Execute(IDictionary<char, int> programs);
    }
}