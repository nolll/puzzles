using Pzl.Common;
using Pzl.Tools.Debug;
using Pzl.Tools.Maths;

namespace Pzl.Euler.Puzzles.Euler064;

[Name("Powerful Digit Counts")]
public class Euler064 : EulerPuzzle
{
    // Don't really understand this one. Tried to code along with
    // https://martin-ueding.de/posts/project-euler-solution-64-odd-period-square-roots
    public PuzzleResult Run()
    {
        var result = 0;
        for (var n = 2L; n <= 10_000L; n++)
        {
            var cf = GetContinuedFraction(n);
            if (cf.cycle.Length % 2 != 0)
                result++;
        }
        
        return new PuzzleResult(result, "44e91baf8c82f4b22ddd38842c45659b");
    }

    public static (long a0, long[] cycle) GetContinuedFraction(long n)
    {
        var floor = (long)Math.Sqrt(n);
        if ((long)Math.Pow(floor, 2) == n)
            return (floor, []);

        List<long> results = [floor];
        var states = new List<(long, long)>();
        var c = floor;
        var b = 1L;
        while (true)
        {
            var d = n - (int)Math.Pow(c, 2);
            var gcd = MathTools.Gcd(b, d);
            b /= gcd;
            d /= gcd;
            var split = (floor + c) / d;
            var a = split * b;
            c -= split * d;
            c = -c;
            b = d;
            var state = (b, c);
            results.Add(a);
            if (states.Contains(state))
                break;
            states.Add(state);
        }
        
        return (results.First(), results.Skip(1).SkipLast(1).ToArray());
    }
}