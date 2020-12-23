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
            var result = game.Play(100);
            return new PuzzleResult(result);
        }

        private const int Input = 952316487;
    }
}