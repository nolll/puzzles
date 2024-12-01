using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq09;

[Name("Big Data?")]
public class Aquaq09 : AquaqPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var numbers = StringReader.ReadLines(input)
            .Select(BigInteger.Parse);
        var result = MultiplyLargeNumbers(numbers);

        return new PuzzleResult(result, "bcead4ceeb598db4924ff4939d43049f");
    }

    public static BigInteger MultiplyLargeNumbers(IEnumerable<BigInteger> numbers) 
        => numbers.Aggregate(new BigInteger(1), BigInteger.Multiply);
}