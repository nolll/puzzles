using System.Numerics;
using Common.Puzzles;

namespace Euler.Puzzles.Euler025;

public class Euler025 : EulerPuzzle
{
    public override string Name => "1000-digit Fibonacci number";

    public override PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, 4782);
    }

    public int Run(int digitCount)
    {
        var numbers = new List<BigInteger> {1, 1};
            
        while (true)
        {
            var lastTwo = numbers.TakeLast(2).ToList();
            var next = lastTwo.First() + lastTwo.Last();
            var s = next.ToString();
            numbers.Add(next);
                
            if (s.Length >= digitCount)
                return numbers.Count;
        }
    }
}