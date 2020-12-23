using Core.CrabCups;

namespace ConsoleApp.Years.Year2020.Puzzles
{
    public class Day23 : Day2020
    {
        public Day23() : base(23)
        {
        }

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