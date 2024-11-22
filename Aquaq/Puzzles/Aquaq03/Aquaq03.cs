using Pzl.Common;

namespace Pzl.Aquaq.Puzzles.Aquaq03;

[Name("Short walks")]
public class Aquaq03(string input) : AquaqPuzzle
{
    protected override PuzzleResult Run()
    {
        var walker = new Walker();
        var result = walker.Walk(input);

        return new PuzzleResult(result, "3fdb562cfba1d01d5ae2817d476f3120");
    }
}