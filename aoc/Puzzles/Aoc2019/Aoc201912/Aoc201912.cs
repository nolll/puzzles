using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201912;

public class Aoc201912 : AocPuzzle
{
    public override string Name => "The N-Body Problem";

    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new MoonTracker(InputFile);
        const int iterations = 1000;
        tracker1.Run(iterations);

        return new PuzzleResult(tracker1.TotalEnergy, "f4aa1e6262770dd457b3fc1a02f903b9");
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new MoonTracker(InputFile);
        tracker2.RunUntilRepeat();

        return new PuzzleResult(tracker2.Iterations, "b61b39d42360ecd83bd6094a285a4251");
    }
}