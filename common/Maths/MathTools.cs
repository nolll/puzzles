using System.Numerics;

namespace Puzzles.common.Maths;

public static class MathTools
{
    public static long Gcd(long a, long b) 
        => b == 0 ? a : Gcd(b, a % b);

    public static long Lcm(params long[] numbers) 
        => Lcm((IEnumerable<long>)numbers);

    public static long Lcm(IEnumerable<long> numbers) 
        => numbers.Aggregate(Lcm);

    public static long Lcm(long a, long b) 
        => Math.Abs(a * b) / Gcd(a, b);

    public static BigInteger ToPowerOf(int num, int power)
    {
        var product = new BigInteger(num);
        for (var i = 1; i < power; i++)
        {
            product *= 2;
        }

        return product;
    }

    public static int Pow(int n, int power)
    {
        var result = n;
        for (var i = 1; i < power; i++)
        {
            result *= n;
        }

        return result;
    }

    public static List<int> GetFactors(int n) 
        => Enumerable.Range(1, n)
            .Where(o => n % o == 0)
            .ToList();

    public static List<(int a, int b)> GetMultiplicationFactors(int n) 
        => Enumerable.Range(1, n)
            .Where(o => n % o == 0)
            .Select(o =>
            {
                var divided = n / o;
                return (Math.Min(o, divided), Math.Max(o, divided));
            })
            .Distinct()
            .ToList();
}