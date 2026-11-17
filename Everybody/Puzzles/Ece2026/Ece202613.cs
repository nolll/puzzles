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
    public long Part1(string input) => SolveOne(input);

    [Puzzle("9d35aad7b08669b7bf272bf91e0614d1")]
    public long Part2(string input) => input.Split(LineBreaks.Double).Sum(SolveOne);

    [Puzzle("502f16ba0a524e07f5fb7715e99f64c2")]
    public long Part3(string input) => input.Split(LineBreaks.Double).Sum(SolveOne);

    private long SolveOne(string input)
    {
        var (handLine, dirLine, currentLine, moveLine) = input.Split(LineBreaks.Single);
        var handSteps = Numbers.IntsFromString(handLine);
        var dirs = dirLine.Split(' ').Last().Split(':').Select(o => o == "CCW" ? -1 : 1).ToArray();
        var positions = Numbers.IntsFromString(currentLine);
        var moves = Numbers.LongsFromString(moveLine);

        var hands = new List<Hand>();
        var lcm = MathTools.Lcm(handSteps);

        for (var i = 0; i < handSteps.Length; i++)
        {
            var multiplier = lcm / handSteps[i];
            hands.Add(new Hand(handSteps[i], dirs[i], positions[i], moves[i], multiplier));
        }

        var time = 0L;
        var signals = 0L;

        var seen = new Dictionary<string, (long, long)>();
        while (time < hands.Max(o => o.Moves))
        {
            foreach (var hand in hands) 
                hand.Move(time);

            for (var i = 0; i < hands.Count; i++)
            {
                for (var j = i + 1; j < hands.Count; j++)
                {
                    if (SendsSignal(lcm, hands[i], hands[j]))
                        signals++;
                }
            }

            foreach (var hand in hands)
                hand.Clamp();

            var key = GetCacheKey(hands, time);

            if (seen.TryGetValue(key, out var tpl))
            {
                var (os, ot) = tpl;
                var signalDiff = signals - os;
                var timeDiff = time - ot;

                if (signalDiff > 0 && timeDiff > 0)
                {
                    var target = hands.Where(o => o.Moves >= time).Min(o => o.Moves);
                    var iterationsToSkip = (target - time - 1) / timeDiff;
                    
                    signals += iterationsToSkip * signalDiff;
                    time += iterationsToSkip * timeDiff;
                }
            }

            seen.TryAdd(key, (signals, time));
            time++;
        }

        return signals;
    }

    private static string GetCacheKey(List<Hand> hands, long time)
    {
        var handsKey = string.Join(',', hands.Select(o => o.Pos));
        var movesKey = string.Join(',', hands.Select(o => o.Moves < time));
        return $"{handsKey}|{movesKey}";
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
    
    private class Hand(int steps, int dir, int pos, long movesLeft, int multiplier)
    {
        private int Steps { get; } = steps * multiplier;
        public int Pos { get; private set; } = pos * multiplier;
        public int LastPos { get; private set; } = pos;
        public long Moves { get; } = movesLeft;
        public void Clamp() => Pos = (Pos + Steps) % Steps;
        
        public void Move(long time)
        {
            LastPos = Pos;
            if (time < Moves)
                Pos += dir * multiplier;
        }
    }
}