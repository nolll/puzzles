using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq03;

[Name("Short walks")]
public class Aquaq03 : AquaqPuzzle
{
    [Puzzle("3fdb562cfba1d01d5ae2817d476f3120")]
    public int Solve(string input) => new Walker().Walk(input);
}