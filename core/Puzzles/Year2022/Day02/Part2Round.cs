namespace Core.Puzzles.Year2022.Day02;

public class Part2Round : RockPaperScissorsRound
{
    private readonly Action _villainAction;
    private readonly PreferredResult _preferredResult;

    private Part2Round(Action villainAction, PreferredResult preferredResult)
    {
        _villainAction = villainAction;
        _preferredResult = preferredResult;
    }

    public static Part2Round Parse(string s)
    {
        var parts = s.Split(' ');
        var villainAction = RockPaperScissorsParser.ParseVillainAction(parts[0]);
        var preferredResult = RockPaperScissorsParser.ParsePreferredResult(parts[1]);
        return new Part2Round(villainAction, preferredResult);
    }

    public int Score
    {
        get
        {
            return _preferredResult switch
            {
                PreferredResult.Win => GetWinScore(WinAction),
                PreferredResult.Draw => GetDrawScore(_villainAction),
                _ => GetLoserScore(LoseAction)
            };
        }
    }

    private Action WinAction
    {
        get
        {
            return _villainAction switch
            {
                Action.Paper => Action.Scissors,
                Action.Rock => Action.Paper,
                _ => Action.Rock
            };
        }
    }

    private Action LoseAction
    {
        get
        {
            return _villainAction switch
            {
                Action.Paper => Action.Rock,
                Action.Rock => Action.Scissors,
                _ => Action.Paper
            };
        }
    }
}
