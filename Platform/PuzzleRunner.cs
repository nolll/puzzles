using System;
using System.Collections.Generic;
using System.Linq;

namespace Aoc.Platform;

public class PuzzleRunner
{
    private readonly int _puzzleTimeout;

    public PuzzleRunner(int puzzleTimeout)
    {
        _puzzleTimeout = puzzleTimeout;
    }

    public void Run(IEnumerable<PuzzleDay> puzzleDays)
    {
        var enumerable = puzzleDays as PuzzleDay[] ?? puzzleDays.ToArray();
        var count = enumerable.Length;

        if(count == 0)
            throw new Exception("No puzzles found.");

        if (count == 1)
            new StandaloneSinglePuzzleRunner(enumerable.First()).Run();
        else
            new MultiPuzzleRunner(_puzzleTimeout).Run(enumerable);
    }

    public void Run(PuzzleDay puzzleDay)
    {
        Run(new List<PuzzleDay> { puzzleDay });
    }
}