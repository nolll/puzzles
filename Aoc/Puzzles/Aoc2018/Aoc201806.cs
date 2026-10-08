using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2018;

[Name("Chronal Coordinates")]
public class Aoc201806 : AocPuzzle
{
    [Puzzle("38a2162984fb4f3ad26481fe9d035149")]
    public int Part1(string input) => GetSizeOfLargestArea(input);

    [Puzzle("1272f4319b022610a3eb7f805e2fba48")]
    public int Part2(string input) => GetSizeOfCentralArea(input, 10000);

    public int GetSizeOfLargestArea(string input)
    {
        var coords = GetCoords(input);
        var (grid, ids) = BuildGrid(coords);
        FillGrid(grid, coords);
        var edgeMarkers = FindEdgeMarkers(grid, ids);
        var nonEdgeMarkers = GetNonEdgeMasters(grid, edgeMarkers);
        var mostCommonMarker = nonEdgeMarkers.GroupBy(o => o).OrderByDescending(o => o.Count()).First().Key;
        return nonEdgeMarkers.Count(o => o == mostCommonMarker) + 1;
    }

    public int GetSizeOfCentralArea(string input, int distanceLimit)
    {
        var coords = GetCoords(input);
        var (grid, _) = BuildGrid(coords);
        FillGrid(grid, coords);
        var centralAreaCount = 0;
        foreach (var coord in grid.Coords)
        {
            var sumOfdistances = coords.Select(o => o.ManhattanDistanceTo(coord)).Sum();
            if (sumOfdistances < distanceLimit)
                centralAreaCount += 1;
        }

        return centralAreaCount;
    }

    private static IList<int> GetNonEdgeMasters(Grid<int> grid, IList<int> edgeMarkers) => 
        grid.Values.Where(o => o != 0 && !edgeMarkers.Contains(o)).ToList();

    private static IList<int> FindEdgeMarkers(Grid<int> grid, List<int> ids)
    {
        grid.MoveTo(grid.XMin, grid.YMin);
        grid.TurnTo(GridDirection.Right);
        var markers = new List<int>();
        var done = false;
        while (!done)
        {
            var val = grid.ReadValue();
            if (val != 0 && !markers.Contains(val) && !ids.Contains(val))
                markers.Add(val);

            if (!grid.TryMoveForward())
            {
                grid.TurnRight();
                grid.MoveForward();
            }

            if (grid.Coord.X == grid.XMin && grid.Coord.Y == grid.YMin)
                done = true;
        }

        return markers;
    }

    private static void FillGrid(Grid<int> grid, IList<Coord> coords)
    {
        foreach (var coord in grid.Coords)
        {
            grid.MoveTo(coord);
            if (grid.ReadValue() != -1)
                continue;

            var coordsOrderedByDistance = coords.OrderBy(o => grid.Coord.ManhattanDistanceTo(o)).ToList();
            var coord1 = coordsOrderedByDistance[0];
            var coord2 = coordsOrderedByDistance[1];
            var distance1 = grid.Coord.ManhattanDistanceTo(coord1);
            var distance2 = grid.Coord.ManhattanDistanceTo(coord2);
            var c = distance1 == distance2
                ? 0
                : grid.ReadValueAt(coord1) + 1000;
            grid.WriteValue(c);
        }
    }

    private static (Grid<int> grid, List<int> ids) BuildGrid(IList<Coord> coords)
    {
        var ids = new List<int>();
        var width = coords.Max(o => o.X) + 1;
        var height = coords.Max(o => o.Y) + 1;
        var grid = new Grid<int>(width, height, -1);

        var c = 1;
        foreach (var coord in coords)
        {
            grid.WriteValueAt(coord, c);
            ids.Add(c);
            c += 1;
        }

        return (grid, ids);
    }

    private static IList<Coord> GetCoords(string input) => input.Trim()
        .Split(LineBreaks.Single)
        .Select(str => new Coord([.. str.Trim().Split(',').Select(int.Parse)]))
        .ToList();
}