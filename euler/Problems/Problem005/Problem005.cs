using common.Puzzles;
using Euler.Platform;

namespace Euler.Problems.Problem005;

public class Problem005 : EulerPuzzle
{
    public override string Name => "Smallest multiple";

    public override PuzzleResult Run()
    {
        var smallestMultiple = Run(20);
        return new PuzzleResult(smallestMultiple, 232792560);
    }
    
    public int Run(int max)
    {
        var smallest = 0;
        var i = 0;
        while (smallest == 0)
        {
            i += 2;
            var c = 0;
            for (var p = 2; p <= max; p++)
            {
                if (i % p != 0)
                    break;

                c++;
            }

            if (c == max - 1)
                smallest = i;
        }
            
        return smallest;
    }
}