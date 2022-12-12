using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2022.Day12;

public class HillClimbing
{
    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var from = FindFromCoord(matrix);
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var steps = StepCountTo(matrix, from, to);

        return steps;
    }

    public int Part2(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var from = FindFromCoord(matrix); 
        var to = FindToCoord(matrix);
        matrix.WriteValueAt(from, 'a');
        matrix.WriteValueAt(to, 'z');
        var startingPoints = matrix.Coords.Where(coord => matrix.ReadValueAt(coord) == 'a').ToList();
        var stepCount = StepCountTo(matrix, startingPoints, to);
        return stepCount;
    }

    private MatrixAddress FindFromCoord(IMatrix<char> matrix) => matrix.Coords.First(o => matrix.ReadValueAt(o) == 'S');
    private MatrixAddress FindToCoord(IMatrix<char> matrix) => matrix.Coords.First(o => matrix.ReadValueAt(o) == 'E');

    private static int StepCountTo(IMatrix<char> matrix, MatrixAddress from, MatrixAddress to) =>
        StepCountTo(matrix, new List<MatrixAddress> { from }, to);

    private static int StepCountTo(IMatrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == to.X && o.Y == to.Y);
        return goal?.Count ?? 0;
    }
    
    private static IList<CoordCount> GetCoordCounts(IMatrix<char> matrix, IList<MatrixAddress> from, MatrixAddress to)
    {
        var seen = from.ToDictionary(k => k, v => 0);
        var queue = from.ToList();
        var index = 0;
        while (index < queue.Count && !seen.ContainsKey(to))
        {
            var next = queue[index];
            var count = seen[next];
            var currentValue = matrix.ReadValueAt(next);
            var adjacentCoords = matrix.PerpendicularAdjacentCoordsTo(next)
                .Where(o => matrix.ReadValueAt(o) - currentValue <= 1 && !seen.ContainsKey(o))
                .ToList();
            queue.AddRange(adjacentCoords);
            foreach (var adjacentCoord in adjacentCoords) 
                seen[adjacentCoord] = count + 1;
            index++;
        }

        return queue.Select(o => new CoordCount(o, seen[o])).ToList();
    }
}