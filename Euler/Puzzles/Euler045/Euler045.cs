using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler045;

[Name("Triangular, Pentagonal, and Hexagonal")]
public class Euler045 : EulerPuzzle
{
    protected override PuzzleResult Run()
    {
        const int input = 285;
        var i = input + 1;

        while (true)
        {
            var t = Numbers.GetTriangularNumber(i);
            if (Numbers.IsPentagonalNumber(t) && Numbers.IsHexagonalNumber(t))
                return new PuzzleResult(t, "a0326c7014766ece5b2d88116aeb9ff6");
            i++;
        }
    }
}