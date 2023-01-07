using Core.Common.Computers.IntCode;
using Core.Platform;

namespace Core.Puzzles.Year2019.Day02;

public class Year2019Day02 : Puzzle
{
    public override string Title => "1202 Program Alarm";

    public override PuzzleResult RunPart1()
    {
        var computer = new ConsoleComputer(FileInput);
        computer.Start(false, 12, 2);
        var value = computer.Result;
        return new PuzzleResult(value, 3_101_844);
    }

    public override PuzzleResult RunPart2()
    {
        var solutionFinder = new ComputerSolutionFinder(FileInput);
        var result = solutionFinder.FindSolution(19690720);
        var answer = 100 * result.Noun + result.Verb;
        return new PuzzleResult(answer, 8478);
    }
}