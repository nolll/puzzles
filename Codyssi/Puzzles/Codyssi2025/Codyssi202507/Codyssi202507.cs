using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202507;

[Name("Siren Disruption")]
public class Codyssi202507 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var tracks = parts[0].Split(LineBreaks.Single);
        var swaps = parts[1].Split(LineBreaks.Single).Select(o => Numbers.IntsFromString(o.Replace('-', ' ')));
        foreach (var swap in swaps)
        {
            var a = swap[0] - 1;
            var b = swap[1] - 1;
            (tracks[a], tracks[b]) = (tracks[b], tracks[a]);
        }
        var testIndex = int.Parse(parts[2]) - 1;
        return new PuzzleResult(tracks[testIndex], "845956d7694a6519373387779e2244af");
    }

    public PuzzleResult Part2(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var tracks = parts[0].Split(LineBreaks.Single);
        var swaps = parts[1].Split(LineBreaks.Single).Select(o => Numbers.IntsFromString(o.Replace('-', ' ')))
            .ToArray();
        for (var i = 0; i < swaps.Length; i++)
        {
            var current = swaps[i];
            var next = swaps[(i + 1) % swaps.Length];
            var a = current[0] - 1;
            var b = current[1] - 1;
            var c = next[0] - 1;
            (tracks[a], tracks[b], tracks[c]) = (tracks[c], tracks[a], tracks[b]);
        }
        
        var testIndex = int.Parse(parts[2]) - 1;
        return new PuzzleResult(tracks[testIndex], "5b9f5658d2df37a466100d66dd0c6c33");
    }

    public PuzzleResult Part3(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var tracks = parts[0].Split(LineBreaks.Single);
        var swaps = parts[1].Split(LineBreaks.Single).Select(o => Numbers.IntsFromString(o.Replace('-', ' ')))
            .ToArray();

        foreach (var blockStart in swaps)
        {
            var s1 = blockStart[0];
            var s2 = blockStart[1];
            var first = Math.Min(s1, s2);
            var last = Math.Max(s1, s2);
            var diff = last - first;
            var toEnd = tracks.Length + 1 - last;
            var size = Math.Min(diff, toEnd);

            for (var i = 0; i < size; i++)
            {
                var a = first - 1 + i;
                var b = last - 1 + i;
                (tracks[a], tracks[b]) = (tracks[b], tracks[a]);
            }
        }
        
        var testIndex = int.Parse(parts[2]) - 1;
        return new PuzzleResult(tracks[testIndex], "e9f3598b7a6018657eea31863471e5ea");
    }
}