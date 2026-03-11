using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201916;

[Name("Flawed Frequency Transmission")]
public class Aoc201916 : AocPuzzle
{
    [Puzzle("e995b448fd31fb067432b47f11ac0e67")]
    public string Part1(string input) => new FrequencyAlgorithmPart1(input).Run(100);

    [Puzzle("0b00b51e4f1b1d517a2bb16008f7af58")]
    public string Part2(string input) => new FrequencyAlgorithmPart2(input).Run(100);
}