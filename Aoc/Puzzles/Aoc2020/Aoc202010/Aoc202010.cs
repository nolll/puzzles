using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202010;

[Name("Adapter Array")]
public class Aoc202010 : AocPuzzle
{
    [Puzzle("56be819907a3ccd3fa53c9340c9cd2b7")]
    public int Part1(string input) => new PowerAdapterChain(input).DifferenceProduct;

    [Puzzle("791600ed80a4c8e120ae60a88193043f")]
    public long Part2(string input) => new PowerAdapterChain(input).GetTotalNumberOfCombinations();
}