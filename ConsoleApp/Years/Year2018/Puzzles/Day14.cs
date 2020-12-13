using System;
using Core.HotChocolate;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day14 : Day2018
    {
        public Day14() : base(14)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var generator = new RecipeGenerator();
            var scores = generator.ScoresAfter(Input);
            return new PuzzleResult(scores, "3718110721");
        }

        public override PuzzleResult RunPart2()
        {
            var generator = new RecipeGenerator();
            var count = generator.RecipeCountBefore(Input.ToString());
            return new PuzzleResult(count, 20_298_300);
        }

        private const int Input = 306281;
    }
}