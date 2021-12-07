using Core.Puzzles.Year2015.Day17;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2015Tests
{
    public class Year2015Day17Tests
    {
        [Test]
        public void NumberOfCombinationsIsCorrect()
        {
            const string input = @"
20
15
10
5
5";

            var containers = new EggnogContainers(input);
            var combinations = containers.GetCombinations(25);

            Assert.That(combinations.Count, Is.EqualTo(4));
        }
    }
}