using Pzl.Common;
using Pzl.Tools.Computers.IntCode;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201902;

[Name("1202 Program Alarm")]
public class Aoc201902 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var computer = new ConsoleComputer(input);
        computer.Start(false, 12, 2);
        var value = computer.Result;
        return new PuzzleResult(value, "85e8cb8123555ca9bd39b2c6b962e54a");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var solutionFinder = new ComputerSolutionFinder(input);
        var result = solutionFinder.FindSolution(19690720);
        var answer = 100 * result!.Noun + result.Verb;
        return new PuzzleResult(answer, "b505e47f6dc62ca5acbbe708dd2192a5");
    }
}