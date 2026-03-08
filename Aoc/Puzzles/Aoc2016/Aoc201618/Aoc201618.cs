using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201618;

[Name("Like a Rogue")]
public class Aoc201618 : AocPuzzle
{
    [Puzzle("e5a7af4db610ffe95694d0dd5d7b43c6")]
    public int Part1(string input) => new FloorTrapDetector(input).CountSafeTiles(40);

    [Puzzle("bd1b0d5a17ef0a0b7c880a805ea95cc4")]
    public int Part2(string input) => new FloorTrapDetector(input).CountSafeTiles(400_000);
}