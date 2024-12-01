using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler039;

[Name("Integer Right Triangle")]
public class Euler039 : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var solutions = FindSolutions(1000);
        
        var groups = solutions.GroupBy(o => o.a + o.b + o.c);
        var perimeterWithMostSolutions = groups.OrderByDescending(o => o.Count()).First();

        return new PuzzleResult(perimeterWithMostSolutions.Key, "e5acdbe3ca4832e6abd355009a432f2e");
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