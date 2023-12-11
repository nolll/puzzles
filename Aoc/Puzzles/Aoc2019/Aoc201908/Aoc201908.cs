using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201908;

[Name("Space Image Format")]
public class Aoc201908(string input) : AocPuzzle(input)
{
    protected override PuzzleResult RunPart1()
    {
        var image = new SpaceImage(Input);
        var checksum = image.Checksum;
        return new PuzzleResult(checksum, "f120f42ddc8c176e63cab4413a41bd99");
    }

    protected override PuzzleResult RunPart2()
    {
        var image = new SpaceImage(Input);
        var printedImage = image.Print();
        var letters = OcrSmallFont.ReadString(printedImage);
        return new PuzzleResult(letters, "a51c490e0a182d6faf996faa2205c829");
    }
}