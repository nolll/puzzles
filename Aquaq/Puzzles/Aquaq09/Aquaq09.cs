using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq09;

[Name("Big Data?")]
public class Aquaq09 : AquaqPuzzle
{
    [Puzzle("bcead4ceeb598db4924ff4939d43049f")]
    public BigInteger Run(string input) => MultiplyLargeNumbers(input.Split(LineBreaks.Single).Select(BigInteger.Parse));

    public static BigInteger MultiplyLargeNumbers(IEnumerable<BigInteger> numbers) => 
        numbers.Aggregate(new BigInteger(1), BigInteger.Multiply);
}