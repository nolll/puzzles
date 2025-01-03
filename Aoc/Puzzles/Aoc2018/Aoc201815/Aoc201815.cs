using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2018.Aoc201815;

[IsSlow] // 23s for part 2
[Name("Beverage Bandits")]
[Comment("Battle Simulator")]
public class Aoc201815 : AocPuzzle
{
    public PuzzleResult RunPart1(string input)
    {
        var battle = new ChocolateBattle(input);
        battle.RunOnce();
        return new PuzzleResult(battle.Outcome, "78d65601c1d852a1cb1c731ef5403795");
    }

    public PuzzleResult RunPart2(string input)
    {
        var battle2 = new ChocolateBattle(input);
        const int initialAttackPower = 4; // Was 4. Optimized after correct answer was found
        battle2.RunUntilElvesWins(initialAttackPower);
        return new PuzzleResult(battle2.Outcome, "69659adc98aaf6e1d1febd9dabddca6f");
    }
}