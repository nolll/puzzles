using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler034;

public class Euler034 : EulerPuzzle
{
    public override string Name => "Digit Factorials";

    protected override PuzzleResult Run()
    {
        var total = 0;

        // looped to a million but didn't find more than two numbers
        for (var i = 3; i < 50000; i++)
        {
            var sum = GetDigitFactorialSum(i);
            if(i == sum)
            {
                total += i;
            }
        }
        return new PuzzleResult(total, "2464ceb2b2cb7b3a2ecb0a4eab5de58b");
    }

    public static int GetDigitFactorialSum(int n)
    {
        return GetDigits(n)
            .Select(GetFactorial)
            .Sum();
    }

    private static IEnumerable<int> GetDigits(int n) => n
        .ToString()
        .ToCharArray()
        .Select(o => int.Parse(o.ToString()));

    private static int GetFactorial(int n) => 
        Enumerable.Range(1, n).Aggregate(1, (a, b) => a * b);
}