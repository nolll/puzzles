using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202109;

public class HeightMap
{
    public int FindLowPointSum(string input)
    {
        var sum = 0;
        var grid = CreateGrid(input);

        var coords = grid.Coords;
        foreach (var coord in coords)
        {
            var v = grid.ReadValueAt(coord);
            var adjacentValues = grid.OrthogonalAdjacentValuesTo(coord);
            var isLowPoint = !adjacentValues.Any(o => o <= v);

            if (isLowPoint)
                sum += v + 1;
        }

        return sum;
    }

    public int FindBasinSizes(string input)
    {
        var grid = CreateGrid(input);

        var checkedCoords = new HashSet<Coord>();
        var allCoords = grid.Coords;
        var basinSizes = new List<int>();

        foreach (var currentCoord in allCoords)
        {
            if (checkedCoords.Contains(currentCoord))
                continue;

            grid.MoveTo(currentCoord);
            if (grid.ReadValue() == 9)
            {
                checkedCoords.Add(currentCoord);
                continue;
            }

            var coordsToCheck = new HashSet<Coord> {currentCoord};
            var basinSize = 0;
            while (coordsToCheck.Any())
            {
                var c = coordsToCheck.First();
                coordsToCheck.Remove(c);
                checkedCoords.Add(c);
                    
                if (grid.ReadValueAt(c) < 9)
                {
                    basinSize++;
                    var adjacentCoords = grid.OrthogonalAdjacentCoordsTo(c);
                    foreach (var a in adjacentCoords)
                    {
                        if (!checkedCoords.Contains(a) && !coordsToCheck.Contains(a))
                            coordsToCheck.Add(a);
                    }
                }

                if (!coordsToCheck.Any())
                {
                    basinSizes.Add(basinSize);
                    basinSize = 1;
                }
            }
        }

        return basinSizes
            .OrderByDescending(o => o)
            .Take(3)
            .Aggregate(1, (product, basin) => product * basin);
    }

    private static Grid<int> CreateGrid(string input)
    {
        var grid = new Grid<int>();
        var lines = StringReader.ReadLines(input);

        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var c in line)
            {
                var n = int.Parse(c.ToString());
                grid.MoveTo(x, y);
                grid.WriteValue(n);
                x++;
            }

            y++;
        }

        return grid;
    }
}