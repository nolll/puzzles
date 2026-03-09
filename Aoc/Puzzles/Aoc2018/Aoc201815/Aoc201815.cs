using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

[Name("Beverage Bandits")]
public class Aoc201815 : AocPuzzle
{
    [Puzzle("78d65601c1d852a1cb1c731ef5403795")]
    public int Part1(string input) => new ChocolateBattle(input).FightOneRound();

    [Puzzle("69659adc98aaf6e1d1febd9dabddca6f")]
    public int Part2(string input) => new ChocolateBattle(input).FightUntilElvesWins();
}