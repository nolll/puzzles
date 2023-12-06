using Puzzles.Common.Computers.IntCode;
using Puzzles.Common.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201909;

public class Aoc201909 : AocPuzzle
{
    public override string Name => "Sensor Boost";

    protected override PuzzleResult RunPart1()
    {
        var boostTester = new BoostRunner(InputFile, 1);
        var testerResult = boostTester.Run();

        return new PuzzleResult(testerResult.LastOutput, "d7f50f8a7d7941f1943aebc443a86484");
    }

    protected override PuzzleResult RunPart2()
    {
        var boostRunner = new BoostRunner(InputFile, 2);
        var runnerResult = boostRunner.Run();

        return new PuzzleResult(runnerResult.LastOutput, "336de8801a44e745a6f69e2c6dc0d4a3");
    }
}