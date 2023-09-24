using Common.Puzzles;

namespace Aoc.Puzzles.Year2019.Day01;

public class Year2019Day01 : AocPuzzle
{
    public override string Name => "The Tyranny of the Rocket Equation";

    protected override PuzzleResult RunPart1()
    {
        var massCalculator = new MassCalculator(InputFile);
        return new PuzzleResult(massCalculator.MassFuel, 3_382_284);
    }

    protected override PuzzleResult RunPart2()
    {
        var massCalculator = new MassCalculator(InputFile);
        return new PuzzleResult(massCalculator.TotalFuel, 5_070_541);
    }
}