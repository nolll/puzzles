using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202215;

[Name("Beacon Exclusion Zone")]
public class Aoc202215 : AocPuzzle
{
    [Puzzle("f81ea7aff75f183d6afc5816570af244")]
    public int Part1(string input) => new BeaconZone().Part1(input, 2_000_000);

    [Puzzle("b4c412a68efd49876d6777a8ea4baea1")]
    public long Part2(string input) => new BeaconZone().Part2(input, 4_000_000);
}