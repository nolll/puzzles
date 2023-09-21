using common.Numbers;
using common.Strings;
using Euler.Platform;

namespace Euler.Problems.Problem035;

public class Problem035 : EulerPuzzle
{
    public override string Name => "Circular Primes";

    public override ProblemResult Run()
    {
        var count = 0;
        for (var i = 0; i < 1_000_000; i++)
        {
            var rotations = GetRotations(i);

            if (rotations.All(Numbers.IsPrime))
                count++;
        }

        return new ProblemResult(count, 55);
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