using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Rock Paper Scissors")]
public class Aoc202202 : AocPuzzle
{
    [Puzzle("21342a8c13c83a2420368dd586a7a5dd")]
    public int Part1(string input) => input.Split(LineBreaks.Single).Select(ParsePart1).Sum(GetScore);

    [Puzzle("ee182ab67d32eeac3499142ceeb632c3")]
    public int Part2(string input) => input.Split(LineBreaks.Single).Select(ParsePart2).Sum(GetScore);

    private static int GetScore(Part1Round round)
    {
        if (IsWinner(round))
            return GetWinScore(round.Hero);
        if (IsDraw(round))
            return GetDrawScore(round.Hero);
        return GetLoseScore(round.Hero);
    }

    private static int GetScore(Part2Round round) => round.PreferredResult switch
    {
        PreferredResult.Win => GetWinScore(GetWinAction(round.Villain)),
        PreferredResult.Draw => GetDrawScore(round.Villain),
        _ => GetLoseScore(GetLoseAction(round.Villain))
    };

    private static bool IsWinner(Part1Round round) => round.Villain switch
    {
        Action.Paper when round.Hero == Action.Scissors => true,
        Action.Rock when round.Hero == Action.Paper => true,
        Action.Scissors when round.Hero == Action.Rock => true,
        _ => false
    };

    private static bool IsDraw(Part1Round round) => round.Villain == round.Hero;
        
    private static Action GetWinAction(Action villain) => villain switch
    {
        Action.Paper => Action.Scissors,
        Action.Rock => Action.Paper,
        _ => Action.Rock
    };
        
    private static Action GetLoseAction(Action villain) => villain switch
    {
        Action.Paper => Action.Rock,
        Action.Rock => Action.Scissors,
        _ => Action.Paper
    };

    private static int GetWinScore(Action heroAction) => GetActionScore(heroAction) + 6;
    private static int GetDrawScore(Action heroAction) => GetActionScore(heroAction) + 3;
    private static int GetLoseScore(Action heroAction) => GetActionScore(heroAction);

    private static int GetActionScore(Action heroAction) => heroAction switch
    {
        Action.Rock => 1,
        Action.Paper => 2,
        _ => 3
    };

    private static Part1Round ParsePart1(string s)
    {
        var (v, h) = s.Split(' ');
        var villain = ParseVillainAction(v);
        var hero = ParseHeroAction(h);
        return new Part1Round(villain, hero);
    }

    private static Part2Round ParsePart2(string s)
    {
        var (v, pr) = s.Split(' ');
        var villain = ParseVillainAction(v);
        var preferredResult = ParsePreferredResult(pr);
        return new Part2Round(villain, preferredResult);
    }

    private static Action ParseVillainAction(string s) => s switch
    {
        "A" => Action.Rock,
        "B" => Action.Paper,
        _ => Action.Scissors
    };

    private static Action ParseHeroAction(string s) => s switch
    {
        "X" => Action.Rock,
        "Y" => Action.Paper,
        _ => Action.Scissors
    };

    private static PreferredResult ParsePreferredResult(string s) => s switch
    {
        "X" => PreferredResult.Lose,
        "Y" => PreferredResult.Draw,
        _ => PreferredResult.Win
    };
    
    private record Part1Round(Action Villain, Action Hero);
    private record Part2Round(Action Villain, PreferredResult PreferredResult);
    
    private enum Action
    {
        Rock,
        Paper,
        Scissors
    }

    private enum PreferredResult
    {
        Lose,
        Draw,
        Win
    }
}