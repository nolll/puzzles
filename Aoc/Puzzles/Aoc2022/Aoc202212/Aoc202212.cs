using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202212;

[Name("Hill Climbing Algorithm")]
public class Aoc202212 : AocPuzzle
{
    [Puzzle("48b865d6e753e7b8f1cd6f83d797bd43")]
    public int Part1(string input) => new HillClimbing().Part1(input);

    [Puzzle("222a9519ff249ce48bdd88917bbcc312")]
    public int Part2(string input) => new HillClimbing().Part2(input);
}