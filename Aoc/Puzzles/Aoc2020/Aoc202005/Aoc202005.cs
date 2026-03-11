using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202005;

[Name("Binary Boarding")]
public class Aoc202005 : AocPuzzle
{
    [Puzzle("0c707dd92ed04ceea0c32086af11620a")]
    public int Part1(string input) => new BoardingCardProcessor(input).HighestId;

    [Puzzle("886c488b39cd9f4848e5a6a2358861c6")]
    public int? Part2(string input) => new BoardingCardProcessor(input).FindMySeat()?.Id;
}