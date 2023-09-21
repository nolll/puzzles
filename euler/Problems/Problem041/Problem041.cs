using Euler.Common.Combinatorics;
using Euler.Common.Numbers;
using Euler.Platform;

namespace Euler.Problems.Problem041;

public class Problem041 : Problem
{
    public override string Name => "Pandigital Prime";

    public override ProblemResult Run()
    {
        var largest = 0L;
        for (var x = 9; x >= 1; x--)
        {
            var numbers = Enumerable.Range(1, x).ToList();
            var combinations = PermutationGenerator.GetPermutations(numbers);

            foreach (var combination in combinations)
            {
                var n = long.Parse(string.Join("", combination));
                if (n > largest && Numbers.IsPrime(n))
                    largest = n;
            }

            if (largest > 0)
                break;
        }
        
        return new ProblemResult(largest, 7652413);
    }
}