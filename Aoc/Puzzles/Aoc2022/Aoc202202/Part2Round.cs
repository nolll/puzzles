namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202202;

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

    public override int Score => _preferredResult switch
    {
        PreferredResult.Win => GetWinScore(WinAction),
        PreferredResult.Draw => GetDrawScore(_villainAction),
        _ => GetLoserScore(LoseAction)
    };

    private Action WinAction => _villainAction switch
    {
        Action.Paper => Action.Scissors,
        Action.Rock => Action.Paper,
        _ => Action.Rock
    };

    private Action LoseAction => _villainAction switch
    {
        Action.Paper => Action.Rock,
        Action.Rock => Action.Scissors,
        _ => Action.Paper
    };
}
