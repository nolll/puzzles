using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

[Name("Transparent Origami")]
public class Aoc202113 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var paper = new TransparentPaper(input);
        var result = paper.DotCountAfterFirstFold();

        return new PuzzleResult(result, "d90cdd38e041f8d021655ac90de64e69");
    }

    public PuzzleResult RunPart2(string input)
    {
        var paper = new TransparentPaper(input);
        var result = paper.MessageAfterFold();
        var letters = OcrSmallFont.ReadString(result);

        return new PuzzleResult(letters, "e96b781220e2551d8c04eaa523de4934");
    }
}