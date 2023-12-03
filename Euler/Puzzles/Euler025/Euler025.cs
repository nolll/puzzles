using System.Numerics;
using Puzzles.Common.Puzzles;

namespace Puzzles.Euler.Puzzles.Euler025;

public class Euler025 : EulerPuzzle
{
    public override string Name => "1000-digit Fibonacci number";

    protected override PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, "b0f9f78357a59417863c853ccb8cff75");
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