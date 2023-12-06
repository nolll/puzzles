using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler042;

public class Euler042 : EulerPuzzle
{
    public override string Name => "Coded Triangle Numbers";

    protected override PuzzleResult Run()
    {
        var words = InputFile.Split(',').Select(o => o.Trim('\"'));
        var count = words.Select(GetWordValue).Count(o => Numbers.IsTriangularNumber(o));

        return new PuzzleResult(count, "b8170c241f9f4405debc7e76a6e8623e");
    }

    public static int GetWordValue(string word) 
        => word.ToCharArray().Select(o => o - 64).Sum();
}