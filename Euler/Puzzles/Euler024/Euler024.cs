using Pzl.Common;
using Pzl.Tools.Combinatorics;

namespace Pzl.Euler.Puzzles.Euler024;

[Name("Lexicographic permutations")]
public class Euler024 : EulerPuzzle
{
    [Puzzle("c8c867235759f60d31cd3afd7b3f1d90")]
    public string Solve() => Solve(10, 1_000_000);
    
    public static string Solve(int digitCount, int nthToFind) => string.Concat(GetPermutations(digitCount)[nthToFind - 1]);

    public static IList<IEnumerable<int>> GetPermutations(int digitCount) => 
        PermutationGenerator.GetPermutations(Enumerable.Range(0, digitCount).ToList());
}