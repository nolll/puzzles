using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201818;

[Name("Settlers of The North Pole")]
public class Aoc201818 : AocPuzzle
{
    [Puzzle("005b4c9579d6ddb74c9a713c7859b558")]
    public int Part1(string input)
    {
        var collection = new LumberCollection(input);
        collection.Run(10);
        return collection.ResourceValue;
    }

    [Puzzle("8ca0e3bcb9441bd0e9d01aa29a11a817")]
    public int Part2(string input)
    {
        var collection2 = new LumberCollection(input);
        collection2.Run(1_000_000_000);
        return collection2.ResourceValue;
    }
}