using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201514;

[Name("Reindeer Olympics")]
public class Aoc201514(string input) : AocPuzzle
{
    protected override PuzzleResult RunPart1()
    {
        var race = new ReindeerRace(input, 2503);
        return new PuzzleResult(race.WinningDistance, "730cd532676e91e7ec7210ec497bba1d");
    }

    protected override PuzzleResult RunPart2()
    {
        var race = new ReindeerRace(input, 2503);
        return new PuzzleResult(race.WinningScore, "d78ca8ddf15b143efbebe5519ac2abf1");
    }
}