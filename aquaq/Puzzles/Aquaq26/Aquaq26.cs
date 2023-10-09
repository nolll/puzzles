using Common.Combinatorics;
using Common.Puzzles;
using NUnit.Framework.Constraints;

namespace Aquaq.Puzzles.Aquaq26;

public class Aquaq26 : AquaqPuzzle
{
    public override string Name => "Typo Theft";

    protected override PuzzleResult Run()
    {
        throw new NotImplementedException();
    }

    public static long FindFirstLargerNumber(long input)
    {
        var digits = input.ToString().ToCharArray().Select(o => int.Parse(o.ToString())).ToList();
        var permutations = PermutationGenerator.GetPermutations(digits, digits.Count);
        var minDiff = long.MaxValue;
        var minDiffNum = input;

        foreach (var permutation in permutations)
        {
            var num = int.Parse(string.Join("", permutation));
            var diff = num - input;
            if (diff > 0 && diff < minDiff)
            {
                minDiff = diff;
                minDiffNum = num;
            }
        }

        if (minDiff == long.MaxValue)
            minDiffNum = input;

        return minDiffNum;
    }
}