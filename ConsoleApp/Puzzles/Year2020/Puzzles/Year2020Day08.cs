using Core.HandheldGameConsole;

namespace ConsoleApp.Puzzles.Year2020.Puzzles
{
    public class Year2020Day08 : Year2020Day
    {
        public override int Day => 8;

        public override PuzzleResult RunPart1()
        {
            var console = new GameConsoleRunner(FileInput);
            var acc = console.RunUntilLoop();
            return new PuzzleResult(acc, 1446);
        }

        public override PuzzleResult RunPart2()
        {
            var console = new GameConsoleRunner(FileInput);
            var acc = console.RunUntilTermination();
            return new PuzzleResult(acc, 1403);
        }
    }
}