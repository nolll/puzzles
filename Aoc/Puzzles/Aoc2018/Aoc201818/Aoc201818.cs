using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201818;

public class Aoc201818 : AocPuzzle
{
    public override string Name => "Settlers of The North Pole";

    protected override PuzzleResult RunPart1()
    {
        var collection = new LumberCollection(InputFile);
        collection.Run(10);
        return new PuzzleResult(collection.ResourceValue, "005b4c9579d6ddb74c9a713c7859b558");
    }

    protected override PuzzleResult RunPart2()
    {
        var collection2 = new LumberCollection(InputFile);
        collection2.Run(1_000_000_000);
        return new PuzzleResult(collection2.ResourceValue, "8ca0e3bcb9441bd0e9d01aa29a11a817");
    }
}