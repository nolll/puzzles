using Euler.Platform;

namespace Euler.Problems.Problem039;

public class Problem039 : EulerPuzzle
{
    public override string Name => "Integer Right Triangle";

    public override ProblemResult Run()
    {
        var solutions = FindSolutions(1000);
        
        var groups = solutions.GroupBy(o => o.a + o.b + o.c);
        var perimeterWithMostSolutions = groups.OrderByDescending(o => o.Count()).First();

        return new ProblemResult(perimeterWithMostSolutions.Key, 840);
    }

    private static IEnumerable<(int a, int b, int c)> FindSolutions(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            for (var j = 1; j <= n; j++)
            {
                for (var k = 1; k <= n; k++)
                {
                    if (i + j + k <= n && i * i + j * j == k * k)
                    {
                        yield return (i, j, k);
                    }
                }
            }
        }
    }
}