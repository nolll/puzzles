using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler001;

[Name("Multiples of 3 or 5")]
public class Euler001 : EulerPuzzle
{
    public PuzzleResult Run()
    {
        var sum = Run(1000);
        return new PuzzleResult(sum, "b292a6e3a2240594d56a2ccc91c9f797");
    }

    public int Run(int limit)
    {
        var multiplesOf3Or5 = new List<int>();
        for (var i = 0; i < limit; i++)
        {
            if (i % 3 == 0 || i % 5 == 0)
                multiplesOf3Or5.Add(i);
        }

        return multiplesOf3Or5.Sum();
    }
}