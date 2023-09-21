using Aoc.Platform;
using common.Ocr;

namespace Aoc.Puzzles.Year2019.Day08;

public class Year2019Day08 : Puzzle
{
    public override string Title => "Space Image Format";

    public override PuzzleResult RunPart1()
    {
        var image = new SpaceImage(FileInput);
        var checksum = image.Checksum;
        return new PuzzleResult(checksum, 1716);
    }

    public override PuzzleResult RunPart2()
    {
        var image = new SpaceImage(FileInput);
        var printedImage = image.Print();
        var letters = OcrSmallFont.ReadString(printedImage);
        return new PuzzleResult(letters, "KFABY");
    }
}