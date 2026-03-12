using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202019;

[Name("Monster Messages")]
public class Aoc202019 : AocPuzzle
{
    [Puzzle("5689e3eed11a233bb204f8f0e2bfe42f")]
    public int Part1(string input) => new MonsterImageValidator(input).ValidCount();

    [Puzzle("95d28bbc9dd67fbc8d8db74ab2879177")]
    public int Part2(string input) => new MonsterImageValidator(input, true).ValidCount();
}