using Core.Puzzles.Year2016.Day17;
using NUnit.Framework;

namespace Tests.PuzzleTests.Year2016Tests
{
    public class Year2016Day17Tests
    {
        [TestCase("ihgpwlah", "DDRRRD")]
        [TestCase("kglvqrro", "DDUDRLRRUDRD")]
        [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
        public void FindShortestPath(string passcode, string expectedPath)
        {
            var maze = new LockedDoorMaze();
            maze.FindPaths(passcode);

            Assert.That(maze.ShortestPath, Is.EqualTo(expectedPath));
        }
    }
}