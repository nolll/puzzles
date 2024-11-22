using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

[Name("Transparent Origami")]
public class Aoc202113(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var paper = new TransparentPaper(input);
        var result = paper.DotCountAfterFirstFold();

        return new PuzzleResult(result, "d90cdd38e041f8d021655ac90de64e69");
    }

    protected override PuzzleResult RunPart2()
    {
        var paper = new TransparentPaper(input);
        var result = paper.MessageAfterFold();
        var letters = OcrSmallFont.ReadString(result);

        return new PuzzleResult(letters, "e96b781220e2551d8c04eaa523de4934");
    }
}