using Core.Platform;

namespace Core.Puzzles.Year2018.Day15;

public class Year2018Day15 : Puzzle
{
    public override string Title => "Beverage Bandits";
    public override string Comment => "Battle Simulator";
    public override bool IsSlow => true; // part 1: 64s, part2: 77s

    public override PuzzleResult RunPart1()
    {
        var battle = new ChocolateBattle(FileInput);
        battle.RunOnce();
        return new PuzzleResult(battle.Outcome, 246_176);
    }

    public override PuzzleResult RunPart2()
    {
        var battle2 = new ChocolateBattle(FileInput);
        var initialAttackPower = 14; // Was 4. Optimized after correct answer was found
        battle2.RunUntilElvesWins(initialAttackPower);
        return new PuzzleResult(battle2.Outcome, 58_128);
    }
}