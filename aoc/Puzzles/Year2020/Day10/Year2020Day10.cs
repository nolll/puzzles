using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2020.Day10;

public class Year2020Day10 : AocPuzzle
{
    public override string Name => "Adapter Array";

    protected override PuzzleResult RunPart1()
    {
        var chain = new PowerAdapterChain(FileInput);
        return new PuzzleResult(chain.DifferenceProduct, 2590);
    }

    protected override PuzzleResult RunPart2()
    {
        var chain = new PowerAdapterChain(FileInput);
        var combinations = chain.GetTotalNumberOfCombinations();
        return new PuzzleResult(combinations, 226_775_649_501_184);
    }
}