using ConsoleApp.Puzzles.Year2019.Puzzles.Day17;
using NUnit.Framework;

namespace Tests
{
    public class ScaffoldingTests
    {
        [Test]
        public void IntersectionsFound()
        {
            const string input = @"
..#..........
..#..........
#######...###
#.#...#...#.#
#############
..#...#...#..
..#####...^..";

            var intersectionFinder = new ScaffoldIntersectionFinder(input);
            var result = intersectionFinder.GetSumOfAlignmentParameters();

            Assert.That(result, Is.EqualTo(76));
        }
    }
}