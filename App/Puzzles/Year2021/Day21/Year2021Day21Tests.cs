using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace App.Puzzles.Year2021.Day21;

public class Year2021Day21Tests
{
    [Test]
    public void Part1()
    {
        var game = new DiracDiceGame();
        var result = game.Play(4, 8);

        Assert.That(result.Result, Is.EqualTo(739785));
    }
    
    [Test]
    public void Part2()
    {
        var game = new RealDiracDiceGame();
        var result = game.Play(4, 8);

        Assert.That(result, Is.EqualTo(444356092776315));
    }
}

public class RealDiracDiceGame
{
    private (int pos, int score) NextPosAndScore(int pos, int score, int dice)
    {
        var newPos = (pos + dice) % 10;
        var newScore = score + newPos + 1;
        return (newPos, newScore);
    }

    public long Play(int pos1, int pos2)
    {
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
                if (key.p1score >= 21 && value > 0)
                {
                    wins.p1 += value;
                    games[key] = 0;
                }
            }

            newGames = BuildGamesDictionary();
            foreach (var (key, gameCount) in games)
            {
                if (gameCount == 0)
                    continue;

                var s = NextPosAndScore(key.p2pos, key.p2score, 9);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 8);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 7);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 6);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 5);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 4);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;

                s = NextPosAndScore(key.p2pos, key.p2score, 3);
                newGames[(key.p1pos, s.pos, key.p1score, s.score)] += gameCount;
            }

            games = newGames; 
            foreach (var (key, value) in games)
            {
                if (key.p2score >= 21 && value > 0)
                {
                    wins.p2 += value;
                    games[key] = 0;
                }
            }
        }
        
//1st 9
//3st 8
//6st 7
//7st 6
//6st 5
//3st 4
//1st 3

        return Math.Max(wins.p1, wins.p2);
    }

    private Dictionary<(int p1pos, int p2pos, int p1score, int p2score), long> BuildGamesDictionary()
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
}

public class DiracDiceGameScore
{
    public int Pos { get; set; }
    public long Count { get; set; }
    public int Score { get; set; }

    public DiracDiceGameScore(int pos)
    {
        Pos = pos;
        Count = 1;
        Score = 0;
    }
}

public class DiracDiceGame
{
    private int _dice;

    public DiracDiceResult Play(int pos1, int pos2)
    {
        _dice = 0;

        var p1 = new DiracDicePlayer(pos1 - 1);
        var p2 = new DiracDicePlayer(pos2 - 1);

        for (var i = 0; i < 1000; i++)
        {
            var won = Move(p1);
            if (won)
                break;

            won = Move(p2);
            if (won)
                break;
        }

        return new DiracDiceResult(Math.Min(p1.Score, p2.Score), _dice);
    }

    private bool Move(DiracDicePlayer player)
    {
        _dice = player.Move(_dice);
        return player.Score >= 1000;
    }
}

public class DiracDicePlayer
{
    public int Score { get; private set; }
    public int Pos { get; private set; }

    public DiracDicePlayer(int pos)
    {
        Pos = pos;
    }

    public int Move(int dice)
    {
        for (var i = 0; i < 3; i++)
        {
            dice++;
            Pos = (Pos + dice) % 10;
        }

        Score += Pos + 1;

        return dice;
    }
}

public class DiracDiceResult
{
    public int MinScore { get; }
    public int Rolls { get; }
    public int Result => MinScore * Rolls;

    public DiracDiceResult(int minScore, int rolls)
    {
        MinScore = minScore;
        Rolls = rolls;
    }
}

//111 = 3
//112 = 4
//121 = 4
//211 = 4
//113 = 5
//122 = 5
//131 = 5
//212 = 5
//221 = 5
//311 = 5
//123 = 6
//132 = 6
//213 = 6
//222 = 6
//231 = 6
//312 = 6
//321 = 6
//133 = 7
//223 = 7
//232 = 7
//313 = 7
//322 = 7
//331 = 7
//233 = 8
//323 = 8
//332 = 8
//333 = 9

