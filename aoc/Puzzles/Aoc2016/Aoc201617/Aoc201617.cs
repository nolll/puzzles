using Common.Puzzles;

namespace Aoc.Puzzles.Aoc2016.Aoc201617;

public class Aoc201617 : AocPuzzle
{
    public override string Name => "Two Steps Forward";

    protected override PuzzleResult RunPart1()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(Input);
        return new PuzzleResult(maze.ShortestPath, "RLDRUDRDDR");
    }

    protected override PuzzleResult RunPart2()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(Input);
        return new PuzzleResult(maze.LongestPath?.Length, 498);
    }

    private const string Input = "yjjvjgan";
}