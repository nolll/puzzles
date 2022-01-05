using Core.Platform;

namespace Core.Puzzles.Year2019.Day20;

public class Year2019Day20 : Puzzle
{
    public override string Comment => "Donut Maze";
    public override bool IsSlow => true;

    public override PuzzleResult RunPart1()
    {
        var mazeSolver = new DonutMazeSolver(FileInput);
        return new PuzzleResult(mazeSolver.ShortestStepCount, 462);
    }

    public override PuzzleResult RunPart2()
    {
        var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(FileInput);
        return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, 5288);
    }
}