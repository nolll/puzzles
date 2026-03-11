using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler002;

[Name("Even Fibonacci numbers")]
public class Euler002 : EulerPuzzle
{
    [Puzzle("abd3fbf8c9d403cd14e0a01404ae011d")]
    public long Solve() => Solve(4_000_000);

    public long Solve(long limit)
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
