using Core.Puzzles.Year2019.Day17;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2019Tests
{
    public class Year2019Day17Tests
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