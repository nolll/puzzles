using Core.HashedDoors;
using NUnit.Framework;

namespace Tests
{
    public class LockedDoorTests
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