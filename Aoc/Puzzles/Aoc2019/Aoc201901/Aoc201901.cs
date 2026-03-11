using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201901;

[Name("The Tyranny of the Rocket Equation")]
public class Aoc201901 : AocPuzzle
{
    [Puzzle("863ba725f4b926c82a67e448dbacc8ca")]
    public int Part1(string input) => new MassCalculator(input).MassFuel;

    [Puzzle("9a6de12a9f00b9360ead07efc0249b8c")]
    public int Part2(string input) => new MassCalculator(input).TotalFuel;
}