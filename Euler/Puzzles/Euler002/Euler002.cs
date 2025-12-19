using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler002;

[Name("Even Fibonacci numbers")]
public class Euler002 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var sum = Run(4_000_000);
        return new PuzzleResult(sum, "abd3fbf8c9d403cd14e0a01404ae011d");
    }

    public long Run(long limit)
    {
        var index = 0L;
        var sum = 0L;
        var cache = new Dictionary<long, long>();
        while (true)
        {
            var fib = Numbers.Fibonacci(index, cache);
            if (fib > limit)
                break;

            if(fib % 2 == 0)
                sum += fib;
            index++;
        }

        return sum;
    }
}
