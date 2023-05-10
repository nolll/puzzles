using Aoc.Common.Hashing;
using Aoc.Platform;

namespace Aoc.Puzzles.Year2017.Day10;

public class Year2017Day10 : Puzzle
{
    public override string Title => "Knot Hash";

    public override PuzzleResult RunPart1()
    {
        var intHasher = new IntKnotHasher(FileInput);
        return new PuzzleResult(intHasher.Checksum, 2928);
    }

    public override PuzzleResult RunPart2()
    {
        var asciiHasher = new AsciiKnotHasher(FileInput);
        return new PuzzleResult(asciiHasher.Hash, "0c2f794b2eb555f7830766bf8fb65a16");
    }
}