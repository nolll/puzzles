using System.Diagnostics;
using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Maths;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

// Got a little help from Jonathan Paulson again
[Name("The Tickursion")]
public class Ece202613 : EverybodyEventPuzzle
{
    [Puzzle("7cf148f86e2ddb022b403e333a229cd1")]
    public int Part1(string input)
    {
        var (handLine, dirLine, currentLine, moveLine) = input.Split(LineBreaks.Single);
        var handSteps = Numbers.IntsFromString(handLine);
        var dirs = dirLine.Split(' ').Last().Split(':').Select(o => o == "CCW" ? -1 : 1).ToArray();
        var positions = Numbers.IntsFromString(currentLine);
        var moves = Numbers.IntsFromString(moveLine);

        var hands = new List<Hand>();
        var id = 1;
        var lcm = MathTools.Lcm(handSteps);

        for (var i = 0; i < handSteps.Length; i++)
        {
            var multiplier = lcm / handSteps[i];
            hands.Add(new Hand(id, handSteps[i], dirs[i], positions[i], moves[i], multiplier));
            id++;
        }

        var signalCount = 0;
        
        while (hands.Any(o => o.CanMove))
        {
            foreach (var hand in hands) 
                hand.Move();

            for (var i = 0; i < hands.Count; i++)
            {
                for (var j = i + 1; j < hands.Count; j++)
                {
                    if (SendsSignal(lcm, hands[i], hands[j]))
                        signalCount++;
                }
            }
            
            foreach (var hand in hands) 
                hand.Clamp();
        }

        return signalCount;
    }

    private bool SendsSignal(int lcm, Hand h1, Hand h2)
    {
        if (h1.LastPos == h2.LastPos)
            return false;
        
        if (Overlaps(h1.LastPos, h1.Pos, h2.LastPos, h2.Pos))
            return true;
        
        if (Overlaps(h1.LastPos + lcm, h1.Pos + lcm, h2.LastPos, h2.Pos))
            return true;
        
        if (Overlaps(h1.LastPos - lcm, h1.Pos - lcm, h2.LastPos, h2.Pos))
            return true;

        return false;
    }

    private bool Overlaps(int a1, int b1, int a2, int b2)
    {
        double den = b2 - a2 - b1 + a1;
        if (den == 0)
            return false;
        var t = (a1 - a2) / den;
        return t is >= 0 and <= 1;
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }

    [DebuggerDisplay("Id: {Id}, Pos: {Pos}, Steps: {Steps}, Clock: {ClockPos}")]
    private class Hand(int id, int steps, int dir, int pos, int movesLeft, int multiplier)
    {
        public int Id { get; } = id;
        public int Steps { get; } = steps * multiplier;
        public int Pos { get; set; } = pos * multiplier;
        public int LastPos { get; private set; } = pos;
        private int MovesLeft { get; set; } = movesLeft;
        public double ClockPos => Math.Round((double)Pos * 12 / Steps, 2);
        public bool CanMove => MovesLeft > 0;
        public void Clamp() => Pos = (Pos + Steps) % Steps;
        
        public void Move()
        {
            LastPos = Pos;
            if (!CanMove)
                return;
            
            Pos += dir * multiplier;
            MovesLeft -= 1;
        }
    }
}