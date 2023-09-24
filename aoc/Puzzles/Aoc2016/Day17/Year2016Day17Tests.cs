using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Day17;

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