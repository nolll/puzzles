using Common.Ocr;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2019.Aoc201908;

public class Aoc201908 : AocPuzzle
{
    public override string Name => "Space Image Format";

    protected override PuzzleResult RunPart1()
    {
        var image = new SpaceImage(InputFile);
        var checksum = image.Checksum;
        return new PuzzleResult(checksum, 1716);
    }

    protected override PuzzleResult RunPart2()
    {
        var image = new SpaceImage(InputFile);
        var printedImage = image.Print();
        var letters = OcrSmallFont.ReadString(printedImage);
        return new PuzzleResult(letters, "KFABY");
    }
}