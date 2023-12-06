using Pzl.Tools.Puzzles;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

public class Aoc201920 : AocPuzzle
{
    public override string Name => "Donut Maze";

    protected override PuzzleResult RunPart1()
    {
        var mazeSolver = new DonutMazeSolver(InputFile);
        return new PuzzleResult(mazeSolver.ShortestStepCount, "58adb5666e2e47bbe945955687e3e3c6");
    }

    protected override PuzzleResult RunPart2()
    {
        var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(InputFile);
        return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, "01cf53a29e92f3092e973f5c97ac5595");
    }
}