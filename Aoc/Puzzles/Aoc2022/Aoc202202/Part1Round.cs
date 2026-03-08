namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

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

    public override int Score
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

    private bool IsWinner => _villainAction switch
    {
        Action.Paper when _heroAction == Action.Scissors => true,
        Action.Rock when _heroAction == Action.Paper => true,
        Action.Scissors when _heroAction == Action.Rock => true,
        _ => false
    };

    private bool IsDraw => _villainAction == _heroAction;

    private int WinScore => GetWinScore(_heroAction);
    private int DrawScore => GetDrawScore(_heroAction);
    private int LoseScore => GetLoserScore(_heroAction);
}