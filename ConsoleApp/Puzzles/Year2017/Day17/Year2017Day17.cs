namespace ConsoleApp.Puzzles.Year2017.Day17
{
    public class Year2017Day17 : Year2017Day
    {
        public override int Day => 17;

        public override PuzzleResult RunPart1()
        {
            var runner1 = new SpinlockRunnerPart1(Input);
            runner1.Run(2017);
            return new PuzzleResult(runner1.NextValue, 1244);
        }

        public override PuzzleResult RunPart2()
        {
            var runner2 = new SpinlockRunnerPart2(Input);
            runner2.Run(50_000_000);
            return new PuzzleResult(runner2.SecondValue, 11_162_912);
        }

        private const int Input = 370;
    }
}