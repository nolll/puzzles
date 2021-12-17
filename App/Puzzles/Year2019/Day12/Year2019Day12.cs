using App.Platform;

namespace App.Puzzles.Year2019.Day12;

public class Year2019Day12 : Puzzle
{
    public override PuzzleResult RunPart1()
    {
        var tracker1 = new MoonTracker(FileInput);
        const int iterations = 1000;
        tracker1.Run(iterations);

        return new PuzzleResult(tracker1.TotalEnergy, 7471);
    }

    public override PuzzleResult RunPart2()
    {
        var tracker2 = new MoonTracker(FileInput);
        tracker2.RunUntilRepeat();

        return new PuzzleResult(tracker2.Iterations, 376_243_355_967_784);
    }
}