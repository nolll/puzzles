using Core.PuzzleClasses;

namespace ConsoleApp.Puzzles.Year2018.Day09
{
    public class Year2018Day09 : Year2018Day
    {
        public override int Day => 9;

        public override PuzzleResult RunPart1()
        {
            var game = MarbleGame.Parse(FileInput);
            return new PuzzleResult(game.WinnerScore, 434_674);
        }

        public override PuzzleResult RunPart2()
        {
            var game2 = MarbleGame.Parse(FileInput, 100);
            return new PuzzleResult(game2.WinnerScore, 3_653_994_575);
        }
    }
}