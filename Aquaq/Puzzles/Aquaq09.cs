using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Big Data?")]
public class Aquaq09 : AquaqPuzzle
{
    [Puzzle("bcead4ceeb598db4924ff4939d43049f")]
    public BigInteger Solve(string input) => input.Split(LineBreaks.Single)
        .Select(BigInteger.Parse)
        .Aggregate(new BigInteger(1), BigInteger.Multiply);
}