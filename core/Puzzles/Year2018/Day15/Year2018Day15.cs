using Core.Platform;

namespace Core.Puzzles.Year2018.Day15;

public class Year2018Day15 : Puzzle
{
    public override string Comment => "Battle Simulator";
    public override bool IsSlow => true;

    public override PuzzleResult RunPart1()
    {
        var battle = new ChocolateBattle(FileInput);
        battle.RunOnce(false);
        return new PuzzleResult(battle.Outcome, 246_176);
    }

    //public override PuzzleResult RunPart2()
    //{
    //    var battle2 = new ChocolateBattle(FileInput);
    //    battle2.RunUntilElvesWins(false);
    //    return new PuzzleResult(battle2.Outcome, 58_128);
    //}
}