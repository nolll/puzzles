using System.Drawing;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Castastrophe")]
public class Ece202612 : EverybodyEventPuzzle
{
    [Puzzle("1e10a803d525ec160795a9bed9161106")]
    public int Part1(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var coordToStack = new Dictionary<Coord, int>();
        var stacks = new Dictionary<int, List<Coord>>();

        var stackId = 0;
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v == '.')
                continue;

            if (coordToStack.ContainsKey(coord))
                continue;

            var queue = new Queue<Coord>([coord]);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!coordToStack.TryAdd(current, stackId))
                    continue;
                if(!stacks.ContainsKey(stackId))
                    stacks.Add(stackId, []);
                stacks[stackId].Add(current);
                var adjacent = grid.OrthogonalAdjacentCoordsTo(current).Where(o => !coordToStack.ContainsKey(o) && grid.ReadValueAt(o) == '#');
                foreach (var adj in adjacent)
                {
                    queue.Enqueue(adj);
                }
            }
            
            stackId++;
        }

        return stacks.Values.Sum(g => Math.Min(GetWidth(g), GetHeight(g)));
    }

    [Puzzle("1f9a1df9931e3ffd8d445f9ccc9fe1fa")]
    public int Part2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var coordToStack = new Dictionary<Coord, int>();
        var stacks = new Dictionary<int, List<Coord>>();

        var stackId = 0;
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v == '.')
                continue;

            if (coordToStack.ContainsKey(coord))
                continue;

            var queue = new Queue<Coord>([coord]);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!coordToStack.TryAdd(current, stackId))
                    continue;
                if(!stacks.ContainsKey(stackId))
                    stacks.Add(stackId, []);
                stacks[stackId].Add(current);
                var adjacent = grid.OrthogonalAdjacentCoordsTo(current).Where(o => !coordToStack.ContainsKey(o) && grid.ReadValueAt(o) == '#');
                foreach (var adj in adjacent)
                {
                    queue.Enqueue(adj);
                }
            }
            
            stackId++;
        }
        
        var spellsRequired = new List<int>();
        foreach (var stack in stacks.Values)
        {
            var rows = stack.GroupBy(o => o.Y).Select(o => o.ToList()).ToList();
            var cols = stack.GroupBy(o => o.X).Select(o => o.ToList()).ToList();

            var widths = rows.Select(o => o.ToList()).Select(GetWidth).ToArray();
            var heights = cols.Select(o => o.ToList()).Select(GetHeight).ToArray();
            
            if(widths.Distinct().Count() == 1 && heights.Distinct().Count() == 1)
            {
                spellsRequired.Add(Math.Min(widths.First(), heights.First()));
                continue;
            }

            var result = Math.Min(rows.Count, cols.Count);
            
            var maxWidth = widths.Max();
            var maxHeight = heights.Max();
            var longRows = rows.Count(o => GetWidth(o.ToList()) == maxWidth);
            var longCols = cols.Count(o => GetHeight(o.ToList()) == maxHeight);

            result = Math.Min(result, longRows + longCols);
            spellsRequired.Add(result);
        }

        return spellsRequired.Sum();
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }

    private int GetWidth(List<Coord> coords) => Measure(coords.Max(c => c.X), coords.Min(c => c.X));
    private int GetHeight(List<Coord> coords) => Measure(coords.Max(c => c.Y), coords.Min(c => c.Y));
    private int Measure(int max, int min) => max - min + 1;
}