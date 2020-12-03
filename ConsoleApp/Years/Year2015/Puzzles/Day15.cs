using System;
using Core.CookieRecipes;

namespace ConsoleApp.Years.Year2015.Puzzles
{
    public class Day15 : Day2015
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var race = new CookieBakery(FileInput);
            Console.WriteLine($"Highest score: {race.HighestScore}");

            WritePartTitle();
            Console.WriteLine($"Highest score for cookies with 500 calories: {race.HighestScoreWith500Calories}");
        }
    }
}