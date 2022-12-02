namespace Core.Puzzles.Year2022.Day02;

public class Part1Round : RockPaperScissorsRound
{
    private readonly Action _villainAction;
    private readonly Action _heroAction;

    private Part1Round(Action villainAction, Action heroAction)
    {
        _villainAction = villainAction;
        _heroAction = heroAction;
    }

    public static Part1Round Parse(string s)
    {
        var parts = s.Split(' ');
        var villainAction = RockPaperScissorsParser.ParseVillainAction(parts[0]);
        var heroAction = RockPaperScissorsParser.ParseHeroAction(parts[1]);
        return new Part1Round(villainAction, heroAction);
    }

    public int Score
    {
        get
        {
            if (IsWinner)
                return WinScore;
            if (IsDraw)
                return DrawScore;
            return LoseScore;
        }
    }

    private bool IsWinner
    {
        get
        {
            switch (_villainAction)
            {
                case Action.Paper when _heroAction == Action.Scissors:
                case Action.Rock when _heroAction == Action.Paper:
                case Action.Scissors when _heroAction == Action.Rock:
                    return true;
                default:
                    return false;
            }
        }
    }

    private bool IsDraw => _villainAction == _heroAction;

    private int WinScore => GetWinScore(_heroAction);
    private int DrawScore => GetDrawScore(_heroAction);
    private int LoseScore => GetLoserScore(_heroAction);
}