using System;
using System.Collections.Generic;
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
        var result = 0;

        Assert.That(result, Is.EqualTo(0));
    }
}

public class RealDiracDiceGame
{
    private Dictionary<(int, int), int> _cache = new();

    public long Play(int pos1, int pos2)
    {

        return 0;
    }

    private Dictionary<(int, int), int> FillCache()
    {
        var d = new Dictionary<(int, int), int>();
        for (var i = 0; i < 10; i++)
        {
            for (var j = 1; j < 4; j++)
            {
                for (var k = 1; k < 4; k++)
                {
                    for (var l = 1; l < 4; l++)
                    {
                        d.Add();
                    }
                }
            }
        }

        return d;
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