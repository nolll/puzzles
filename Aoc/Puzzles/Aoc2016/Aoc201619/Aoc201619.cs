using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201619;

[Name("An Elephant Named Joseph")]
public class Aoc201619 : AocPuzzle
{
    [Puzzle("0ff6e8f1eb200db98926c54e1a1fac6a")]
    public int Part1(string input) => new WhiteElephantParty(int.Parse(input)).StealFromNextElf();

    [Puzzle("b67fd31a59ecdb3e94d0fbdfc778e61f")]
    public int Part2(string input) => new WhiteElephantParty(int.Parse(input)).StealFromElfAcrossCircle();
}