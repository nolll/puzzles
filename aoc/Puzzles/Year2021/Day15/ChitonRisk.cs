using System;
using System.Collections.Generic;
using System.Linq;
using common.CoordinateSystems.CoordinateSystem2D;

namespace Aoc.Puzzles.Year2021.Day15;

public class ChitonRisk
{
    private readonly IDictionary<MatrixAddress, IList<MatrixAddress>> _neighborCache = new Dictionary<MatrixAddress, IList<MatrixAddress>>();

    public int FindRiskLevelForSmallCave(string input)
    {
        var matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        return FindRiskLevel(matrix);
    }

    public int FindRiskLevelForLargeCave(string input)
    {
        var smallMatrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        var largeMatrix = BuildLargeMatrix(smallMatrix);
        return FindRiskLevel(largeMatrix);
    }

    private Matrix<int> BuildLargeMatrix(Matrix<int> smallMatrix)
    {
        const int multiplier = 5;
        var largeMatrix = new Matrix<int>(smallMatrix.Width * multiplier, smallMatrix.Height * multiplier);
        var width = smallMatrix.Width;
        var height = smallMatrix.Height;
        for (var Y = 0; Y < multiplier; Y++) 
        {
            for (var X = 0; X < multiplier; X++)
            {
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var vSmall = smallMatrix.ReadValueAt(x, y);
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

    private int FindRiskLevel(Matrix<int> matrix)
    {
        var from = new MatrixAddress(0, 0);
        var to = new MatrixAddress(matrix.Width - 1, matrix.Height - 1);
        var path = GetBestPathTo(matrix, from, to);

        var sum = 0;
        foreach (var coord in path)
        {
            sum += matrix.ReadValueAt(coord);
        }

        //PrintPath(matrix, path);

        return sum;
    }

    private void PrintPath(Matrix<int> matrix, IList<MatrixAddress> path)
    {
        var pathMatrix = new Matrix<char>(matrix.Width, matrix.Height, defaultValue: '.');
        foreach (var coord in path)
        {
            pathMatrix.WriteValueAt(coord, '#');
        }

        Console.WriteLine(pathMatrix.Print());
    }

    private Matrix<int> GetCoordCounts(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
    {
        var queue = new Queue<MatrixAddress>();
        queue.Enqueue(to);
        var seenMatrix = new Matrix<int>(matrix.Width, matrix.Height, int.MaxValue);
        seenMatrix.WriteValueAt(to, matrix.ReadValueAt(to));
        while (queue.Any() && seenMatrix.ReadValueAt(from) == int.MaxValue)
        {
            var next = queue.Dequeue();
            var currentScore = seenMatrix.ReadValueAt(next.X, next.Y);
            var adjacentCoords = GetAdjacentCoords(matrix, new MatrixAddress(next.X, next.Y))
                .OrderBy(matrix.ReadValueAt);

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newScore = currentScore + matrix.ReadValueAt(adjacentCoord);
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

    private IList<MatrixAddress> GetBestPathTo(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
    {
        var pathMatrix = GetCoordCounts(matrix, from, to);
        
        var path = new List<MatrixAddress>();
        var pathSet = new HashSet<MatrixAddress>();
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
                currentAddress = new MatrixAddress(bestAddress.X, bestAddress.Y);
                path.Add(currentAddress);
                pathSet.Add(currentAddress);
            }
        }

        return path;
    }

    private IList<MatrixAddress> GetAdjacentCoords<T>(Matrix<T> matrix, MatrixAddress address)
    {
        if (_neighborCache.TryGetValue(address, out var coords))
            return coords;

        matrix.MoveTo(address);
        coords = matrix.PerpendicularAdjacentCoords;
        _neighborCache.Add(address, coords);
        return coords;
    }
}