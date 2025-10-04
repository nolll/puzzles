using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq33;

[Name("Bit of Bully")]
public class Aquaq33 : AquaqPuzzle
{
    public PuzzleResult Run()
    {
        return new PuzzleResult(Run(245701), "3c08f90044660194d3d619fa4c14d736");
    }

    public static long Run(int maxTarget)
    {
        var dartGame = new DartGame();
        var sum = 0L;
        for (var i = 1; i <= maxTarget; i++)
        {
            sum += dartGame.Play(i);
        }

        return sum;
    }
}