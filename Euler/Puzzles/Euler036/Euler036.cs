using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Euler.Puzzles.Euler036;

[Name("Double-base Palindromes")]
public class Euler036 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var sum = Enumerable.Range(0, 1_000_000)
            .Where(IsPalindromeInBothBases)
            .Sum();

        return new PuzzleResult(sum, "710d458ea3f1a020b4ad4198a1ec846f");
    }

    public static bool IsPalindromeInBothBases(int n) => 
        n.ToString().IsPalindrome() && Conversion.ToBinary(n).IsPalindrome();
}