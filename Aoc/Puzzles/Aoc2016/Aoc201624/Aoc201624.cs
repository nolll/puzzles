using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201624;

[Name("Air Duct Spelunking")]
public class Aoc201624 : AocPuzzle
{
    [Puzzle("573c0267baa35fb5a2a80250ac4d8775")]
    public int Part1(string input) => new AirDuctNavigator(input).Run(false);

    [Puzzle("5d497a617fb2aecf0d9e02ee07665b4e")]
    public int Part2(string input) => new AirDuctNavigator(input).Run(true);
}