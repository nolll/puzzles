using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler032;

[Name("Pandigital products")]
public class Euler032 : EulerPuzzle
{
    private const string AllChars = "123456789";

    public PuzzleResult Run()
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

        return new PuzzleResult(result, "735c4542e52acbb81533403307c46237");
    }

    public static bool IsPandigital(int a, int b) => IsPandigital(a, b, a * b);

    private static bool IsPandigital(int a, int b, int product) => 
        string.Concat($"{a}{b}{product}".OrderBy(c => c)) == AllChars;
}
