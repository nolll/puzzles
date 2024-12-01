using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler002;

[Name("Even Fibonacci numbers")]
public class Euler002 : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var sum = Run(4_000_000);
        return new PuzzleResult(sum, "abd3fbf8c9d403cd14e0a01404ae011d");
    }

    public int Run(int limit)
    {
        var numbers = new List<int> { 1, 2 };
        while (true)
        {
            var lastNumbers = numbers.TakeLast(2);
            var nextNumber = lastNumbers.Sum();

            if (nextNumber > limit)
                break;
                
            numbers.Add(nextNumber);
        }

        var evenNumbers = numbers.Where(o => o % 2 == 0);
        var sum = evenNumbers.Sum();

        return sum;
    }
}