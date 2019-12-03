using Core.IntersectionFinder;
using NUnit.Framework;

namespace Tests
{
    public class IntersectionFinderTests
    {
        [TestCase("R8,U5,L5,D3", "U7,R6,D4,L4", 6)]
        public void ReturnsTheShortestDistance(string pathA, string pathB, int expectedDistance)
        {
            var intersectionFinder = new IntersectionFinder(pathA, pathB);
            var result = intersectionFinder.ClosestIntersection;
            Assert.That(result.Distance, Is.EqualTo(expectedDistance));
        }
    }
}