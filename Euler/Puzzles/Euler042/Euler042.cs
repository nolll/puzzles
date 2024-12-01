using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler042;

[Name("Coded Triangle Numbers")]
public class Euler042(string legacyInput) : EulerPuzzle
{
    protected override PuzzleResult Run(string input)
    {
        var words = input.Split(',').Select(o => o.Trim('\"'));
        var count = words.Select(GetWordValue).Count(o => Numbers.IsTriangularNumber(o));

        return new PuzzleResult(count, "b8170c241f9f4405debc7e76a6e8623e");
    }

    public static int GetWordValue(string word) 
        => word.ToCharArray().Select(o => o - 64).Sum();
}