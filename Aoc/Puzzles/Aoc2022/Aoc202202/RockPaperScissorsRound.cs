namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public abstract class RockPaperScissorsRound
{
    public abstract int Score { get; }
    
    protected static int GetWinScore(Action heroAction) => GetActionScore(heroAction) + 6;
    protected static int GetDrawScore(Action heroAction) => GetActionScore(heroAction) + 3;
    protected static int GetLoserScore(Action heroAction) => GetActionScore(heroAction);

    private static int GetActionScore(Action heroAction) => heroAction switch
    {
        Action.Rock => 1,
        Action.Paper => 2,
        _ => 3
    };
}