using Aoc.Platform;
using Common.Puzzles;

namespace Aoc.Puzzles.Year2015.Day14;

public class Year2015Day14 : AocPuzzle
{
    public override string Name => "Reindeer Olympics";

    protected override PuzzleResult RunPart1()
    {
        var race = new ReindeerRace(FileInput, 2503);
        return new PuzzleResult(race.WinningDistance, 2655);
    }

    protected override PuzzleResult RunPart2()
    {
        var race = new ReindeerRace(FileInput, 2503);
        return new PuzzleResult(race.WinningScore, 1059);
    }
}