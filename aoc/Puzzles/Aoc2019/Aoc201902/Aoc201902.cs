using Puzzles.common.Computers.IntCode;
using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2019.Aoc201902;

public class Aoc201902 : AocPuzzle
{
    public override string Name => "1202 Program Alarm";

    protected override PuzzleResult RunPart1()
    {
        var computer = new ConsoleComputer(InputFile);
        computer.Start(false, 12, 2);
        var value = computer.Result;
        return new PuzzleResult(value, "85e8cb8123555ca9bd39b2c6b962e54a");
    }

    protected override PuzzleResult RunPart2()
    {
        var solutionFinder = new ComputerSolutionFinder(InputFile);
        var result = solutionFinder.FindSolution(19690720);
        var answer = 100 * result!.Noun + result.Verb;
        return new PuzzleResult(answer, "b505e47f6dc62ca5acbbe708dd2192a5");
    }
}