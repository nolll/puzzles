using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler014;

[Name("Longest Collatz sequence")]
public class Euler014 : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var result = Run(1_000_000);
        return new PuzzleResult(result, "0450ecdacdabfdc1139c86a81684b5ef");
    }

    private int Run(int limit)
    {
        var longestSequence = (Num: 1, Length: 1);
        var i = 0;

        while (i < limit)
        {
            var sequence = GenerateCollatzSequence(i);

            var length = sequence.Count();

            if (length > longestSequence.Length)
            {
                longestSequence = (i, length);
            }

            i++;
        }

        return longestSequence.Num;
    }

    public IEnumerable<long> GenerateCollatzSequence(long n)
    {
        yield return n;
            
        while (n > 1)
        {
            if (n % 2 == 0)
            {
                n /= 2;
            }
            else
            {
                n = n * 3 + 1;
            }

            yield return n;
        }
    }
}