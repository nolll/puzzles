using Puzzles.Common.Numbers;
using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Pzl.Euler.Puzzles.Euler035;

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

        return new PuzzleResult(count, "5363390b461681375e68f3cea9b968df");
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