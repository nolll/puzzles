using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler021;

[Name("Amicable numbers")]
public class Euler021 : EulerPuzzle
{
    public PuzzleResult Run()
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

            if (a == dA)
                continue;
                
            var dB = sums[dA];

            if (dB != a)
                continue;
            
            amicableNumbers.Add(dA);
            amicableNumbers.Add(dB);
        }

        var amicableSum = amicableNumbers.Sum();
            
        return new PuzzleResult(amicableSum, "bfa83952447e586ff82b1adaed0d53ea");
    }

    public static int GetFactorialSum(int n) => Numbers.GetProperDivisors(n).Sum();
}