using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201616;

public class Year2016Day16 : AocPuzzle
{
    public override string Name => "Dragon Checksum";

    protected override PuzzleResult RunPart1()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 272);
        return new PuzzleResult(checksum, "10010010110011010");
    }

    protected override PuzzleResult RunPart2()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 35651584);
        return new PuzzleResult(checksum, "01010100101011100");
    }

    private const string Input = "01000100010010111";
}