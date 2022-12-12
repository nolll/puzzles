using System.Collections.Generic;
using System.Linq;
using Core.Common.CoordinateSystems.CoordinateSystem2D;

namespace Core.Puzzles.Year2022.Day12;

public class HillClimbing
{
    public int Part1(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var (from, to) = FindFromAndTo(matrix);
        var steps = StepCountTo(matrix, from, to);

        return steps;
    }

    public int Part2(string input)
    {
        var matrix = MatrixBuilder.BuildStaticCharMatrix(input);
        var (_, to) = FindFromAndTo(matrix);
        var startingPoints = FindStartingPoints(matrix);
        var stepCounts = startingPoints.Select(from => StepCountTo(matrix, from, to)).ToList();
        return stepCounts.Where(o => o > 0).Min();
    }

    private List<MatrixAddress> FindStartingPoints(IMatrix<char> matrix)
    {
        var startingPositions = new List<MatrixAddress>();
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == 'a')
            {
                startingPositions.Add(coord);
            }
        }

        return startingPositions;
    }

    private (MatrixAddress from, MatrixAddress to) FindFromAndTo(IMatrix<char> matrix)
    {
        var from = new MatrixAddress(0, 0);
        var to = new MatrixAddress(0, 0);
        foreach (var coord in matrix.Coords)
        {
            if (matrix.ReadValueAt(coord) == 'S')
            {
                matrix.WriteValueAt(coord, 'a');
                from = coord;
            }
            if (matrix.ReadValueAt(coord) == 'E')
            {
                matrix.WriteValueAt(coord, 'z');
                to = coord;
            }
        }

        return (from, to);
    }

    public static int StepCountTo(IMatrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var goal = coordCounts.FirstOrDefault(o => o.X == from.X && o.Y == from.Y);
        return goal?.Count ?? 0;
    }

    private static IList<CoordCount> GetCoordCounts(IMatrix<char> matrix, MatrixAddress from, MatrixAddress to)
    {
        var queue = new List<CoordCount> { new(to.X, to.Y, 0) };
        var index = 0;
        while (index < queue.Count && !queue.Any(o => o.X == from.X && o.Y == from.Y))
        {
            var next = queue[index];
            matrix.MoveTo(next.X, next.Y);
            var currentValue = matrix.ReadValue();
            var adjacentCoords = matrix.PerpendicularAdjacentCoords
                .Where(o => currentValue - matrix.ReadValueAt(o) <= 1 && !queue.Any(q => q.X == o.X && q.Y == o.Y))
                .ToList();
            var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o.X, o.Y, next.Count + 1));
            queue.AddRange(newCoordCounts);
            index++;
        }

        return queue;
    }
}