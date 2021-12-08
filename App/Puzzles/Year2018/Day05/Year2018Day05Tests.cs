using NUnit.Framework;

namespace App.Puzzles.Year2018.Day05
{
    public class Year2018Day05Tests
    {
        [Test]
        public void FullPolymer()
        {
            const string input = "dabAcCaCBAcCcaDA";

            var puzzle = new PolymerPuzzle();
            var reducedPolymer = puzzle.GetReducedPolymer(input);
            Assert.AreEqual("dabCBAcaDA", reducedPolymer);
        }

        [Test]
        public void ImprovedPolymer()
        {
            const string input = "dabAcCaCBAcCcaDA";

            var puzzle = new PolymerPuzzle();
            var improvedPolymer = puzzle.GetImprovedPolymer(input);
            Assert.AreEqual("daDA", improvedPolymer);
        }
    }
}