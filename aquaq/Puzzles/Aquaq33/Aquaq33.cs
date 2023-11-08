using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq33;

public class Aquaq33 : AquaqPuzzle
{
    public override string Name => "Bit of Bully";

    protected override PuzzleResult Run()
    {
        return new PuzzleResult(Run(245701), "ec010b488c836479c6d86af512a76ba5");
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