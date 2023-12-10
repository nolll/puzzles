using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler044;

[Name("Pentagon Numbers")]
public class Euler044 : EulerPuzzle
{
    protected override PuzzleResult Run()
    {
        var i = 0;
        while(true)
        {
            for (var j = 1; j < i + 1; j++)
            {
                if (i == j)
                    continue;

                var a = Numbers.GetPentagonalNumber(i);
                var b = Numbers.GetPentagonalNumber(j);
                var sum = a + b;

                if (!Numbers.IsPentagonalNumber(sum))
                    continue;

                var diff = Math.Abs(a - b);
                if (!Numbers.IsPentagonalNumber(diff))
                    continue;

                return new PuzzleResult(diff, "204982446e51e0168bb4850543d28cd6");
            }

            i++;
        }
    }
}