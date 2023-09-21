using Euler.Platform;

namespace Euler.Problems.Problem004;

public class Problem004 : Problem
{
    public override string Name => "Largest palindrome product";

    public override ProblemResult Run()
    {
        var largestPalindrome = Run(100, 999);

        return new ProblemResult(largestPalindrome, 906609);
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