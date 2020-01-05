using Core.Polymers;
using NUnit.Framework;

namespace Tests
{
    public class PolymerTests
    {
        [Test]
        public void FullPolymer()
        {
            const string input = "dabAcCaCBAcCcaDA";

            var puzzle = new PolymerPuzzle(input);
            Assert.AreEqual("dabCBAcaDA", puzzle.ReducedPolymer);
        }

        [Test]
        public void ImprovedPolymer()
        {
            const string input = "dabAcCaCBAcCcaDA";

            var puzzle = new PolymerPuzzle(input);
            Assert.AreEqual("daDA", puzzle.ImprovedPolymer);
        }
    }
}