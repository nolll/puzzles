using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201613;

[Name("A Maze of Twisty Little Cubicles")]
public class Aoc201613 : AocPuzzle
{
    [Puzzle("7cedb689517199a6fa49637072deb141")]
    public int Part1(string input) => new Maze(50, 50, int.Parse(input)).StepCountToTarget(31, 39);

    [Puzzle("d8ee6b0475f3971b598eab03bf31bed4")]
    public int Part2(string input) => new Maze(75, 75, int.Parse(input)).LocationCountAfter(50);
}