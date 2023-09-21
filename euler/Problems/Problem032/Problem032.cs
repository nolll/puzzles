using Euler.Platform;

namespace Euler.Problems.Problem032;

public class Problem032 : Problem
{
    public override string Name => "Pandigital products";

    private const string AllChars = "123456789";

    public override ProblemResult Run()
    {
        const int limit = 2000;
        var pandigitalProducts = new HashSet<int>();

        for (var i = 1; i < limit; i++)
        {
            for (var j = i; j < limit; j++)
            {
                var product = i * j;
                if (!pandigitalProducts.Contains(product) && IsPandigital(i, j, product))
                {
                    pandigitalProducts.Add(product);
                }
            }
        }

        var result = pandigitalProducts.Sum();

        return new ProblemResult(result, 45228);
    }

    public static bool IsPandigital(int a, int b)
    {
        return IsPandigital(a, b, a * b);
    }

    private static bool IsPandigital(int a, int b, int product)
    {
        var s = $"{a}{b}{product}";
        var sorted = string.Concat(s.OrderBy(c => c));
        return sorted == AllChars;
    }
}
