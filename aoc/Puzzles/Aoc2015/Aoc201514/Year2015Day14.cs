using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2015.Aoc201514;

public class Year2015Day14 : AocPuzzle
{
    public override string Name => "Reindeer Olympics";

    protected override PuzzleResult RunPart1()
    {
        var race = new ReindeerRace(InputFile, 2503);
        return new PuzzleResult(race.WinningDistance, 2655);
    }

    protected override PuzzleResult RunPart2()
    {
        var race = new ReindeerRace(InputFile, 2503);
        return new PuzzleResult(race.WinningScore, 1059);
    }
}