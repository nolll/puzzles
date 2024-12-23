using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler021;

[Name("Amicable numbers")]
public class Euler021 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var sums = new Dictionary<int, int>();
        var amicableNumbers = new HashSet<int>();
        for (var i = 3; i < 10000; i++)
        {
            var sum = GetFactorialSum(i);
            sums.Add(i, sum);
        }

        foreach (var a in sums.Keys)
        {
            if (amicableNumbers.Contains(a))
                continue;
                
            var dA = sums[a];
                
            if(!sums.ContainsKey(dA))
                continue;

            var b = dA;

            if (a == b)
                continue;
                
            var dB = sums[dA];

            if (dA == b && dB == a)
            {
                amicableNumbers.Add(dA);
                amicableNumbers.Add(dB);
            }
        }

        var amicableSum = amicableNumbers.Sum();
            
        return new PuzzleResult(amicableSum, "bfa83952447e586ff82b1adaed0d53ea");
    }

    public static int GetFactorialSum(int n)
    {
        var factors = Numbers.GetProperDivisors(n);
        return factors.Sum();
    }
}