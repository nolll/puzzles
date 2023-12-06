using Pzl.Tools.Numbers;
using Pzl.Tools.Puzzles;

namespace Pzl.Euler.Puzzles.Euler045;

public class Euler045 : EulerPuzzle
{
    public override string Name => "Triangular, Pentagonal, and Hexagonal";

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