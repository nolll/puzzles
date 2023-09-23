using Common.Numbers;
using Common.Puzzles;
using Common.Strings;

namespace Euler.Puzzles.Euler035;

public class Euler035 : EulerPuzzle
{
    public override string Name => "Circular Primes";

    protected override PuzzleResult Run()
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