using Common.Combinatorics;
using Common.Puzzles;

namespace Euler.Puzzles.Euler024;

public class Euler024 : EulerPuzzle
{
    private const int UpperLimit = 28123;

    public override string Name => "Lexicographic permutations";
    public override bool IsSlow => true;
    public override bool NeedsRewrite => true;

    protected override PuzzleResult Run()
    {
        var numbers = Enumerable.Range(0, 10).ToList();
        var permutations = PermutationGenerator.GetPermutations(numbers);
        var strings = permutations.Select(string.Concat<int>).ToList();
        strings = strings.OrderBy(o => o).ToList();
        var result = strings[999999];
            
        return new PuzzleResult(result, null, "7f155b45cb3f0a6e518d59ec348bff84");
    }
}