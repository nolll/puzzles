using Common.Puzzles;

namespace Euler.Puzzles.Euler038;

public class Euler038 : EulerPuzzle
{
    private const int Limit = 10_000;
    private const int MaxLength = 9;

    public override string Name => "Pandigital Multiples";

    protected override PuzzleResult Run()
    {
        var products = new List<long>();
        var n = 1;
        while (n < Limit)
        {
            var p = GetConcatenatedProduct(n);
            if(p != null)
                products.Add(p.Value);
            n++;
        }

        return new PuzzleResult(products.Max(), "f2a29ede8dc9fae7926dc7a4357ac25e");
    }

    public static long? GetConcatenatedProduct(int n)
    {
        var s = "";
        var multipler = 1;
        while (s.Length < MaxLength)
        {
            s += n * multipler;

            if (s.Length > MaxLength)
                return null;

            multipler++;
        }

        if (s.Contains('0'))
            return null;

        var set = s.ToCharArray().ToHashSet();
        if (set.Count < MaxLength)
            return null;

        return long.Parse(s);
    }
}