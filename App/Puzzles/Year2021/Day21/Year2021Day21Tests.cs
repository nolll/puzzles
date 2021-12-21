using System;
using App.Common.Computers.IntCode;
using NUnit.Framework;
using NUnit.Framework.Constraints;

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

    private const string Input = @"
";
}

public class DiracDiceGame
{
    public DiracDiceResult Play(int pos1, int pos2)
    {
        var s1 = 0;
        var s2 = 0;
        var p1 = pos1;
        var p2 = pos2;
        var dice = 0;

        for (var i = 0; i < 1000; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                dice++;
                p1 += dice;
                while (p1 > 10)
                    p1 -= 10;
            }

            s1 += p1;

            if (s1 >= 1000)
                break;

            for (var j = 0; j < 3; j++)
            {
                dice++;
                p2 += dice;
                while (p2 > 10)
                    p2 -= 10;
            }

            s2 += p2;

            if (s2 >= 1000)
                break;
        }

        return new DiracDiceResult(Math.Min(s1, s2), dice);
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