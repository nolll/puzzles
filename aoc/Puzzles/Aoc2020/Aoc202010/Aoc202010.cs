using Puzzles.common.Puzzles;

namespace Puzzles.aoc.Puzzles.Aoc2020.Aoc202010;

public class Aoc202010 : AocPuzzle
{
    public override string Name => "Adapter Array";

    protected override PuzzleResult RunPart1()
    {
        var chain = new PowerAdapterChain(InputFile);
        return new PuzzleResult(chain.DifferenceProduct, "56be819907a3ccd3fa53c9340c9cd2b7");
    }

    protected override PuzzleResult RunPart2()
    {
        var chain = new PowerAdapterChain(InputFile);
        var combinations = chain.GetTotalNumberOfCombinations();
        return new PuzzleResult(combinations, "791600ed80a4c8e120ae60a88193043f");
    }
}