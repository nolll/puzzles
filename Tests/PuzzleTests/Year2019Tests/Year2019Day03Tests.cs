using Core.Puzzles.Year2019.Day03;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2019Tests
{
    public class Year2019Day03Tests
    {
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 159)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 135)]
        public void ReturnsTheShortestManhattanDistance(string pathA, string pathB, int expectedDistance)
        {
            var intersectionFinder = new IntersectionFinder(pathA, pathB);
            var result = intersectionFinder.ClosestIntersection;
            Assert.That(result.Distance, Is.EqualTo(expectedDistance));
        }

        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 30)]
        [TestCase("R75,D30,R83,U83,L12,D49,R71,U7,L72", "U62,R66,U55,R34,D71,R55,D58,R83", 610)]
        [TestCase("R98,U47,R26,D63,R33,U87,L62,D20,R33,U53,R51", "U98,R91,D20,R16,D67,R40,U7,R15,U6,R7", 410)]
        public void ReturnsFewestStepsToReachAnIntersection(string pathA, string pathB, int expectedSteps)
        {
            var intersectionFinder = new IntersectionFinder(pathA, pathB);
            var result = intersectionFinder.FewestSteps;
            Assert.That(result.Steps, Is.EqualTo(expectedSteps));
        }
    }
}