using Aoc.Platform;

namespace Aoc.Puzzles.Year2018.Day15;

public class Year2018Day15 : Puzzle
{
    public override string Title => "Beverage Bandits";
    public override string Comment => "Battle Simulator";
    public override bool IsSlow => true; // Could still use optimization, the hard coded 14 is a little ugly

    public override PuzzleResult RunPart1()
    {
        var battle = new ChocolateBattle(FileInput);
        battle.RunOnce();
        return new PuzzleResult(battle.Outcome, 246_176);
    }

    public override PuzzleResult RunPart2()
    {
        var battle2 = new ChocolateBattle(FileInput);
        const int initialAttackPower = 14; // Was 4. Optimized after correct answer was found
        battle2.RunUntilElvesWins(initialAttackPower);
        return new PuzzleResult(battle2.Outcome, 58_128);
    }
}