using Pzl.Common;

namespace Pzl.Euler.Puzzles.Euler005;

[Name("Smallest multiple")]
public class Euler005 : EulerPuzzle
{
    [Puzzle("6a929ec1d5586fac0506b20ad87b56e5")]
    public int Solve() => Solve(20);

    public int Solve(int max)
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