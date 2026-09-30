using Pzl.Common;

namespace Pzl.Aoc.Puzzles.Aoc2015;

[Name("Let It Snow")]
public class Aoc201525 : AocPuzzle
{
    [Puzzle("d755f54368cc6c88fb38633954dddb9f")]
    public long Solve(string input)
    {
        var p = GetParams(input);
        return FindCodeAt(p.TargetX, p.TargetY);
    }
    
    public long FindCodeAt(int targetX, int targetY)
    {
        long code = 20151125;
        var index = 2;

        while (true)
        {
            for (var x = 1; x <= index; x++)
            {
                var y = index - x + 1;
                code = code * 252533 % 33554393;
                if (x == targetX && y == targetY)
                    return code;
            }
            index++;
        }
    }

    private static Params GetParams(string input)
    {
        var words = input.Replace(".", "").Replace(",", "").Split(' ');
        return new Params(int.Parse(words[18]), int.Parse(words[16]));
    }

    private record Params(int TargetX, int TargetY);
}