using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Packet Scanners")]
public class Aoc201713 : AocPuzzle
{
    [Puzzle("760af7f4f4ebd6ba3ffa5e5387041857")]
    public int Part1(string input) => ParseLayers(input).Select(GetTotalSeverity).Sum();

    private static int GetTotalSeverity(FirewallLayer layer, int i) => layer.IsCaught(i)
        ? i * layer.Range
        : 0;

    [Puzzle("0659d62185d9ba0a8fc5c0a3cb87e842")]
    public int Part2(string input)
    {
        var wasCaught = true;
        var delay = 0;
        var layers = ParseLayers(input);
        while (wasCaught)
        {
            wasCaught = SendPacketPart2(layers, delay);
            if (wasCaught)
                delay += 1;
        }
        
        return delay;
    }

    private bool SendPacketPart2(IList<FirewallLayer> layers, in int delay)
    {
        for (var i = 0; i < layers.Count; i++)
        {
            var layer = layers[i];
            if (layer.IsCaught(delay + i))
                return true;
        }

        return false;
    }

    private static IList<FirewallLayer> ParseLayers(string input)
    {
        var dictionary = new Dictionary<int, FirewallLayer>();
        var rows = input.Split(LineBreaks.Single);
        foreach (var row in rows)
        {
            var parts = row.Split(": ");
            var index = int.Parse(parts[0]);
            var range = int.Parse(parts[1]);
            var layer = new FirewallLayer(range);
            dictionary.Add(index, layer);
        }

        var lastIndex = dictionary.Keys.Max();
        var layers = new List<FirewallLayer>();
        for (var i = 0; i <= lastIndex; i++)
        {
            var layer = dictionary.TryGetValue(i, out var value)
                ? value
                : new FirewallLayer();
            layers.Add(layer);
        }

        return layers;
    }

    public class FirewallLayer(int range = 0)
    {
        public int Range { get; } = range < 2 ? 0 : range;

        public bool IsCaught(in int iteration)
        {
            if (Range == 0)
                return false;
            if (iteration == 0)
                return true;
            if (iteration < Range)
                return iteration == 0;

            return iteration % (2 * (Range - 1)) == 0;
        }
    }
}