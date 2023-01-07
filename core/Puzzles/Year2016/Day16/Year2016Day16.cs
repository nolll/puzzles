using Core.Platform;

namespace Core.Puzzles.Year2016.Day16;

public class Year2016Day16 : Puzzle
{
    public override string Title => "Dragon Checksum";

    public override PuzzleResult RunPart1()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 272);
        return new PuzzleResult(checksum, "10010010110011010");
    }

    public override PuzzleResult RunPart2()
    {
        var dragonCurve = new DragonCurve();
        var checksum = dragonCurve.Run(Input, 35651584);
        return new PuzzleResult(checksum, "01010100101011100");
    }

    private const string Input = "01000100010010111";
}