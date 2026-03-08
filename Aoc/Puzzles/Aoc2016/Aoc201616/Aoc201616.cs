using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201616;

[Name("Dragon Checksum")]
public class Aoc201616 : AocPuzzle
{
    [Puzzle("14684ecac7686be656974d19fb659532")]
    public string Part1(string input) => new DragonCurve().Run(input, 272);

    [Puzzle("e5cc9c18ff1145ba041c85c6de72c9e2")]
    public string Part2(string input) => new DragonCurve().Run(input, 35651584);
}