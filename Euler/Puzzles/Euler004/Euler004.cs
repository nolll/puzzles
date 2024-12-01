using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler004;

[Name("Largest palindrome product")]
public class Euler004 : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var largestPalindrome = Run(100, 999);

        return new PuzzleResult(largestPalindrome, "bf66c93b5263ee5be1d362b688a9a581");
    }
    
    public int Run(int minFactor, int maxFactor)
    {
        var tried = new HashSet<(int, int)>();
        var largestPalindrome = 0;

        for (var a = minFactor; a <= maxFactor; a++)
        {
            for (var b = minFactor; b <= maxFactor; b++)
            {
                var min = Math.Min(a, b);
                var max = Math.Max(a, b);

                if (!tried.Contains((min, max)))
                {
                    tried.Add((min, max));
                    var product = min * max;
                    var str = product.ToString();
                    var reverse = string.Concat(str.ToCharArray().Reverse());

                    if (str == reverse && product > largestPalindrome)
                    {
                        largestPalindrome = product;
                    }
                }
            }
        }

        return largestPalindrome;
    }
}