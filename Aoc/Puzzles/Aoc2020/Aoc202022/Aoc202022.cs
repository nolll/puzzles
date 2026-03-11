using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202022;

[Name("Crab Combat")]
public class Aoc202022 : AocPuzzle
{
    [Puzzle("1ab0c908e993eb4c76057e745326c12d")]
    public long Part1(string input) => new CardCombatGame(input).Play();

    [Puzzle("f1c4ea36b08889edb687d00e9dacffcf")]
    public long Part2(string input) => new CardCombatGame(input).PlayRecursive();
}