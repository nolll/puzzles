using Core.CookieRecipes;

namespace ConsoleApp.Puzzles.Year2015.Puzzles.Day15
{
    public class Year2015Day15 : Year2015Day
    {
        public override int Day => 15;

        public override PuzzleResult RunPart1()
        {
            var bakery = new CookieBakery(FileInput);
            return new PuzzleResult(bakery.HighestScore, 21_367_368);
        }

        public override PuzzleResult RunPart2()
        {
            var bakery = new CookieBakery(FileInput);
            return new PuzzleResult(bakery.HighestScoreWith500Calories, 1_766_400);
        }
    }
}