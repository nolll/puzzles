using System.Numerics;
using Puzzles.common.Combinatorics;
using Puzzles.common.Puzzles;

namespace Puzzles.aquaq.Puzzles.Aquaq26;

public class Aquaq26 : AquaqPuzzle
{
    public override string Name => "Typo Theft";

    protected override PuzzleResult Run()
    {
        var inputNumbers = InputFile.Split(Environment.NewLine)
            .Select(BigInteger.Parse);

        var sum = inputNumbers.Aggregate(BigInteger.Zero, (current, n) => current + FindFirstLargerNumber(n) - n);

        return new PuzzleResult(sum, "36fec1139b2f97e4783a60a6d4756578");
    }

    public static BigInteger FindFirstLargerNumber(BigInteger input)
    {
        var digits = input.ToString();
        
        var numChars = 2;
        while (numChars <= digits.Length)
        {
            var untouchedChars = digits.Substring(0, digits.Length - numChars);
            var charsToMove = digits.Substring(digits.Length - numChars, numChars);
            var positions = Enumerable.Range(0, charsToMove.Length).ToArray();
            var largerNumbers = PermutationGenerator.GetPermutations(positions, positions.Length)
                .Select(o => o.Select(p => charsToMove[p]))
                .Select(o => BigInteger.Parse($"{untouchedChars}{string.Join("", o)}"))
                .Where(o => o > input).ToList();
            if (largerNumbers.Any())
                return largerNumbers.Min();
            numChars++;
        }

        return input;
    }
}