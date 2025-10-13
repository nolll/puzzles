using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022.Aoc202212;

public class HillClimbing
{
    public int Part1(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var from = FindFromCoord(matrix);
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var steps = StepCountTo(matrix, from, to);

        return steps;
    }

    public int Part2(string input)
    {
        var matrix = GridBuilder.BuildCharGrid(input);
        var from = FindFromCoord(matrix); 
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var startingPoints = matrix.Coords.Where(coord => matrix.ReadValueAt(coord) == 'a').ToList();
        var stepCount = StepCountTo(matrix, startingPoints, to);
        return stepCount;
    }

    private static Coord FindFromCoord(Grid<char> grid) => grid.Coords.First(o => grid.ReadValueAt(o) == 'S');
    private static Coord FindToCoord(Grid<char> grid) => grid.Coords.First(o => grid.ReadValueAt(o) == 'E');

    private static int StepCountTo(Grid<char> grid, Coord from, Coord to) =>
        StepCountTo(grid, new List<Coord> { from }, to);

    private static int StepCountTo(Grid<char> grid, IList<Coord> from, Coord to)
    {
        var coordCounts = GetCoordCounts(grid, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }
    
    private static IList<CoordCount> GetCoordCounts(Grid<char> grid, IList<Coord> from, Coord to)
    {
        var seen = from.ToDictionary(k => k, v => 0);
        var queue = new Queue<Coord>(from);
        while (queue.Count > 0 && !seen.ContainsKey(to))
        {
            var next = queue.Dequeue();
            var count = seen[next];
            var adjacentCoords = grid.OrthogonalAdjacentCoordsTo(next)
                .Where(o => !seen.ContainsKey(o) && grid.ReadValueAt(o) - grid.ReadValueAt(next) <= 1);
            foreach (var adjacentCoord in adjacentCoords)
            {
                queue.Enqueue(adjacentCoord);
                seen[adjacentCoord] = count + 1;
            }
        }

        return seen.Select(o => new CoordCount(o.Key, o.Value)).ToList();
    }
}