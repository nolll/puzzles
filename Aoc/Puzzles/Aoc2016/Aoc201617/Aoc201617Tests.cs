using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201617;

public class Aoc201617Tests
{
    [TestCase("ihgpwlah", "DDRRRD")]
    [TestCase("kglvqrro", "DDUDRLRRUDRD")]
    [TestCase("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void FindShortestPath(string passcode, string expectedPath)
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(passcode);

        maze.ShortestPath.Should().Be(expectedPath);
    }
}