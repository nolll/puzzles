using Pzl.Common;
using Pzl.Tools.Strings;

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
        var seen = new HashSet<(int x, int y, int z)>();

        var lines = input.Split(LineBreaks.Single);
        foreach (var line in lines)
        {
            var x = 0;
            var y = 0;
            var z = 0;
            
            foreach (var instr in line.Split(','))
            {
                var v = int.Parse(instr[1..]);
                if (instr.StartsWith("R"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("L"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        x--;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("U"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("D"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        y--;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("F"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z++;
                        seen.Add((x, y, z));
                    }
                }
                else if (instr.StartsWith("B"))
                {
                    for (var i = 0; i < v; i++)
                    {
                        z--;
                        seen.Add((x, y, z));
                    }
                }
            }   
        }

        var result = seen.Count;
        
        return new PuzzleResult(result, "1ceb1e594b0f47c1b64f940bb505f9ce");
    }

    public PuzzleResult Part3(string input)
    {
        return new PuzzleResult(0);
    }
}