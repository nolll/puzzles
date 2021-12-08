using App.Platform;

namespace App.Puzzles.Year2015.Day14
{
    public class Year2015Day14 : PuzzleDay
    {
        public override PuzzleResult RunPart1()
        {
            var race = new ReindeerRace(FileInput, 2503);
            return new PuzzleResult(race.WinningDistance, 2655);
        }

        public override PuzzleResult RunPart2()
        {
            var race = new ReindeerRace(FileInput, 2503);
            return new PuzzleResult(race.WinningScore, 1059);
        }
    }
}