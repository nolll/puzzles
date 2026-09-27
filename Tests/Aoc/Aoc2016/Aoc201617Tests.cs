using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201617Tests
{
    [Theory]
    [InlineData("ihgpwlah", "DDRRRD")]
    [InlineData("kglvqrro", "DDUDRLRRUDRD")]
    [InlineData("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void FindShortestPath(string passcode, string expectedPath)
    {
        var maze = new Aoc201617.LockedDoorMaze();
        maze.FindPaths(passcode);

        maze.ShortestPath.Should().Be(expectedPath);
    }
}