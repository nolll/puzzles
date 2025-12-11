using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2025.Aoc202509;

[Name("Movie Theater")]
[IsFunToOptimize]
[Comment("Could probably use the corners in a more clever way")]
public class Aoc202509 : AocPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var coords = ParseCoords(input);
        var best = GetAreas(coords).Select(o => o.area).Max();
        
        return new PuzzleResult(best, "703b2c49bc827700bb8947a8bd64d264");
    }

    public PuzzleResult Part2(string input)
    {
        var corners = ParseCoords(input);
        var minx = corners.Min(o => o.X);
        var miny = corners.Min(o => o.Y);
        var filled = new HashSet<(int, int)>();
        corners = corners.Select(o => new Coord(o.X - minx + 1, o.Y - miny + 1)).ToList();
        var mapper = new CoordCompressor(corners);
        var mappedCorners = mapper.MappedCorners;
        
        var w = mappedCorners.Max(o => o.X) + 2;
        var h = mappedCorners.Max(o => o.Y) + 2;
        var grid = new Grid<char>(w, h, '.');

        foreach (var (a, b) in mappedCorners.Zip([..mappedCorners.Skip(1), mappedCorners.First()]))
        {
            var dx = Math.Sign(b.X - a.X);
            var dy = Math.Sign(b.Y - a.Y);
            grid.MoveTo(a);
            
            while (grid.Coord != b)
            { 
                grid.MoveTo(grid.Coord.X + dx, grid.Coord.Y + dy);
                grid.WriteValue('#');
                filled.Add((grid.Coord.X, grid.Coord.Y));
            }
        }
        
        var insideCoord = FindInsideCoord(grid, mappedCorners.First());

        var queue = new Queue<Coord>();
        queue.Enqueue(insideCoord);
        var seen = new HashSet<Coord>();

        while (queue.Count > 0)
        {
            var coord = queue.Dequeue();
            grid.WriteValueAt(coord, '#');
            filled.Add((coord.X, coord.Y));
            var adj = grid.OrthogonalAdjacentCoordsTo(coord).Where(o => !seen.Contains(o) && grid.ReadValueAt(o) != '#');
            foreach (var a in adj)
            {
                seen.Add(a);
                queue.Enqueue(a);
            }
        }

        var areas = GetAreas(corners).OrderByDescending(o => o.area);
        foreach (var item in areas)
        {
            if (IsValidArea(item, mapper, filled))
                return new PuzzleResult(item.area, "83d4cb5ecc9d6a6e763f9d96944b412b");
        }
        
        return PuzzleResult.Empty;
    }

    private static bool IsValidArea((Coord a, Coord b, long area) item, CoordCompressor compressor, HashSet<(int, int)> filled)
    {
        var frombx = Math.Min(item.a.X, item.b.X);
        var fromby = Math.Min(item.a.Y, item.b.Y);
        var tobx = Math.Max(item.a.X, item.b.X);
        var toby = Math.Max(item.a.Y, item.b.Y);
        var (fromx, fromy) = compressor.MapCoord((frombx, fromby));
        var (tox, toy) = compressor.MapCoord((tobx, toby));
            
        for (var y = fromy; y <= toy; y++)
        {
            for (var x = fromx; x <= tox; x++)
            {
                if (!filled.Contains((x, y)))
                    return false;
            }
        }

        return true;
    }
    
    private static List<(Coord a, Coord b, long area)> GetAreas(List<Coord> coords)
    {
        var areas = new List<(Coord a, Coord b, long area)>();
        for (var i = 0; i < coords.Count - 1; i++)
        {
            var a = coords[i];
            for (var j = i + 1; j < coords.Count; j++)
            {
                var b = coords[j];
                long xdiff = Math.Abs(a.X - b.X) + 1;
                long ydiff = Math.Abs(a.Y - b.Y) + 1;
                var area = xdiff * ydiff;
                areas.Add((a, b, area));
            }
        }

        return areas;
    }

    private static List<Coord> ParseCoords(string input) => input.Split(LineBreaks.Single).Select(line => line.Split(',').Select(int.Parse).ToArray())
        .Select(nums => new Coord(nums[0], nums[1]))
        .ToList();

    private static Coord FindInsideCoord(Grid<char> grid, Coord corner)
    {
        List<int[]> deltas = new List<int[]>();
        deltas.Add([1, -1]);
        deltas.Add([1, 1]);
        deltas.Add([-1, 1]);
        deltas.Add([-1, -1]);

        var firstCoord = corner;
        var adjCoords = deltas.Select(o => new Coord(firstCoord.X + o[0], firstCoord.Y + o[1]));
        
        foreach (var adjCoord in adjCoords)
        {
            var x = adjCoord.X;
            var y = adjCoord.Y;
            var crossings = 0;
            while (x < grid.Width)
            {
                if (grid.ReadValueAt(x, y) == '#')
                    crossings++;

                x++;
            }

            if (crossings % 2 != 0)
                return adjCoord;
        }

        throw new Exception("No inside coord was found.");
    }
}