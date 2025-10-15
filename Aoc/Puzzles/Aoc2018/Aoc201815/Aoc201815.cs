using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

[IsSlow] // 18s for part 2
[Name("Beverage Bandits")]
[Comment("Battle Simulator")]
public class Aoc201815 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var battle = new ChocolateBattle(input);
        var result = battle.FightOneRound();
        return new PuzzleResult(result, "78d65601c1d852a1cb1c731ef5403795");
    }

    public PuzzleResult RunPart2(string input)
    {
        var battle2 = new ChocolateBattle(input);
        var result = battle2.FightUntilElvesWins();
        return new PuzzleResult(result, "69659adc98aaf6e1d1febd9dabddca6f");
    }
}