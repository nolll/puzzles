namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

public static class RockPaperScissorsParser
{
    public static Action ParseVillainAction(string s)
    {
        return s switch
        {
            "A" => Action.Rock,
            "B" => Action.Paper,
            _ => Action.Scissors
        };
    }

    public static Action ParseHeroAction(string s)
    {
        return s switch
        {
            "X" => Action.Rock,
            "Y" => Action.Paper,
            _ => Action.Scissors
        };
    }

    public static PreferredResult ParsePreferredResult(string s)
    {
        return s switch
        {
            "X" => PreferredResult.Lose,
            "Y" => PreferredResult.Draw,
            _ => PreferredResult.Win
        };
    }
}