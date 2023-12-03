using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2016.Aoc201616;

public class Aoc201616 : AocPuzzle
{
    public override string Name => "Dragon Checksum";

    protected override PuzzleResult RunPart1()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 272);
        return new PuzzleResult(checksum, "14684ecac7686be656974d19fb659532");
    }

    protected override PuzzleResult RunPart2()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 35651584);
        return new PuzzleResult(checksum, "e5cc9c18ff1145ba041c85c6de72c9e2");
    }

    private const string Input = "01000100010010111";
}