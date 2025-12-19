using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler025;

[Name("1000-digit Fibonacci number")]
public class Euler025 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var result = Run(1000);
        return new PuzzleResult(result, "b0f9f78357a59417863c853ccb8cff75");
    }

    public BigInteger Run(int digitCount)
    {
        var index = new BigInteger(0);
        var cache = new Dictionary<BigInteger, BigInteger>();
        while (true)
        {
            var fib = Numbers.Fibonacci(index, cache);
            var s = fib.ToString();
            
            if (s.Length >= digitCount)
                break;

            index++;
        }

        return index;
    }
}