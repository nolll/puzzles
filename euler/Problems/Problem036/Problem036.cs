using common.Numbers;
using common.Strings;
using Euler.Platform;

namespace Euler.Problems.Problem036;

public class Problem036 : EulerPuzzle
{
    public override string Name => "Double-base Palindromes";

    public override ProblemResult Run()
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

        return new ProblemResult(sum, 872187);
    }
}