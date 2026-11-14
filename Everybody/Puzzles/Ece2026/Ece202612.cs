using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("The Castastrophe")]
public class Ece202612 : EverybodyEventPuzzle
{
    [Puzzle("1e10a803d525ec160795a9bed9161106")]
    public int Part1(string input) => Solve(input);

    [Puzzle("1f9a1df9931e3ffd8d445f9ccc9fe1fa")]
    public int Part2(string input) => Solve(input);

    [Puzzle("cd972c9de45101b7e85edf21bbb14be9")]
    public int Part3(string input) => Solve(input);

    private int Solve(string input) => ParseStacks(input).Sum(CountSpells);

    private int CountSpells(HashSet<Coord> stack)
    {
        var spellCount = 0;
        while (stack.Count > 0)
        {
            var lines = GetLines(stack).OrderByDescending(o => o.Count);
            foreach (var coord in lines.First()) 
                stack.Remove(coord);

            spellCount++;
        }

        return spellCount;
    }

    private List<List<Coord>> GetLines(HashSet<Coord> stack)
    {
        var minx = stack.Min(o => o.X);
        var miny = stack.Min(o => o.Y);
        var maxx = stack.Max(o => o.X);
        var maxy = stack.Max(o => o.Y);

        List<Coord>? currentLine = null;
        var lines = new List<List<Coord>>();
        for (var y = miny; y <= maxy; y++)
        {
            for (var x = minx; x <= maxx; x++)
            {
                var currentCoord = new Coord(x, y);
                if (stack.Contains(currentCoord))
                {
                    currentLine ??= [];
                    currentLine.Add(currentCoord);
                }
                else
                {
                    if (currentLine is not null)
                        lines.Add(currentLine);
                    currentLine = null;
                }
            }

            if (currentLine is not null)
                lines.Add(currentLine);
            currentLine = null;
        }

        for (var x = minx; x <= maxx; x++)
        {
            for (var y = miny; y <= maxy; y++)
            {
                var currentCoord = new Coord(x, y);
                if (stack.Contains(currentCoord))
                {
                    currentLine ??= [];
                    currentLine.Add(currentCoord);
                }
                else
                {
                    if (currentLine is not null)
                        lines.Add(currentLine);
                    currentLine = null;
                }
            }

            if (currentLine is not null)
                lines.Add(currentLine);
            currentLine = null;
        }

        return lines;
    }

    private List<HashSet<Coord>> ParseStacks(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var coordToStack = new Dictionary<Coord, int>();
        var stacks = new Dictionary<int, HashSet<Coord>>();

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
                if (!stacks.ContainsKey(stackId))
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

        return [.. stacks.Values];
    }
}