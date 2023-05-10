using System.Collections.Generic;
using System.Linq;

namespace Aoc.Puzzles.Year2017.Day16;

public class SpinMove : DanceMove
{
    private readonly int _itemsToMove;

    public SpinMove(string command)
    {
        _itemsToMove = int.Parse(command.Substring(1));
    }

    public override void Execute(IDictionary<char, int> programs)
    {
        var programCount = programs.Count;
        var keys = programs.Keys.ToList();
        foreach (var key in keys)
        {
            var pos = programs[key];
            var newPos = pos + _itemsToMove;
            if (newPos > programCount - 1)
                newPos -= programCount;
            programs[key] = newPos;
        }
    }
}