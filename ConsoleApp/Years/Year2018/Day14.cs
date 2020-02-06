using System;
using Core.HotChocolate;

namespace ConsoleApp.Years.Year2018
{
    public class Day14 : Day
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
        }

        private const int Input = 306281;
    }
}