using Common.Puzzles;

namespace Euler.Problems.Problem042;

public class Problem042 : EulerPuzzle
{
    public override string Name => "Coded Triangle Numbers";

    public override PuzzleResult Run()
    {
        var words = FileInput.Split(',').Select(o => o.Trim('\"'));
        var triangularNumbers = GetTriangularNumbers(1000).ToHashSet();
        var count = words.Select(GetWordValue).Count(o => triangularNumbers.Contains(o));

        return new PuzzleResult(count, 162);
    }

    public static bool IsTriangular(string word)
    {
        return false;
    }

    public static IEnumerable<int> GetTriangularNumbers(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            yield return (i + 1) * i / 2;
        }
    }

    public static int GetWordValue(string word)
    {
        return word.ToCharArray().Select(o => (int)o - 64).Sum();
    }
}