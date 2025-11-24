using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202418;

[Name("The Ring")]
public class Ece202418 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Part1And2(input), "58a8744a3bef1c6dcbf739d171b22ea5");
    public PuzzleResult Part2(string input) => new(Part1And2(input), "e709ebaa41c12566e0524c796fac3615");

    private int Part1And2(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var palmtrees = grid.FindAddresses('P');
        var current = grid.Coords.Where(o => (o.X == 0 || o.X == grid.XMax) && grid.ReadValueAt(o) == '.')
            .ToHashSet();
        var reached = new HashSet<Coord>();
        var seen = new HashSet<Coord>();
        var time = 0;
        while (reached.Count < palmtrees.Count)
        {
            var next = new HashSet<Coord>();
            foreach (var c in current)
            {
                var adjacent = grid.OrthogonalAdjacentCoordsTo(c);
                foreach (var adj in adjacent)
                {
                    if (!seen.Add(adj))
                        continue;

                    var v = grid.ReadValueAt(adj); 
                    if (v != '#') 
                        next.Add(adj);
                    
                    if (grid.ReadValueAt(adj) == 'P') 
                        reached.Add(adj);
                }
            }

            current = next;
            
            time++;
        }

        return time;
    }

    public PuzzleResult Part3(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var palmtrees = grid.FindAddresses('P');
        var possibleStarts = grid.FindAddresses('.');
        var hits = possibleStarts.ToDictionary(k => k, _ => new Dictionary<Coord, int>());
        var allcurrent = palmtrees
            .Select(o => (palmtree: o, current: new HashSet<Coord> { o }, seen: new HashSet<Coord>()))
            .ToList();
        
        var time = 1;
        while (hits.Values.Any(o => o.Count < palmtrees.Count))
        {
            var allnext = new List<(Coord palmtree, HashSet<Coord> current, HashSet<Coord> seen)>();
            foreach (var (palmtree, current, seen) in allcurrent)
            {
                var next = new HashSet<Coord>();
                foreach (var c in current)
                {
                    var adjacent = grid.OrthogonalAdjacentCoordsTo(c);
                    foreach (var adj in adjacent)
                    {
                        if (!seen.Add(adj))
                            continue;

                        var v = grid.ReadValueAt(adj); 
                        if (v != '#') 
                            next.Add(adj);
                
                        if (v == '.' && !hits[adj].ContainsKey(palmtree)) 
                            hits[adj].Add(palmtree, time);
                    }
                }

                allnext.Add((palmtree, next, seen));
            }

            allcurrent = allnext;
            time++;
        }

        var best = hits.Values.Select(o => o.Values.Sum()).Min();

        return new PuzzleResult(best, "393186167939da99eb22eccf3da6b31b");
    }
}