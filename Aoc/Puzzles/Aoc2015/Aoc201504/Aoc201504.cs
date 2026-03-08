using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201504;

[Name("The Ideal Stocking Stuffer")]
public class Aoc201504 : AocPuzzle
{
    [Puzzle("e89372908b5202e6ce4d69a8b3538295")]
    public int Part1(string input) => AdventCoinMiner.Mine(input, 5);

    [Puzzle("9eb348bda7d61e7026099765b89a55fa")]
    public int Part2(string input) => AdventCoinMiner.Mine(input, 6);
}