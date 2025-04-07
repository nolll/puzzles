using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202518;

[Name("Cataclysmic Escape")]
public class Codyssi202518 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var result = RunPart1(input, 10, 15, 60);
        return new PuzzleResult(result, "a8c76203a26abde805a1a11cbd419b79");
    }

    public int RunPart1(string input, int sizex, int sizey, int sizez)
    {
        var rules = input.Split(LineBreaks.Single).Select(Numbers.IntsFromString);

        var d = new Dictionary<(int x, int y, int z, int w), List<(int vx, int vy, int vz, int vw)>>();
        for (var x = 0; x < sizex; x++)
        {
            for (var y = 0; y < sizey; y++)
            {
                for (var z = 0; z < sizez; z++)
                {
                    for (var w = -1; w < 2; w++)
                    {
                        d.Add((x, y, z, w), []);
                    }
                }
            }
        }
        
        foreach (var rule in rules)
        {
            var x = rule[1];
            var y = rule[2];
            var z = rule[3];
            var w = rule[4];
            var divide = rule[5];
            var remainder = rule[6];
            var vx = rule[7];
            var vy = rule[8];
            var vz = rule[9];
            var vw = rule[10];
            
            foreach (var key in d.Keys)
            {
                var sum = key.x * x + key.y * y + key.z * z + key.w * w;

                var res = (sum % divide + divide) % divide; 
                if(res == remainder) 
                    d[key].Add((vx, vy, vz, vw));
            }
        }

        return d.Values.Sum(list => list.Count);
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