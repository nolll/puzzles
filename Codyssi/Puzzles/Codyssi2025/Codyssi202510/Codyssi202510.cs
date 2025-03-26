using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202510;

[Name("")]
public class Codyssi202510 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var data = input.Split(LineBreaks.Single)
            .Select(o => o.Replace(" ", "").ToCharArray().Select(p => int.Parse(p.ToString())).ToArray())
            .ToArray();

        var hmin = int.MaxValue;
        var vmin = int.MaxValue;

        for (var i = 0; i < data.Length; i++)
        {
            var hsum = 0;
            var vsum = 0;
            for (var j = 0; j < data[i].Length; j++)
            {
                hsum += data[i][j];
                vsum += data[j][i];
            }

            hmin = Math.Min(hsum, hmin);
            vmin = Math.Min(vsum, vmin);
        }

        var min = Math.Min(hmin, vmin);
        
        return new PuzzleResult(min, "1e10a803d525ec160795a9bed9161106");
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