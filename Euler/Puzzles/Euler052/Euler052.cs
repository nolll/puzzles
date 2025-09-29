using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler052;

[Name("Permuted Multiples")]
public class Euler052 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var n = 1;

        while (true)
        {
            var digits = GetDigits(n);
            var isValid = true;
            
            for (var m = 2; m <= 6; m++)
            {
                var c = n * m;
                if (GetDigits(c) == digits)
                    continue;
                
                isValid = false;
                break;
            }

            if (isValid)
                return new PuzzleResult(n, "7e25d491fc51dd8d228120bc98f3eb50");

            n++;
        }
    }

    private static string GetDigits(int n) => string.Join("", n.ToString().ToCharArray().Order());
}