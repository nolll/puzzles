using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2018.Day18;

public class Year2018Day18 : AocPuzzle
{
    public override string Name => "Settlers of The North Pole";

    public override PuzzleResult RunPart1()
    {
        var collection = new LumberCollection(FileInput);
        collection.Run(10);
        return new PuzzleResult(collection.ResourceValue, 763_804);
    }

    public override PuzzleResult RunPart2()
    {
        var collection2 = new LumberCollection(FileInput);
        collection2.Run(1_000_000_000);
        return new PuzzleResult(collection2.ResourceValue, 188_400);
    }
}