using Pzl.Common;
using Pzl.Tools.Numbers;

namespace Pzl.Euler.Puzzles.Euler042;

[Name("Coded Triangle Numbers")]
public class Euler042 : EulerPuzzle
{
    [Puzzle("b8170c241f9f4405debc7e76a6e8623e")]
    public int Solve(string input) => input.Split(',')
        .Select(o => o.Trim('\"'))
        .Select(GetWordValue)
        .Count(o => Numbers.IsTriangularNumber(o));

    public static int GetWordValue(string word) => word.ToCharArray().Select(o => o - 64).Sum();
}