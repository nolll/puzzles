using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler006;

[Name("Sum square difference")]
public class Euler006 : EulerPuzzle
{
    public PuzzleResult Run(string input)
    {
        var diff = Run(100);
        return new PuzzleResult(diff, "87e872f8edddae501e3813163ca22680");
    }
        
    public int Run(int numCount)
    {
        var numbers = Enumerable.Range(1, numCount).ToList();
        var sum = numbers.Sum();
        return sum * sum - numbers.Select(o => o * o).Sum();
    }
}