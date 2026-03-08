using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201524;

[Name("It Hangs in the Balance")]
public class Aoc201524 : AocPuzzle
{
    [Puzzle("112caddb8448ec5cdd5bfca087f393aa")]
    public long Part1(string input) => new PresentBalancer(input, 3).QuantumEntanglementOfFirstGroup;

    [Puzzle("d1eb70991c3477542b3499f754799982")]
    public long Part2(string input) => new PresentBalancer(input, 4).QuantumEntanglementOfFirstGroup;
}