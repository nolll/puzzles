using Aoc.Platform;
using common.Puzzles;

namespace Aoc.Puzzles.Year2016.Day17;

public class Year2016Day17 : AocPuzzle
{
    public override string Title => "Two Steps Forward";

    public override PuzzleResult RunPart1()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(Input);
        return new PuzzleResult(maze.ShortestPath, "RLDRUDRDDR");
    }

    public override PuzzleResult RunPart2()
    {
        var maze = new LockedDoorMaze();
        maze.FindPaths(Input);
        return new PuzzleResult(maze.LongestPath.Length, 498);
    }

    private const string Input = "yjjvjgan";
}