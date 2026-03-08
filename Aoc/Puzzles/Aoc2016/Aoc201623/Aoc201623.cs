using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201623;

[IsSlow] // 98s for part 2
[Name("Safe Cracking")]
[Comment("Factorial of 12")]
public class Aoc201623 : AocPuzzle
{
    [Puzzle("11e66781d74c9188561ba3937d053d99")]
    public int Part1(string input) => new SafeCrackingComputerPart1(input, 7, 0).ValueA;

    [Puzzle("eb0c83e21e8bd77e7f0b5686e8f1c31a")]
    public int Part2(string input) => new SafeCrackingComputerPart2(input, 12, 0).ValueA;  // 12! + 7708
}