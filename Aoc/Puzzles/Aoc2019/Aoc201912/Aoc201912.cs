﻿using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201912;

[Name("The N-Body Problem")]
public class Aoc201912(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new MoonTracker(Input);
        const int iterations = 1000;
        tracker1.Run(iterations);

        return new PuzzleResult(tracker1.TotalEnergy, "f4aa1e6262770dd457b3fc1a02f903b9");
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new MoonTracker(Input);
        tracker2.RunUntilRepeat();

        return new PuzzleResult(tracker2.Iterations, "b61b39d42360ecd83bd6094a285a4251");
    }
}