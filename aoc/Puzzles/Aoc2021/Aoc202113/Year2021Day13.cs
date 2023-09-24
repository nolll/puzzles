using Common.Ocr;
using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2021.Aoc202113;

public class Year2021Day13 : AocPuzzle
{
    public override string Name => "Transparent Origami";

    protected override PuzzleResult RunPart1()
    {
        var paper = new TransparentPaper(InputFile);
        var result = paper.DotCountAfterFirstFold();

        return new PuzzleResult(result, 695);
    }

    protected override PuzzleResult RunPart2()
    {
        var paper = new TransparentPaper(InputFile);
        var result = paper.MessageAfterFold();
        var letters = OcrSmallFont.ReadString(result);

        return new PuzzleResult(letters, "GJZGLUPJ");
    }
}