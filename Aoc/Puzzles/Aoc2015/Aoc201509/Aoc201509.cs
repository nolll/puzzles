using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201509;

[Name("All in a Single Night")]
public class Aoc201509 : AocPuzzle
{
    [Puzzle("4cc29488fe313222695140cafd29224d")]
    public int Part1(string input) => new RouteCalculator(input).ShortestDistance;

    [Puzzle("6d5195b794f070d181a56006b064ff95")]
    public int Part2(string input) => new RouteCalculator(input).LongestDistance;
}