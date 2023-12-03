using Puzzles.Common.Numbers;
using Puzzles.Common.Puzzles;

namespace Puzzles.Euler.Puzzles.Euler037;

public class Euler037 : EulerPuzzle
{
    private const int Target = 11;
    private const int Initial = 8;

    public override string Name => "Truncatable Primes";

    protected override PuzzleResult Run()
    {
        var count = 0;
        var sum = 0;
        var i = Initial;
        while(count < Target)
        {
            if (Numbers.IsPrime(i) && IsTruncatable(i))
            {
                count++;
                sum += i;
            }

            i++;
        }

        return new PuzzleResult(sum, "89fae62491c03802ab17f278061a576d");
    }

    public static bool IsTruncatable(int n)
    {
        return IsTruncatableLeft(n) && IsTruncatableRight(n);
    }

    private static bool IsTruncatableLeft(int n) => IsTruncatable(n, s => s[1..]);
    private static bool IsTruncatableRight(int n) => IsTruncatable(n, s => s[..^1]);

    private static bool IsTruncatable(int n, Func<string, string> truncateFunc)
    {
        var s = n.ToString();
        while (s.Length > 1)
        {
            s = truncateFunc(s);
            var num = int.Parse(s);
            if (!Numbers.IsPrime(num))
            {
                return false;
            }
        }

        return true;
    }
}