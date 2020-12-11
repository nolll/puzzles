using System;
using Core.CookieRecipes;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day15 : Day2015
    {
        public Day15() : base(15)
        {
        }

        public override PuzzleResult RunPart1()
        {
            var bakery = new CookieBakery(FileInput);
            return new PuzzleResult($"Highest score: {bakery.HighestScore}");
        }

        public override PuzzleResult RunPart2()
        {
            var bakery = new CookieBakery(FileInput);
            return new PuzzleResult($"Highest score for cookies with 500 calories: {bakery.HighestScoreWith500Calories}");
        }
    }
}