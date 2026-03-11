using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201912;

[Name("The N-Body Problem")]
public class Aoc201912 : AocPuzzle
{
    private const int Iterations = 1000;

    [Puzzle("f4aa1e6262770dd457b3fc1a02f903b9")]
    public int Part1(string input)
    {
        var tracker1 = new MoonTracker(input);
        tracker1.Run(Iterations);

        return tracker1.TotalEnergy;
    }

    [Puzzle("b61b39d42360ecd83bd6094a285a4251")]
    public long Part2(string input)
    {
        var tracker2 = new MoonTracker(input);
        tracker2.RunUntilRepeat();

        return tracker2.Iterations;
    }
}