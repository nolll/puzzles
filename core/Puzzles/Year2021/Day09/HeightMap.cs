using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using App.Common.Strings;

namespace App.Puzzles.Year2021.Day09;

public class HeightMap
{
    public int FindLowPointSum(string input)
    {
        var sum = 0;
        var matrix = CreateMatrix(input);

        var coords = matrix.Coords;
        foreach (var coord in coords)
        {
            matrix.MoveTo(coord);
            var v = matrix.ReadValue();

            var adjacentValues = matrix.PerpendicularAdjacentValues;
            var isLowPoint = !adjacentValues.Any(o => o <= v);

            if (isLowPoint)
                sum += v + 1;
        }

        return sum;
    }

    public int FindBasinSizes(string input)
    {
        var matrix = CreateMatrix(input);

        var checkedCoords = new HashSet<MatrixAddress>();
        var allCoords = matrix.Coords;
        var basinSizes = new List<int>();

        foreach (var currentCoord in allCoords)
        {
            if (checkedCoords.Contains(currentCoord))
                continue;

            matrix.MoveTo(currentCoord);
            if (matrix.ReadValue() == 9)
            {
                checkedCoords.Add(currentCoord);
                continue;
            }

            var coordsToCheck = new HashSet<MatrixAddress> {currentCoord};
            var basinSize = 0;
            while (coordsToCheck.Any())
            {
                var c = coordsToCheck.First();
                coordsToCheck.Remove(c);
                matrix.MoveTo(c);
                checkedCoords.Add(c);
                    
                if (matrix.ReadValue() < 9)
                {
                    basinSize++;
                    var adjacentCoords = matrix.PerpendicularAdjacentCoords;
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

    private static Matrix<int> CreateMatrix(string input)
    {
        var matrix = new Matrix<int>();
        var lines = PuzzleInputReader.ReadLines(input);

        var y = 0;
        foreach (var line in lines)
        {
            var x = 0;
            foreach (var c in line)
            {
                var n = int.Parse(c.ToString());
                matrix.MoveTo(x, y);
                matrix.WriteValue(n);
                x++;
            }

            y++;
        }

        return matrix;
    }
}