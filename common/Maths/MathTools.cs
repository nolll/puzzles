namespace Common.Maths;

public static class MathTools
{
    public static long Gcd(long a, long b)
    {
        return b == 0 ? a : Gcd(b, a % b);
    }

    public static long Lcm(params long[] numbers)
    {
        return Lcm((IEnumerable<long>)numbers);
    }

    public static long Lcm(IEnumerable<long> numbers)
    {
        return numbers.Aggregate(Lcm);
    }

    public static long Lcm(long a, long b)
    {
        return System.Math.Abs(a * b) / Gcd(a, b);
    }
}