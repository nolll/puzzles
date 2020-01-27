using Core.CubicleMaze;
using NUnit.Framework;

namespace Tests
{
    public class CubicleMazeTests
    {
        [Test]
        public void ShortestRouteLengthIsCorrect()
        {
            const int input = 10;

            var maze = new Maze(10, 7, input, 7, 4);

            Assert.That(maze.RouteLength, Is.EqualTo(11));
        }
    }
}