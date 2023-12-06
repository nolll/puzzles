using Pzl.Tools.Puzzles;

namespace Pzl.Euler.Puzzles.Euler002;

public class Euler002 : EulerPuzzle
{
    public override string Name => "Even Fibonacci numbers";

    protected override PuzzleResult Run()
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