using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201514;

[Name("Reindeer Olympics")]
public class Aoc201514 : AocPuzzle
{
    [Puzzle("730cd532676e91e7ec7210ec497bba1d")]
    public int Part1(string input) => new ReindeerRace(input, 2503).WinningDistance;

    [Puzzle("d78ca8ddf15b143efbebe5519ac2abf1")]
    public int Part2(string input) => new ReindeerRace(input, 2503).WinningScore;
}