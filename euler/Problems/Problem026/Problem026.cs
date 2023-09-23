using System.Numerics;
using System.Text.RegularExpressions;
using Common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem026;

public class Problem026 : EulerPuzzle
{
    public override string Name => "Reciprocal cycles";
    public override string Comment => "My original solution involved regex and is left as the RunSlow method. At least I learned something!";

    public override PuzzleResult Run()
    {
        var result = Run(999);
        return new PuzzleResult(result, 983);
    }

    public int Run(int maxDivisor)
    {
        var sequenceLength = 0;
        var numberWithlongestSequence = 0;

        for (var i = maxDivisor; i > 1; i--)
        {
            if (sequenceLength >= i)
            {
                break;
            }

            var foundRemainders = new int[i];
            var value = 1;
            var position = 0;

            while (foundRemainders[value] == 0 && value != 0)
            {
                foundRemainders[value] = position;
                value *= 10;
                value %= i;
                position++;
            }

            if (position - foundRemainders[value] > sequenceLength)
            {
                sequenceLength = position - foundRemainders[value];
                numberWithlongestSequence = i;
            }
        }

        return numberWithlongestSequence;
    }

    private int RunSlow(int maxDivisor)
    {
        var divisor = 2;

        var multiplier = BigInteger.Pow(10, 1999);
        var maxRepeatLength = 0;
        var numberWithLongestRepeat = 0;

        while (divisor <= maxDivisor)
        {
            var n = multiplier / divisor;
            var s = n.ToString();
            s = s[..^1];
            var lastChar = s.Last();
            s = s.TrimEnd(lastChar);
            var repeatLength = GetRepeatLength(s);
            if (repeatLength > maxRepeatLength)
            {
                maxRepeatLength = repeatLength;
                numberWithLongestRepeat = divisor;
            }

            divisor++;
        }

        return numberWithLongestRepeat;
    }

    private static int GetRepeatLength(string input)
    {
        if (input.Length == 0)
            return 0;

        var repeatLength = 0;
        var regex = new Regex("^(.+?)(?:\\1)+");
        var s = input;
        while (s.Length > 0)
        {
            var matches = regex.Match(s);
            var match = matches.Groups.Count > 0
                ? matches.Groups[1].Value
                : null;

            if (match?.Length > repeatLength)
                repeatLength = match.Length;

            s = s[1..];
        }

        return repeatLength;
    }
}