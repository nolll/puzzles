using App.Platform;

namespace App.Puzzles.Year2018.Day04
{
    public class Year2018Day04 : Year2018Day
    {
        public override int Day => 4;

        public override PuzzleResult RunPart1()
        {
            var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
            return new PuzzleResult(guardSleepPuzzle.StrategyOneScore, 87_681);
        }

        public override PuzzleResult RunPart2()
        {
            var guardSleepPuzzle = new GuardSleepPuzzle(FileInput);
            return new PuzzleResult(guardSleepPuzzle.StrategyTwoScore, 136_461);
        }
    }
}