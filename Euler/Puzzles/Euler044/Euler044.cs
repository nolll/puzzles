using Puzzles.Common.Puzzles;

namespace Puzzles.Euler.Puzzles.Euler044;

public class Euler044 : EulerPuzzle
{
    public override string Name => "Pentagon Numbers";

    protected override PuzzleResult Run()
    {
        var numberCount = 10_000; // just tried larger numbers until I got it right
        var numberList = GeneratePentagonalNumbers(numberCount);
        var numberSet = numberList.ToHashSet();

        for (var i = 0; i < numberList.Length; i++)
        {
            for (var j = 0; j < i + 1; j++)
            {
                if (i == j)
                    continue;

                var a = numberList[i];
                var b = numberList[j];
                var sum = a + b;

                if (!numberSet.Contains(sum))
                    continue;

                var diff = Math.Abs(a - b);
                if (!numberSet.Contains(diff))
                    continue;

                return new PuzzleResult(diff, "204982446e51e0168bb4850543d28cd6");
            }
        }

        throw new Exception("No result found");
    }

    public static long[] GeneratePentagonalNumbers(int n)
    {
        var list = new List<long>();
        var i = 1L;
        while (i <= n)
        {
            var p = i * (3 * i - 1) / 2;
            list.Add(p);
            i++;
        }

        return list.ToArray();
    }
}