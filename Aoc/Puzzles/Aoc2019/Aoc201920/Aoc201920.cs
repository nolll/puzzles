using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

[Name("Donut Maze")]
public class Aoc201920 : AocPuzzle
{
    protected override PuzzleResult RunPart1(string input)
    {
        var mazeSolver = new DonutMazeSolver(input);
        return new PuzzleResult(mazeSolver.ShortestStepCount, "58adb5666e2e47bbe945955687e3e3c6");
    }

    protected override PuzzleResult RunPart2(string input)
    {
        var recursiveDonutMazeSolver = new RecursiveDonutMazeSolver(input);
        return new PuzzleResult(recursiveDonutMazeSolver.ShortestStepCount, "01cf53a29e92f3092e973f5c97ac5595");
    }
}