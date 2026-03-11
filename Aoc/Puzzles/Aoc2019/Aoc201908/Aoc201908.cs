using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201908;

[Name("Space Image Format")]
public class Aoc201908 : AocPuzzle
{
    [Puzzle("f120f42ddc8c176e63cab4413a41bd99")]
    public int Part1(string input) => new SpaceImage(input).Checksum;

    [Puzzle("a51c490e0a182d6faf996faa2205c829")]
    public string Part2(string input) => OcrSmallFont.ReadString(new SpaceImage(input).Print());
}