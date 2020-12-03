using System;
using Core.CookieRecipes;

namespace ConsoleApp.Years.Year2015
{
    public class Day15 : Day2015
    {
        public Day15() : base(15)
        {
        }

        protected override void RunDay()
        {
            WritePartTitle();
            var race = new CookieBakery(Input);
            Console.WriteLine($"Highest score: {race.HighestScore}");

            WritePartTitle();
            Console.WriteLine($"Highest score for cookies with 500 calories: {race.HighestScoreWith500Calories}");
        }

        protected override string Input => @"
Sprinkles: capacity 2, durability 0, flavor -2, texture 0, calories 3
Butterscotch: capacity 0, durability 5, flavor -3, texture 0, calories 3
Chocolate: capacity 0, durability 0, flavor 5, texture -1, calories 8
Candy: capacity 0, durability -1, flavor 0, texture 5, calories 8";
    }
}