using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201616;

[Name("Dragon Checksum")]
public class Aoc201616 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(input, 272);
        return new PuzzleResult(checksum, "14684ecac7686be656974d19fb659532");
    }

    public PuzzleResult RunPart2(string input)
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(input, 35651584);
        return new PuzzleResult(checksum, "e5cc9c18ff1145ba041c85c6de72c9e2");
    }
}