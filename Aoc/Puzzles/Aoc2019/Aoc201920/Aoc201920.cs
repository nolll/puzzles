using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201920;

[Name("Donut Maze")]
public class Aoc201920 : AocPuzzle
{
    [Puzzle("58adb5666e2e47bbe945955687e3e3c6")]
    public int Part1(string input) => new DonutMazeSolver(input).ShortestStepCount;

    [Puzzle("01cf53a29e92f3092e973f5c97ac5595")]
    public int Part2(string input) => new RecursiveDonutMazeSolver(input).ShortestStepCount;
}