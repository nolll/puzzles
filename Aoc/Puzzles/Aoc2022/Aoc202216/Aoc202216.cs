using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202216;

[Name("Proboscidea Volcanium")]
public class Aoc202216 : AocPuzzle
{
    [Puzzle("dd3e51c50edd114901226b469c51dd40")]
    public int Part1(string input) => new VolcanicPipes(input).Part1();

    [Puzzle("29db1cdba5fd2b052581c68854027ea8")]
    public int Part2(string input) => new VolcanicPipes(input).Part2();
}