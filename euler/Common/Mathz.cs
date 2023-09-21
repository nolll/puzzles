using System.Numerics;

namespace Euler.Common;

public static class Mathz
{
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
}