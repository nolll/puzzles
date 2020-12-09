using System;
using Core.HotChocolate;

namespace ConsoleApp.Years.Year2018.Puzzles
{
    public class Day14 : Day2018
    {
        public Day14() : base(14)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var generator = new RecipeGenerator();
            var scores = generator.ScoresAfter(Input);
            Console.WriteLine($"Next ten scores: {scores}");

            WritePartTitle();
            var count = generator.RecipeCountBefore(LegacyInput.ToString());
            Console.WriteLine($"Recipe count: {count}");
        }

        private const int Input = 306281;
    }
}