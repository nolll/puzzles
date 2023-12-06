using Puzzles.Common.Combinatorics;
using Puzzles.Common.Puzzles;

namespace Pzl.Euler.Puzzles.Euler024;

public class Euler024 : EulerPuzzle
{
    public override string Name => "Lexicographic permutations";
    public override bool IsSlow => true;
    public override bool NeedsRewrite => true;

    protected override PuzzleResult Run()
    {
        var result = Run(10, 1_000_000);
        
        return new PuzzleResult(result, "c8c867235759f60d31cd3afd7b3f1d90");
    }

    public static string Run(int digitCount, int nthToFind)
    {
        var permutations = GetPermutations(digitCount);
        return string.Concat(permutations[nthToFind - 1]);
    }

    public static IList<IEnumerable<int>> GetPermutations(int digitCount)
    {
        var numbers = Enumerable.Range(0, digitCount).ToList();
        return PermutationGenerator.GetPermutations(numbers);
    }
}