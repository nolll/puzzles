using Common.Puzzles;

namespace Euler.Puzzles.Euler005;

public class Euler005 : EulerPuzzle
{
    public override string Name => "Smallest multiple";

    protected override PuzzleResult Run()
    {
        var smallestMultiple = Run(20);
        return new PuzzleResult(smallestMultiple, "bc0d0a22a7a46212135ed0ba77d22f3a");
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