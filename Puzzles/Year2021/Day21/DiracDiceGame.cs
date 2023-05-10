using System;

namespace Aoc.Puzzles.Year2021.Day21;

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