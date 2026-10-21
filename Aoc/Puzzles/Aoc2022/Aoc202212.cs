using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;

namespace Pzl.Aoc.Puzzles.Aoc2022;

[Name("Hill Climbing Algorithm")]
public class Aoc202212 : AocPuzzle
{
    private const char StartChar = 'a';
    private const char EndChar = 'z';

    [Puzzle("48b865d6e753e7b8f1cd6f83d797bd43")]
    public int Part1(string input)
    {
        var (grid, from, to) = Parse(input);
        return StepCountTo(grid, from, to);
    }

    [Puzzle("222a9519ff249ce48bdd88917bbcc312")]
    public int Part2(string input)
    {
        var (grid, _, to) = Parse(input);
        var startingPoints = grid.Coords.Where(coord => grid.ReadValueAt(coord) == StartChar).ToList();
        return StepCountTo(grid, startingPoints, to);
    }
    
    private static Coord FindCoord(Grid<char> grid, char c) => grid.Coords.First(o => grid.ReadValueAt(o) == c);

    private static int StepCountTo(Grid<char> grid, Coord from, Coord to) =>
        StepCountTo(grid, new List<Coord> { from }, to);

    private static int StepCountTo(Grid<char> grid, IList<Coord> from, Coord to) => 
        GetCoordCounts(grid, from, to).FirstOrDefault(o => o.Coord.X == to.X && o.Coord.Y == to.Y)?.Count ?? 0;

    private static IList<CoordCount> GetCoordCounts(Grid<char> grid, IList<Coord> from, Coord to)
    {
        var seen = from.ToDictionary(k => k, _ => 0);
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
    
    private static (Grid<char>, Coord, Coord) Parse(string input)
    {
        var grid = GridBuilder.BuildCharGrid(input);
        var from = FindCoord(grid, 'S');
        var to = FindCoord(grid, 'E');
        grid.WriteValueAt(from, StartChar);
        grid.WriteValueAt(to, EndChar);
        return (grid, from, to);
    }
}