using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201809;

[Name("Marble Mania")]
public class Aoc201809 : AocPuzzle
{
    [Puzzle("dab82e0990c953b88e3617b646bc089a")]
    public long Part1(string input) => MarbleGame.Parse(input).WinnerScore;

    [Puzzle("efdea08bc5ee63512ba8659f1d13e63c")]
    public long Part2(string input) => MarbleGame.Parse(input, 100).WinnerScore;
}