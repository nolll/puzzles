using Pzl.Tools.Ocr;
using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

public class Aoc202113 : AocPuzzle
{
    public override string Name => "Transparent Origami";

    protected override PuzzleResult RunPart1()
    {
        var paper = new TransparentPaper(InputFile);
        var result = paper.DotCountAfterFirstFold();

        return new PuzzleResult(result, "d90cdd38e041f8d021655ac90de64e69");
    }

    protected override PuzzleResult RunPart2()
    {
        var paper = new TransparentPaper(InputFile);
        var result = paper.MessageAfterFold();
        var letters = OcrSmallFont.ReadString(result);

        return new PuzzleResult(letters, "e96b781220e2551d8c04eaa523de4934");
    }
}