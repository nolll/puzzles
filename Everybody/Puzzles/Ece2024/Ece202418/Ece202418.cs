using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2024.Ece202418;

[Name("The Ring")]
public class Ece202418 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var time = Part1And2(input);
        return new PuzzleResult(time, "58a8744a3bef1c6dcbf739d171b22ea5");
    }

    public PuzzleResult Part2(string input)
    {
        var time = Part1And2(input);
        return new PuzzleResult(time, "e709ebaa41c12566e0524c796fac3615");
    }

    private int Part1And2(string input)
    {
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var palmtrees = matrix.FindAddresses('P');
        var current = matrix.Coords.Where(o => (o.X == 0 || o.X == matrix.XMax) && matrix.ReadValueAt(o) == '.')
            .ToHashSet();
        var reached = new HashSet<MatrixAddress>();
        var seen = new HashSet<MatrixAddress>();
        var time = 0;
        while (reached.Count < palmtrees.Count)
        {
            var next = new HashSet<MatrixAddress>();
            foreach (var c in current)
            {
                var adjacent = matrix.OrthogonalAdjacentCoordsTo(c);
                foreach (var adj in adjacent)
                {
                    if (!seen.Add(adj))
                        continue;

                    var v = matrix.ReadValueAt(adj); 
                    if (v != '#') 
                        next.Add(adj);
                    
                    if (matrix.ReadValueAt(adj) == 'P') 
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
        var matrix = MatrixBuilder.BuildCharMatrix(input);
        var palmtrees = matrix.FindAddresses('P');
        var possibleStarts = matrix.FindAddresses('.');
        var hits = possibleStarts.ToDictionary(k => k, _ => new Dictionary<MatrixAddress, int>());
        var allcurrent = palmtrees
            .Select(o => (palmtree: o, current: new HashSet<MatrixAddress> { o }, seen: new HashSet<MatrixAddress>()))
            .ToList();
        
        var time = 1;
        while (hits.Values.Any(o => o.Count < palmtrees.Count))
        {
            var allnext = new List<(MatrixAddress palmtree, HashSet<MatrixAddress> current, HashSet<MatrixAddress> seen)>();
            foreach (var (palmtree, current, seen) in allcurrent)
            {
                var next = new HashSet<MatrixAddress>();
                foreach (var c in current)
                {
                    var adjacent = matrix.OrthogonalAdjacentCoordsTo(c);
                    foreach (var adj in adjacent)
                    {
                        if (!seen.Add(adj))
                            continue;

                        var v = matrix.ReadValueAt(adj); 
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