using System.Numerics;
using Pzl.Common;
using Pzl.Tools.Combinatorics;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles;

[Name("Typo Theft")]
public class Aquaq26 : AquaqPuzzle
{
    [Puzzle("36fec1139b2f97e4783a60a6d4756578")]
    public BigInteger Solve(string input) => input.Split(LineBreaks.Single)
        .Select(BigInteger.Parse)
        .Aggregate(BigInteger.Zero, (current, n) => current + FindFirstLargerNumber(n) - n);

    public BigInteger FindFirstLargerNumber(BigInteger input)
    {
        var digits = input.ToString();
        
        var numChars = 2;
        while (numChars <= digits.Length)
        {
            var untouchedChars = digits[..^numChars];
            var charsToMove = digits.Substring(digits.Length - numChars, numChars);
            var positions = Enumerable.Range(0, charsToMove.Length).ToArray();
            var largerNumbers = PermutationGenerator.GetPermutations(positions, positions.Length)
                .Select(o => o.Select(p => charsToMove[p]))
                .Select(o => BigInteger.Parse($"{untouchedChars}{string.Concat(o)}"))
                .Where(o => o > input).ToList();
            
            if (largerNumbers.Count != 0)
                return largerNumbers.Min();
            
            numChars++;
        }

        return input;
    }
}