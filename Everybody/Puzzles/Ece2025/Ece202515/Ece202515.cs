using Pzl.Common;
using Pzl.Tools.Graphs;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202515;

[Name("Definitely Not a Maze")]
public class Ece202515 : EverybodyEventPuzzle
{
    public PuzzleResult Part1(string input) => new(Solve(input), "4a1a3b7a0e4af4aaf4c4f9e0b95430d4");
    public PuzzleResult Part2(string input) => new(Solve(input), "c9e63859efb2156d5906e433e50285d0");
    public PuzzleResult Part3(string input) => new(Solve(input), "f5a3b1e436cc12fdbacea6f28f381b67");

    public static int Solve(string input)
    {
        var originalCorners = GetCorners(input);
        var coordMapper = new CoordMapper(originalCorners);
        var corners = coordMapper.MappedCorners;
        var grid = BuildGrid(corners);
        var edges = BuildGraph(grid, coordMapper);
        
        return Dijkstra.BestCost(edges, corners.First().Id, corners.Last().Id);
    }

    private static List<Coord> GetCorners(string input)
    {
        var instructions = input.Split(',').Select(o => (o.First(), int.Parse(o[1..])));
        var grid = new Grid<char>(1, 1, '.');
        grid.TurnTo(GridDirection.Up);
        List<Coord> corners = [grid.Coord];
        
        foreach (var (direction, distance) in instructions)
        {
            Action turnFunc = direction == 'L' ? () => grid.TurnLeft() : () => grid.TurnRight();
            turnFunc();
            grid.MoveForward(distance);
            corners.Add(grid.Coord);
        }
        
        var offsetX = corners.Select(o => o.X).Min();
        var offsetY = corners.Select(o => o.Y).Min();
        return corners.Select(o => new Coord(o.X + offsetX, o.Y + offsetY)).ToList();
    }

    private static Grid<char> BuildGrid(List<Coord> corners)
    {
        var smallGrid = new Grid<char>(corners.Max(o => o.X) + 1, corners.Max(o => o.Y) + 1, '.');

        smallGrid.MoveTo(corners.First());
        foreach (var corner in corners.Skip(1))
        {
            var cx = smallGrid.Coord.X;
            var cy = smallGrid.Coord.Y;
            var sx = Math.Min(cx, corner.X);
            var sy = Math.Min(cy, corner.Y);
            var tx = Math.Max(cx, corner.X);
            var ty = Math.Max(cy, corner.Y);
            for (var y = sy; y <= ty; y++)
            {
                for (var x = sx; x <= tx; x++)
                {
                    smallGrid.MoveTo(x, y);
                    smallGrid.WriteValue('#');
                }
            }

            smallGrid.MoveTo(corner);
        }

        var startPoint = corners.First();
        var endPoint = corners.Last();
        
        smallGrid.WriteValueAt(startPoint, '.');
        smallGrid.WriteValueAt(endPoint, '.');

        return smallGrid;
    }

    private static List<GraphEdge> BuildGraph(Grid<char> grid, CoordMapper coordMapper)
    {
        var edges = new List<GraphEdge>();
        foreach (var coord in grid.Coords)
        {
            if (grid.ReadValueAt(coord) == '#')
                continue;
            
            var adj = grid.OrthogonalAdjacentCoordsTo(coord).Where(o => grid.ReadValueAt(o) != '#');
            edges.AddRange(adj.Select(ac => new GraphEdge(coord.Id, ac.Id, coordMapper.CalculateCost(coord, ac))));
        }

        return edges;
    }

    private class CoordMapper
    {
        private const int MaxDistance = 3;
        private readonly Dictionary<(int, int), int> _xcost;
        private readonly Dictionary<(int, int), int> _ycost;
        private readonly Dictionary<int, int> _xmap;
        private readonly Dictionary<int, int> _ymap;
        
        public List<Coord> MappedCorners => field.Select(MapCoord).ToList();
        private Coord MapCoord(Coord coord) => new(_xmap[coord.X], _ymap[coord.Y]);

        public CoordMapper(List<Coord> corners)
        {
            MappedCorners = corners;
            (_xmap, _xcost) = GetMapAndCost(corners.Select(o => o.X).Distinct().Order().ToList());
            (_ymap, _ycost) = GetMapAndCost(corners.Select(o => o.Y).Distinct().Order().ToList());
        }

        private (Dictionary<int, int> map, Dictionary<(int, int), int> cost) GetMapAndCost(List<int> values)
        {
            var m = new Dictionary<int, int>();
            var c = new Dictionary<(int, int), int>();
            var current = values.First();
            m.Add(current, current);
            foreach (var (a, b) in values.Zip(values.Skip(1)))
            {
                if(m.ContainsKey(b))
                    continue;
            
                var distance = b - a;
                var needsShortening = distance > MaxDistance;
                if (needsShortening)
                {
                    var cost = distance - MaxDistance + 1;
                    c.TryAdd((current + 1, current + 2), cost);
                    c.TryAdd((current + 2, current + 1), cost);
                    current += MaxDistance;
                }
                else
                {
                    current += distance;
                }
            
                m.TryAdd(b, current);
            }

            return (m, c);
        }

        // public int CalculateCost(Coord from, Coord to)
        // {
        //     var cost = 0;
        //     if (_xcost.ContainsKey((from.X, to.X)))
        //         cost += _xcost[(from.X, to.X)];
        //     if (_ycost.ContainsKey((from.Y, to.Y)))
        //         cost += _ycost[(from.Y, to.Y)];
        //     
        //     return cost == 0 ? 1 : cost;
        // }
        
        public int CalculateCost(Coord from, Coord to)
        {
            var origFrom = MapCoord(from);
            var origTo = MapCoord(to);
            var cost = 0;
            cost += Math.Abs(origFrom.X - origTo.X);
            cost += Math.Abs(origFrom.Y - origTo.Y);
            return cost;
        }
    }
}