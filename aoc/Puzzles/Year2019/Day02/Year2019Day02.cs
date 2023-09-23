using Common.Computers.IntCode;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day02;

public class Year2019Day02 : AocPuzzle
{
    public override string Name => "1202 Program Alarm";

    protected override PuzzleResult RunPart1()
    {
        var computer = new ConsoleComputer(InputFile);
        computer.Start(false, 12, 2);
        var value = computer.Result;
        return new PuzzleResult(value, 3_101_844);
    }

    protected override PuzzleResult RunPart2()
    {
        var solutionFinder = new ComputerSolutionFinder(InputFile);
        var result = solutionFinder.FindSolution(19690720);
        var answer = 100 * result!.Noun + result.Verb;
        return new PuzzleResult(answer, 8478);
    }
}