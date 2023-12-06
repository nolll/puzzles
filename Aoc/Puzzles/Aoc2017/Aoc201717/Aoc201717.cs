using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201717;

public class Aoc201717 : AocPuzzle
{
    public override string Name => "Spinlock";

    protected override PuzzleResult RunPart1()
    {
        var runner1 = new SpinlockRunnerPart1(Input);
        runner1.Run(2017);
        return new PuzzleResult(runner1.NextValue, "ddce3b9888bd1dd2364ae8ba030b674f");
    }

    protected override PuzzleResult RunPart2()
    {
        var runner2 = new SpinlockRunnerPart2(Input);
        runner2.Run(50_000_000);
        return new PuzzleResult(runner2.SecondValue, "9d9ce3fec64cbea9caf918562df54fe4");
    }

    private const int Input = 370;
}