namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day14
{
    public class Year2015Day14 : Year2015Day
    {
        public override int Day => 14;

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