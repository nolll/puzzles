using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

[Name("Transparent Origami")]
public class Aoc202113 : AocPuzzle
{
    [Puzzle("d90cdd38e041f8d021655ac90de64e69")]
    public int Part1(string input) => new TransparentPaper(input).DotCountAfterFirstFold();

    [Puzzle("e96b781220e2551d8c04eaa523de4934")]
    public string Part2(string input) => OcrSmallFont.ReadString(new TransparentPaper(input).MessageAfterFold());
}