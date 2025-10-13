using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202115;

public class ChitonRisk
{
    private readonly IDictionary<Coord, IList<Coord>> _neighborCache = new Dictionary<Coord, IList<Coord>>();

    public int FindRiskLevelForSmallCave(string input)
    {
        var grid = GridBuilder.BuildIntGridFromNonSeparated(input);
        return FindRiskLevel(grid);
    }

    public int FindRiskLevelForLargeCave(string input)
    {
        var smallGrid = GridBuilder.BuildIntGridFromNonSeparated(input);
        var largeGrid = BuildLargeGrid(smallGrid);
        return FindRiskLevel(largeGrid);
    }

    private Grid<int> BuildLargeGrid(Grid<int> smallGrid)
    {
        const int multiplier = 5;
        var largeGrid = new Grid<int>(smallGrid.Width * multiplier, smallGrid.Height * multiplier);
        var width = smallGrid.Width;
        var height = smallGrid.Height;
        for (var Y = 0; Y < multiplier; Y++) 
        {
            for (var X = 0; X < multiplier; X++)
            {
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var vSmall = smallGrid.ReadValueAt(x, y);
                        var vLarge = X + Y + vSmall;
                        while (vLarge > 9)
                            vLarge -= 9;
                        var xLarge = X * width + x;
                        var yLarge = Y * height + y;
                        largeGrid.WriteValueAt(xLarge, yLarge, vLarge);
                    }
                }
            }
        }

        return largeGrid;
    }

    private int FindRiskLevel(Grid<int> grid)
    {
        var from = new Coord(0, 0);
        var to = new Coord(grid.Width - 1, grid.Height - 1);
        var path = GetBestPathTo(grid, from, to);

        var sum = 0;
        foreach (var coord in path)
        {
            sum += grid.ReadValueAt(coord);
        }

        //PrintPath(grid, path);

        return sum;
    }

    private void PrintPath(Grid<int> grid, IList<Coord> path)
    {
        var pathGrid = new Grid<char>(grid.Width, grid.Height, defaultValue: '.');
        foreach (var coord in path)
        {
            pathGrid.WriteValueAt(coord, '#');
        }

        Console.WriteLine(pathGrid.Print());
    }

    private Grid<int> GetCoordCounts(Grid<int> grid, Coord from, Coord to)
    {
        var queue = new Queue<Coord>();
        queue.Enqueue(to);
        var seenGrid = new Grid<int>(grid.Width, grid.Height, int.MaxValue);
        seenGrid.WriteValueAt(to, grid.ReadValueAt(to));
        while (queue.Any() && seenGrid.ReadValueAt(from) == int.MaxValue)
        {
            var next = queue.Dequeue();
            var currentScore = seenGrid.ReadValueAt(next.X, next.Y);
            var adjacentCoords = GetAdjacentCoords(grid, new Coord(next.X, next.Y))
                .OrderBy(grid.ReadValueAt);

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newScore = currentScore + grid.ReadValueAt(adjacentCoord);
                var existing = seenGrid.ReadValueAt(adjacentCoord);
                if (newScore < existing)
                {
                    queue.Enqueue(adjacentCoord);
                    seenGrid.WriteValueAt(adjacentCoord, newScore);
                }
            }
        }

        return seenGrid;
    }

    private IList<Coord> GetBestPathTo(Grid<int> grid, Coord from, Coord to)
    {
        var pathGrid = GetCoordCounts(grid, from, to);
        
        var path = new List<Coord>();
        var pathSet = new HashSet<Coord>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            var adjacentCoords = GetAdjacentCoords(pathGrid, currentAddress)
                .Where(o => pathGrid.ReadValueAt(o) > -1 && !pathSet.Contains(o))
                .OrderBy(o => pathGrid.ReadValueAt(o))
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            if (adjacentCoords.Any())
            {
                var bestAddress = adjacentCoords.First();
                currentAddress = new Coord(bestAddress.X, bestAddress.Y);
                path.Add(currentAddress);
                pathSet.Add(currentAddress);
            }
        }

        return path;
    }

    private IList<Coord> GetAdjacentCoords<T>(Grid<T> grid, Coord address) where T : struct
    {
        if (_neighborCache.TryGetValue(address, out var coords))
            return coords;

        grid.MoveTo(address);
        coords = grid.OrthogonalAdjacentCoords;
        _neighborCache.Add(address, coords);
        return coords;
    }
}