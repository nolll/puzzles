using System.Text.RegularExpressions;

namespace Pzl.Tools.Numbers;

public static class Numbers
{
    private static readonly Regex DigitRegex = new("(-?\\d+)");

    public static IEnumerable<int> FindPrimesBelow(int limit)
    {
        var primes = new List<int> {2};

        for (var i = 3; i < limit; i += 2)
        {
            var root = Math.Sqrt(i);
            var found = false;
                
            for (int j = 0, count = primes.Count; j < count; j++)
            {
                int divisor;
                if ((divisor = primes[j]) > root)
                    break;

                if ((i % divisor) == 0)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
                primes.Add(i);
        }

        return primes;
    }

    public static bool IsPrime(int n) => IsPrime((long)n);

    public static bool IsPrime(long n)
    {
        if (n <= 1)
            return false;

        if (n == 2)
            return true;

        if (n % 2 == 0)
            return false;

        var upperBound = (long)Math.Floor(Math.Sqrt(n));

        for (var i = 3; i <= upperBound; i += 2)
            if (n % i == 0)
                return false;

        return true;
    }

    public static long LargestPrimeFactor(long num)
    {
        long largest = 0;

        if (num % 2 == 0)
        {
            largest = 2;
            while (num % 2 == 0)
            {
                num /= 2;
            }
        }

        for (long i = 3; i <= Math.Sqrt(num); i += 2)
        {
            while (num % i == 0)
            {
                largest = i;
                num /= i;
            }
        }

        if (num > largest)
            largest = num;

        return largest;
    }

    public static IEnumerable<int> GetAllDivisors(int n)
    {
        for (var i = 1; i * i <= n; i++)
        {
            if (n % i != 0) 
                continue;
            
            yield return i;
            if (i != n / i)
                yield return n / i;
        }
    }
    
    public static IEnumerable<int> GetProperDivisors(int x) => 
        GetAllDivisors(x).OrderBy(o => o).SkipLast(1);

    public static bool IsPandigital1Through9(long n)
    {
        var s = n.ToString();

        if (s.Length > 9)
            return false;

        var length = s.Length;

        for (var i = 1; i <= length; i++)
        {
            if (!s.Contains(i.ToString()))
                return false;
        }

        return true;
    }

    public static bool IsPandigital0Through9(long n)
    {
        var s = n.ToString();

        if (s.Length > 10)
            return false;

        var length = s.Length - 1;

        for (var i = 0; i <= length; i++)
        {
            if (!s.Contains(i.ToString()))
                return false;
        }

        return true;
    }

    public static long GetTriangularNumber(long n) => n * (n + 1) / 2;
    public static bool IsTriangularNumber(long x) => (Math.Sqrt(8 * x + 1) - 1) % 2 == 0;
    public static long GetPentagonalNumber(long n) => n * (3 * n - 1) / 2;
    public static bool IsPentagonalNumber(long x) => (Math.Sqrt(24 * x + 1) + 1) % 6 == 0;
    public static long GetHexagonalNumber(long n) => n * (2 * n - 1);
    public static bool IsHexagonalNumber(long x) => (Math.Sqrt(8 * x + 1) + 1) % 4 == 0;

    public static int[] IntsFromString(string s) => 
        DigitRegex.Matches(s).Select(o => int.Parse(o.ToString())).ToArray();

    public static long[] LongsFromString(string s) => 
        DigitRegex.Matches(s).Select(o => long.Parse(o.ToString())).ToArray();
}