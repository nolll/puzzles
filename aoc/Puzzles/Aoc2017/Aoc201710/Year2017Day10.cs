using Common.Hashing;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2017.Day10;

public class Year2017Day10 : AocPuzzle
{
    public override string Name => "Knot Hash";

    protected override PuzzleResult RunPart1()
    {
        var intHasher = new IntKnotHasher(InputFile);
        return new PuzzleResult(intHasher.Checksum, 2928);
    }

    protected override PuzzleResult RunPart2()
    {
        var asciiHasher = new AsciiKnotHasher(InputFile);
        return new PuzzleResult(asciiHasher.Hash, "0c2f794b2eb555f7830766bf8fb65a16");
    }
}