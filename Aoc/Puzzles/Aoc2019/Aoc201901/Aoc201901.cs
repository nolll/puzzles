using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201901;

[Name("The Tyranny of the Rocket Equation")]
public class Aoc201901(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var massCalculator = new MassCalculator(Input);
        return new PuzzleResult(massCalculator.MassFuel, "863ba725f4b926c82a67e448dbacc8ca");
    }

    protected override PuzzleResult RunPart2()
    {
        var massCalculator = new MassCalculator(Input);
        return new PuzzleResult(massCalculator.TotalFuel, "9a6de12a9f00b9360ead07efc0249b8c");
    }
}