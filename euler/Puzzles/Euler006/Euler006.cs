using Common.Puzzles;

namespace Euler.Puzzles.Euler006;

public class Euler006 : EulerPuzzle
{
    public override string Name => "Sum square difference";

    protected override PuzzleResult Run()
    {
        var diff = Run(100);

        return new PuzzleResult(diff, "867380888952c39a131fe1d832246ecc");
    }
        
    public int Run(int numCount)
    {
        var numbers = Enumerable.Range(1, numCount).ToList();
        var sum = numbers.Sum();
        var squareOfSum = sum * sum;
        var sumOfSquares = numbers.Select(o => o * o).Sum();
        var diff = squareOfSum - sumOfSquares;
            
        return diff;
    }
}