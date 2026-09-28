using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Rock Paper Scissors")]
public class Aoc202202 : AocPuzzle
{
    [Puzzle("21342a8c13c83a2420368dd586a7a5dd")]
    public int Part1(string input) => Solve(input, Part1Round.Parse);

    [Puzzle("ee182ab67d32eeac3499142ceeb632c3")]
    public int Part2(string input) => Solve(input, Part2Round.Parse);

    private static int Solve(string input, Func<string, RockPaperScissorsRound> parse) =>
        input.Split(LineBreaks.Single)
            .Where(o => o.Length > 0)
            .Select(parse)
            .Sum(o => o.Score);
    
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
    
    public enum Action
    {
        Rock,
        Paper,
        Scissors
    }
    
    public enum PreferredResult
    {
        Lose,
        Draw,
        Win
    }
    
    public static class RockPaperScissorsParser
    {
        public static Action ParseVillainAction(string s) => s switch
        {
            "A" => Action.Rock,
            "B" => Action.Paper,
            _ => Action.Scissors
        };

        public static Action ParseHeroAction(string s) => s switch
        {
            "X" => Action.Rock,
            "Y" => Action.Paper,
            _ => Action.Scissors
        };

        public static PreferredResult ParsePreferredResult(string s) => s switch
        {
            "X" => PreferredResult.Lose,
            "Y" => PreferredResult.Draw,
            _ => PreferredResult.Win
        };
    }
    
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
}