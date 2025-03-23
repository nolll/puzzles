using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202507;

[Name("Siren Disruption")]
public class Codyssi202507 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var (tracks, swaps, testIndex) = Parse(input);
        
        foreach (var swap in swaps)
        {
            var a = swap[0];
            var b = swap[1];
            (tracks[a], tracks[b]) = (tracks[b], tracks[a]);
        }
        
        return new PuzzleResult(tracks[testIndex], "845956d7694a6519373387779e2244af");
    }

    public PuzzleResult Part2(string input)
    {
        var (tracks, swaps, testIndex) = Parse(input);
        var swapCount = swaps.Length;
        
        for (var i = 0; i < swapCount; i++)
        {
            var current = swaps[i];
            var next = swaps[(i + 1) % swapCount];
            var a = current[0];
            var b = current[1];
            var c = next[0];
            (tracks[a], tracks[b], tracks[c]) = (tracks[c], tracks[a], tracks[b]);
        }
        
        return new PuzzleResult(tracks[testIndex], "5b9f5658d2df37a466100d66dd0c6c33");
    }

    public PuzzleResult Part3(string input)
    {
        var (tracks, swaps, testIndex) = Parse(input);

        foreach (var blockStart in swaps)
        {
            var s1 = blockStart[0];
            var s2 = blockStart[1];
            var first = Math.Min(s1, s2);
            var last = Math.Max(s1, s2);
            var size = Math.Min(Math.Abs(s1 - s2), tracks.Length - last);

            for (var i = 0; i < size; i++)
            {
                var a = first + i;
                var b = last + i;
                (tracks[a], tracks[b]) = (tracks[b], tracks[a]);
            }
        }
        
        return new PuzzleResult(tracks[testIndex], "e9f3598b7a6018657eea31863471e5ea");
    }

    private static (int[] tracks, int[][] swaps, int testIndex) Parse(string input)
    {
        var parts = input.Split(LineBreaks.Double);
        var tracks = parts[0].Split(LineBreaks.Single).Select(int.Parse).ToArray();
        var swaps = parts[1].Split(LineBreaks.Single)
            .Select(o => Numbers.IntsFromString(o.Replace('-', ' ')).Select(p => p - 1).ToArray())
            .ToArray();
        var testIndex = int.Parse(parts[2]) - 1;

        return (tracks, swaps, testIndex);
    }
}