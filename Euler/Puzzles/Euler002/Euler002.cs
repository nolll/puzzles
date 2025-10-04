using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler002;

[Name("Even Fibonacci numbers")]
public class Euler002 : EulerPuzzle
{
    public PuzzleResult Run()
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

        return numbers.Where(o => o % 2 == 0).Sum();
    }
}