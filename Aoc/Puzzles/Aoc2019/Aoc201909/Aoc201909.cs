using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201909;

[Name("Sensor Boost")]
public class Aoc201909 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var boostTester = new BoostRunner(input, 1);
        var testerResult = boostTester.Run();

        return new PuzzleResult(testerResult.LastOutput, "d7f50f8a7d7941f1943aebc443a86484");
    }

    public PuzzleResult RunPart2(string input)
    {
        var boostRunner = new BoostRunner(input, 2);
        var runnerResult = boostRunner.Run();

        return new PuzzleResult(runnerResult.LastOutput, "336de8801a44e745a6f69e2c6dc0d4a3");
    }
}