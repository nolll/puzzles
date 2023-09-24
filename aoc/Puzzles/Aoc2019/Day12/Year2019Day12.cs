using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day12;

public class Year2019Day12 : AocPuzzle
{
    public override string Name => "The N-Body Problem";

    protected override PuzzleResult RunPart1()
    {
        var tracker1 = new MoonTracker(InputFile);
        const int iterations = 1000;
        tracker1.Run(iterations);

        return new PuzzleResult(tracker1.TotalEnergy, 7471);
    }

    protected override PuzzleResult RunPart2()
    {
        var tracker2 = new MoonTracker(InputFile);
        tracker2.RunUntilRepeat();

        return new PuzzleResult(tracker2.Iterations, 376_243_355_967_784);
    }
}