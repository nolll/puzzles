using Puzzles.common.Puzzles;

namespace Puzzles.euler.Puzzles.Euler042;

public class Euler042 : EulerPuzzle
{
    public override string Name => "Coded Triangle Numbers";

    protected override PuzzleResult Run()
    {
        var words = InputFile.Split(',').Select(o => o.Trim('\"'));
        var triangularNumbers = GetTriangularNumbers(1000).ToHashSet();
        var count = words.Select(GetWordValue).Count(o => triangularNumbers.Contains(o));

        return new PuzzleResult(count, "b8170c241f9f4405debc7e76a6e8623e");
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