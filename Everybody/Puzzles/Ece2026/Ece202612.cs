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
        var coordToGroup = new Dictionary<Coord, int>();
        var groups = new Dictionary<int, List<Coord>>();

        var groupId = 0;
        foreach (var coord in grid.Coords)
        {
            var v = grid.ReadValueAt(coord);
            if (v == '.')
                continue;

            if (coordToGroup.ContainsKey(coord))
                continue;

            var queue = new Queue<Coord>([coord]);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (!coordToGroup.TryAdd(current, groupId))
                    continue;
                if(!groups.ContainsKey(groupId))
                    groups.Add(groupId, []);
                groups[groupId].Add(current);
                var adjacent = grid.OrthogonalAdjacentCoordsTo(current).Where(o => !coordToGroup.ContainsKey(o) && grid.ReadValueAt(o) == '#');
                foreach (var adj in adjacent)
                {
                    queue.Enqueue(adj);
                }
            }
            
            groupId++;
        }

        return groups.Values.Sum(g => Math.Min(g.Max(c => c.X) - g.Min(c => c.X) + 1, g.Max(c => c.Y) - g.Min(c => c.Y) + 1));
    }

    [Puzzle("")]
    public int Part2(string input)
    {
        return 0;
    }

    [Puzzle("")]
    public int Part3(string input)
    {
        return 0;
    }
}