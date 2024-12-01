using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler013;

[Name("Large sum")]
public class Euler013(string input) : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var result = RunInternal(input);
        return new PuzzleResult(result, "9a8a979a38f81877c39016dde66dda45");
    }

    public string RunInternal(string listOfNumbers)
    {
        var rows = StringReader.ReadLines(listOfNumbers);
        var numbers = rows.Select(BigInteger.Parse);

        var sum = new BigInteger();
        sum = numbers.Aggregate(sum, (current, n) => current + n);

        return sum.ToString()[..10];
    }
}