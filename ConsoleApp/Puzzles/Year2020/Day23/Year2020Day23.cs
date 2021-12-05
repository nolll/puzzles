using Core.CrabCups;

namespace ConsoleApp.Puzzles.Year2020.Day23
{
    public class Year2020Day23 : Year2020Day
    {
        public override int Day => 23;

        public override PuzzleResult RunPart1()
        {
            var game = new CrabCupsGame(Input);
            game.Play(100);
            return new PuzzleResult(game.ResultString, "25398647");
        }

        public override PuzzleResult RunPart2()
        {
            var game = new CrabCupsGame(Input, true);
            game.Play(10_000_000);
            return new PuzzleResult(game.ResultProduct, 363_807_398_885);
        }

        private const int Input = 952316487;
    }
}