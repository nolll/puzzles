using Puzzles.Common.Puzzles;

namespace Puzzles.Aoc.Puzzles.Aoc2015.Aoc201514;

public class Aoc201514 : AocPuzzle
{
    public override string Name => "Reindeer Olympics";

    protected override PuzzleResult RunPart1()
    {
        var race = new ReindeerRace(InputFile, 2503);
        return new PuzzleResult(race.WinningDistance, "730cd532676e91e7ec7210ec497bba1d");
    }

    protected override PuzzleResult RunPart2()
    {
        var race = new ReindeerRace(InputFile, 2503);
        return new PuzzleResult(race.WinningScore, "d78ca8ddf15b143efbebe5519ac2abf1");
    }
}