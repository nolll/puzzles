using Aoc.Platform;
using common.Ocr;
using common.Puzzles;

namespace Aoc.Puzzles.Year2021.Day13;

public class Year2021Day13 : AocPuzzle
{
    public override string Title => "Transparent Origami";

    public override PuzzleResult RunPart1()
    {
        var paper = new TransparentPaper(FileInput);
        var result = paper.DotCountAfterFirstFold();

        return new PuzzleResult(result, 695);
    }

    public override PuzzleResult RunPart2()
    {
        var paper = new TransparentPaper(FileInput);
        var result = paper.MessageAfterFold();
        var letters = OcrSmallFont.ReadString(result);

        return new PuzzleResult(letters, "GJZGLUPJ");
    }
}