using NUnit.Framework;

namespace App.Puzzles.Year2015.Day17
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