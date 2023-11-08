using Common.Numbers;
using Common.Puzzles;
using Common.Strings;

namespace Euler.Puzzles.Euler036;

public class Euler036 : EulerPuzzle
{
    public override string Name => "Double-base Palindromes";

    protected override PuzzleResult Run()
    {
        var sum = 0;
        for (var i = 0; i < 1_000_000; i++)
        {
            var s = i.ToString();
            if (s.IsPalindrome())
            {
                var binary = Conversion.ToBinary(i);
                if (binary.IsPalindrome())
                    sum += i;
            }
        }

        return new PuzzleResult(sum, "710d458ea3f1a020b4ad4198a1ec846f");
    }
}