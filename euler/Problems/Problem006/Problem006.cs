using Euler.Platform;

namespace Euler.Problems.Problem006;

public class Problem006 : EulerPuzzle
{
    public override string Name => "Sum square difference";

    public override ProblemResult Run()
    {
        var diff = Run(100);

        return new ProblemResult(diff, 25164150);
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