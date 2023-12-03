namespace Puzzles.Aoc.Puzzles.Aoc2022.Aoc202202;

public class RockPaperScissorsRound
{
    protected int GetWinScore(Action heroAction)
    {
        return GetActionScore(heroAction) + 6;
    }

    protected int GetDrawScore(Action heroAction)
    {
        return GetActionScore(heroAction) + 3;
    }

    protected int GetLoserScore(Action heroAction)
    {
        return GetActionScore(heroAction);
    }

    protected int GetActionScore(Action heroAction)
    {
        return heroAction switch
        {
            Action.Rock => 1,
            Action.Paper => 2,
            _ => 3
        };
    }
}