using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201912;

[Name("The N-Body Problem")]
public class Aoc201912 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var tracker1 = new MoonTracker(input);
        const int iterations = 1000;
        tracker1.Run(iterations);

        return new PuzzleResult(tracker1.TotalEnergy, "f4aa1e6262770dd457b3fc1a02f903b9");
    }

    public PuzzleResult RunPart2(string input)
    {
        var tracker2 = new MoonTracker(input);
        tracker2.RunUntilRepeat();

        return new PuzzleResult(tracker2.Iterations, "b61b39d42360ecd83bd6094a285a4251");
    }
}