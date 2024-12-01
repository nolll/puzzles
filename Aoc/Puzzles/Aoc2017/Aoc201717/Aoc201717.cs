using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201717;

[Name("Spinlock")]
public class Aoc201717 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var runner1 = new SpinlockRunnerPart1(int.Parse(input));
        runner1.Run(2017);
        return new PuzzleResult(runner1.NextValue, "ddce3b9888bd1dd2364ae8ba030b674f");
    }

    public PuzzleResult RunPart2(string input)
    {
        var runner2 = new SpinlockRunnerPart2(int.Parse(input));
        runner2.Run(50_000_000);
        return new PuzzleResult(runner2.SecondValue, "9d9ce3fec64cbea9caf918562df54fe4");
    }
}