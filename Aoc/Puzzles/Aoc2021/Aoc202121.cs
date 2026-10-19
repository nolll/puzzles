using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Dirac Dice")]
public class Aoc202121 : AocPuzzle
{
    [Puzzle("97097680a3e3bcba7ebb46d172476cd9")]
    public int Part1(string input)
    {
        var (pos1, pos2) = Parse(input);
        var dice = 0;

        var p1 = new DiracDicePlayer(pos1 - 1);
        var p2 = new DiracDicePlayer(pos2 - 1);

        for (var i = 0; i < 1000; i++)
        {
            if (Move(p1))
                break;
            
            if (Move(p2))
                break;
        }
        
        return Math.Min(p1.Score, p2.Score) * dice;
            
        bool Move(DiracDicePlayer player)
        {
            dice = player.Move(dice);
            return player.Score >= 1000;
        }
    }

    [Puzzle("677e241c3997b2a9a5c99891d90399f3")]
    public long Part2(string input)
    {
        var (pos1, pos2) = Parse(input);
        var games = BuildGamesDictionary();
        games[(pos1 - 1, pos2 - 1, 0, 0)] = 1;
        (long p1, long p2) wins = (0, 0);

        while (games.Values.Sum() > 0)
        {
            var newGames = BuildGamesDictionary();
            foreach (var (key, gameCount) in games)
            {
                if (gameCount == 0)
                    continue;

                var s = NextPosAndScore(key.p1pos, key.p1score, 9);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount;

                s = NextPosAndScore(key.p1pos, key.p1score, 8);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount * 3;

                s = NextPosAndScore(key.p1pos, key.p1score, 7);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount * 6;

                s = NextPosAndScore(key.p1pos, key.p1score, 6);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount * 7;

                s = NextPosAndScore(key.p1pos, key.p1score, 5);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount * 6;

                s = NextPosAndScore(key.p1pos, key.p1score, 4);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount * 3;

                s = NextPosAndScore(key.p1pos, key.p1score, 3);
                newGames[(s.pos, key.p2pos, s.score, key.p2score)] += gameCount;
            }

            games = newGames;
            foreach (var (key, value) in games)
            {
                if (key.p1score < 21 || value <= 0)
                    continue;
                
                wins.p1 += value;
                games[key] = 0;
            }

            newGames = BuildGamesDictionary();
            foreach (var (key, gameCount) in games)
            {
                if (gameCount == 0)
                    continue;

                var s = NextPosAndScore(key.p2pos, key.p2score, 9);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 8);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount * 3;

                s = NextPosAndScore(key.p2pos, key.p2score, 7);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount * 6;

                s = NextPosAndScore(key.p2pos, key.p2score, 6);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount * 7;

                s = NextPosAndScore(key.p2pos, key.p2score, 5);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount * 6;

                s = NextPosAndScore(key.p2pos, key.p2score, 4);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount * 3;

                s = NextPosAndScore(key.p2pos, key.p2score, 3);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;
            }

            games = newGames;
            foreach (var (key, value) in games)
            {
                if (key.p2score < 21 || value <= 0)
                    continue;
                
                wins.p2 += value;
                games[key] = 0;
            }
        }

        return Math.Max(wins.p1, wins.p2);
    }

    private (int pos, int score) NextPosAndScore(int pos, int score, int dice)
    {
        var newPos = (pos + dice) % 10;
        var newScore = score + newPos + 1;
        return (newPos, newScore);
    }

    private static Dictionary<(int p1pos, int p2pos, int p1score, int p2score), long> BuildGamesDictionary()
    {
        var games = new Dictionary<(int p1pos, int p2pos, int p1score, int p2score), long>();
        for (var i = 0; i < 10; i++)
        {
            for (var j = 0; j < 10; j++)
            {
                for (var k = 0; k < 31; k++)
                {
                    for (var l = 0; l < 31; l++)
                    {
                        games.Add((i, j, k, l), 0);
                    }
                }
            }
        }

        return games;
    }

    private class DiracDicePlayer(int pos)
    {
        public int Score { get; private set; }
        private int _pos = pos;

        public int Move(int dice)
        {
            for (var i = 0; i < 3; i++)
            {
                dice++;
                _pos = (_pos + dice) % 10;
            }

            Score += _pos + 1;

            return dice;
        }
    }
    
    private static (int, int) Parse(string input)
    {
        var (_, pos1, _, pos2) = Numbers.IntsFromString(input);
        return (pos1, pos2);
    }
}