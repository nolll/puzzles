using Core.Puzzles.Year2015.Day09;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2015Tests
{
    public class Year2015Day09Tests
    {
        [Test]
        public void CalculateShortestAndLongestRoute()
        {
            const string input = @"
London to Dublin = 464
London to Belfast = 518
Dublin to Belfast = 141";

            var calculator = new RouteCalculator(input);

            Assert.That(calculator.ShortestDistance, Is.EqualTo(605));
            Assert.That(calculator.LongestDistance, Is.EqualTo(982));
        }
    }
}