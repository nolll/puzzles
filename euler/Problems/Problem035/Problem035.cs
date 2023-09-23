using Common.Numbers;
using Common.Puzzles;
using Common.Strings;
using Euler.Platform;

namespace Euler.Problems.Problem035;

public class Problem035 : EulerPuzzle
{
    public override string Name => "Circular Primes";

    public override PuzzleResult Run()
    {
        var count = 0;
        for (var i = 0; i < 1_000_000; i++)
        {
            var rotations = GetRotations(i);

            if (rotations.All(Numbers.IsPrime))
                count++;
        }

        return new PuzzleResult(count, 55);
    }

    public static IEnumerable<int> GetRotations(int n)
    {
        var s = n.ToString();

        yield return n;

        for (var i = 0; i < s.Length - 1; i++)
        {
            s = s.ShiftLeft();
            yield return int.Parse(s);
        }
    }
}