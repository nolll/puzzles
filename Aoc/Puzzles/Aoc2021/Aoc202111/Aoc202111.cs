using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202111;

[Name("Dumbo Octopus")]
public class Aoc202111 : AocPuzzle
{
    [Puzzle("4aec5027d57e852d3dc2c0fa275d9d7a")]
    public int Part1(string input) => new OctopusFlasher(input).Run(100);

    [Puzzle("ffd6657cda58c97fce2c4c27d8fd43a9")]
    public int Part2(string input) => new OctopusFlasher(input).Run();
}