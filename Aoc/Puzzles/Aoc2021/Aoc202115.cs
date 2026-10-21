using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Chiton")]
public class Aoc202115 : AocPuzzle
{
    [Puzzle("044f1b14974612cad17255d7683d0892")]
    public int Part1(string input) => FindRiskLevel(GridBuilder.BuildIntGridFromNonSeparated(input), []);

    [Puzzle("99cda5f07b0381340587915a1e9f5cb2")]
    public int Part2(string input) => FindRiskLevel(BuildLargeGrid(GridBuilder.BuildIntGridFromNonSeparated(input)), []);

    private static Grid<int> BuildLargeGrid(Grid<int> smallGrid)
    {
        const int multiplier = 5;
        var largeGrid = new Grid<int>(smallGrid.Width * multiplier, smallGrid.Height * multiplier);
        var width = smallGrid.Width;
        var height = smallGrid.Height;
        for (var yy = 0; yy < multiplier; yy++)
        {
            for (var xx = 0; xx < multiplier; xx++)
            {
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var vSmall = smallGrid.ReadValueAt(x, y);
                        var vLarge = xx + yy + vSmall;
                        while (vLarge > 9)
                            vLarge -= 9;
                        var xLarge = xx * width + x;
                        var yLarge = yy * height + y;
                        largeGrid.WriteValueAt(xLarge, yLarge, vLarge);
                    }
                }
            }
        }

        return largeGrid;
    }

    private static int FindRiskLevel(Grid<int> grid, Dictionary<Coord, IList<Coord>> cache)
    {
        var from = new Coord();
        var to = new Coord(grid.Width - 1, grid.Height - 1);
        return GetBestPathTo(grid, cache, from, to).Sum(grid.ReadValueAt);
    }

    private static Grid<int> GetCoordCounts(Grid<int> grid, IDictionary<Coord, IList<Coord>> cache, Coord from, Coord to)
    {
        var queue = new Queue<Coord>();
        queue.Enqueue(to);
        var seenGrid = new Grid<int>(grid.Width, grid.Height, int.MaxValue);
        seenGrid.WriteValueAt(to, grid.ReadValueAt(to));
        while (queue.Any() && seenGrid.ReadValueAt(from) == int.MaxValue)
        {
            var next = queue.Dequeue();
            var currentScore = seenGrid.ReadValueAt(next.X, next.Y);
            var adjacentCoords = GetAdjacentCoords(grid, cache, new Coord(next.X, next.Y))
                .OrderBy(grid.ReadValueAt);

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newScore = currentScore + grid.ReadValueAt(adjacentCoord);
                var existing = seenGrid.ReadValueAt(adjacentCoord);
                if (newScore >= existing)
                    continue;

                queue.Enqueue(adjacentCoord);
                seenGrid.WriteValueAt(adjacentCoord, newScore);
            }
        }

        return seenGrid;
    }

    private static IList<Coord> GetBestPathTo(Grid<int> grid, IDictionary<Coord, IList<Coord>> cache, Coord from, Coord to)
    {
        var pathGrid = GetCoordCounts(grid, cache, from, to);

        var path = new List<Coord>();
        var pathSet = new HashSet<Coord>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            var adjacentCoords = GetAdjacentCoords(pathGrid, cache, currentAddress)
                .Where(o => pathGrid.ReadValueAt(o) > -1 && !pathSet.Contains(o))
                .OrderBy(pathGrid.ReadValueAt)
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            
            if (adjacentCoords.Count == 0)
                continue;
            
            var bestAddress = adjacentCoords.First();
            currentAddress = new Coord(bestAddress.X, bestAddress.Y);
            path.Add(currentAddress);
            pathSet.Add(currentAddress);
        }

        return path;
    }

    private static IList<Coord> GetAdjacentCoords<T>(Grid<T> grid, IDictionary<Coord, IList<Coord>> cache, Coord address) where T : struct
    {
        if (cache.TryGetValue(address, out var coords))
            return coords;

        grid.MoveTo(address);
        coords = grid.OrthogonalAdjacentCoords;
        cache.Add(address, coords);
        return coords;
    }
}