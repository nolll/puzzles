using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day01;

public class Year2019Day01 : AocPuzzle
{
    public override string Title => "The Tyranny of the Rocket Equation";

    public override PuzzleResult RunPart1()
    {
        var massCalculator = new MassCalculator(FileInput);
        return new PuzzleResult(massCalculator.MassFuel, 3_382_284);
    }

    public override PuzzleResult RunPart2()
    {
        var massCalculator = new MassCalculator(FileInput);
        return new PuzzleResult(massCalculator.TotalFuel, 5_070_541);
    }
}