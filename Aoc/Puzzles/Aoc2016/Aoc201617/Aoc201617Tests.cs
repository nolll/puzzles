namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201617;

public class Aoc201617Tests
{
    [Theory]
    [InlineData("ihgpwlah", "DDRRRD")]
    [InlineData("kglvqrro", "DDUDRLRRUDRD")]
    [InlineData("ulqzkmiv", "DRURDRUDDLLDLUURRDULRLDUUDDDRR")]
    public void FindShortestPath(string passcode, string expectedPath)
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(passcode);

        maze.ShortestPath.Should().Be(expectedPath);
    }
}