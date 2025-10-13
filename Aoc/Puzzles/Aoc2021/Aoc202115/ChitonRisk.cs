using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202115;

public class ChitonRisk
{
    private readonly IDictionary<Coord, IList<Coord>> _neighborCache = new Dictionary<Coord, IList<Coord>>();

    public int FindRiskLevelForSmallCave(string input)
    {
        var matrix = GridBuilder.BuildIntGridFromNonSeparated(input);
        return FindRiskLevel(matrix);
    }

    public int FindRiskLevelForLargeCave(string input)
    {
        var smallMatrix = GridBuilder.BuildIntGridFromNonSeparated(input);
        var largeMatrix = BuildLargeMatrix(smallMatrix);
        return FindRiskLevel(largeMatrix);
    }

    private Grid<int> BuildLargeMatrix(Grid<int> smallGrid)
    {
        const int multiplier = 5;
        var largeMatrix = new Grid<int>(smallGrid.Width * multiplier, smallGrid.Height * multiplier);
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
                        largeMatrix.WriteValueAt(xLarge, yLarge, vLarge);
                    }
                }
            }
        }

        return largeMatrix;
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

        //PrintPath(matrix, path);

        return sum;
    }

    private void PrintPath(Grid<int> grid, IList<Coord> path)
    {
        var pathMatrix = new Grid<char>(grid.Width, grid.Height, defaultValue: '.');
        foreach (var coord in path)
        {
            pathMatrix.WriteValueAt(coord, '#');
        }

        Console.WriteLine(pathMatrix.Print());
    }

    private Grid<int> GetCoordCounts(Grid<int> grid, Coord from, Coord to)
    {
        var queue = new Queue<Coord>();
        queue.Enqueue(to);
        var seenMatrix = new Grid<int>(grid.Width, grid.Height, int.MaxValue);
        seenMatrix.WriteValueAt(to, grid.ReadValueAt(to));
        while (queue.Any() && seenMatrix.ReadValueAt(from) == int.MaxValue)
        {
            var next = queue.Dequeue();
            var currentScore = seenMatrix.ReadValueAt(next.X, next.Y);
            var adjacentCoords = GetAdjacentCoords(grid, new Coord(next.X, next.Y))
                .OrderBy(grid.ReadValueAt);

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newScore = currentScore + grid.ReadValueAt(adjacentCoord);
                var existing = seenMatrix.ReadValueAt(adjacentCoord);
                if (newScore < existing)
                {
                    queue.Enqueue(adjacentCoord);
                    seenMatrix.WriteValueAt(adjacentCoord, newScore);
                }
            }
        }

        return seenMatrix;
    }

    private IList<Coord> GetBestPathTo(Grid<int> grid, Coord from, Coord to)
    {
        var pathMatrix = GetCoordCounts(grid, from, to);
        
        var path = new List<Coord>();
        var pathSet = new HashSet<Coord>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            var adjacentCoords = GetAdjacentCoords(pathMatrix, currentAddress)
                .Where(o => pathMatrix.ReadValueAt(o) > -1 && !pathSet.Contains(o))
                .OrderBy(o => pathMatrix.ReadValueAt(o))
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