using Pzl.Common;

namespace Pzl.Everybody.Puzzles.Everybody14;

[Name("")]
public class Everybody14 : EverybodyPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var y = 0;
        var miny = 0;
        var maxy = 0;

        foreach (var instr in input.Split(','))
        {
            var v = int.Parse(instr[1..]);
            if (instr.StartsWith("U"))
                y += v;
            else if (instr.StartsWith("D")) 
                y -= v;

            miny = Math.Min(y, miny);
            maxy = Math.Max(y, maxy);
        }

        var result = maxy - miny;
        
        return new PuzzleResult(result, "4d7ad96354959558ed0b95fa70be777c");
    }

    public PuzzleResult Part2(string input)
    {
        return new PuzzleResult(0);
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}