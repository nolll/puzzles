using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201908;

[Name("Space Image Format")]
public class Aoc201908 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var image = new SpaceImage(input);
        var checksum = image.Checksum;
        return new PuzzleResult(checksum, "f120f42ddc8c176e63cab4413a41bd99");
    }

    public PuzzleResult RunPart2(string input)
    {
        var image = new SpaceImage(input);
        var printedImage = image.Print();
        var letters = OcrSmallFont.ReadString(printedImage);
        return new PuzzleResult(letters, "a51c490e0a182d6faf996faa2205c829");
    }
}