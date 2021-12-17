using System;
using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2021.Day15;

public class ChitonRisk
{
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
        var largeMatrix = new Matrix<int>();
        const int multiplier = 5;
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
                        largeMatrix.MoveTo(xLarge, yLarge);
                        largeMatrix.WriteValue(vLarge);
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
        var pathMatrix = new Matrix<char>(defaultValue: '.');
        foreach (var coord in path)
        {
            pathMatrix.MoveTo(coord);
            pathMatrix.WriteValue('#');
        }

        Console.WriteLine(pathMatrix.Print());
    }

    private static IList<CoordCount> GetCoordCounts(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
    {
        var queue = new Queue<CoordCount>();
        var startCoordCount = new CoordCount(to.X, to.Y, matrix.ReadValueAt(to));
        queue.Enqueue(startCoordCount);
        var seen = new Dictionary<MatrixAddress, CoordCount>
        {
            [to] = startCoordCount
        };
        while (queue.Any() && !seen.ContainsKey(from))
        {
            var next = queue.Dequeue();
            matrix.MoveTo(next.X, next.Y);
            var adjacentCoords = matrix.PerpendicularAdjacentCoords
                .OrderBy(matrix.ReadValueAt)
                .ToList();

            foreach (var adjacentCoord in adjacentCoords)
            {
                var newScore = next.Count + matrix.ReadValueAt(adjacentCoord);
                if (seen.TryGetValue(adjacentCoord, out var existing) && newScore < existing.Count)
                {
                    var coordCount = new CoordCount(adjacentCoord.X, adjacentCoord.Y, newScore);
                    queue.Enqueue(coordCount);
                    seen[adjacentCoord] = coordCount;
                }
                else if (existing == null)
                {
                    var coordCount = new CoordCount(adjacentCoord.X, adjacentCoord.Y, newScore);
                    queue.Enqueue(coordCount);
                    seen[adjacentCoord] = coordCount;
                }
            }
        }

        return seen.Values.ToList();
    }

    private static IList<MatrixAddress> GetBestPathTo(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
    {
        var coordCounts = GetCoordCounts(matrix, from, to);
        var pathMatrix = new Matrix<int>(matrix.Width, matrix.Height, -1);
        foreach (var coordCount in coordCounts)
        {
            pathMatrix.MoveTo(coordCount.X, coordCount.Y);
            pathMatrix.WriteValue(coordCount.Count);
        }

        var path = new List<MatrixAddress>();
        var currentAddress = from;
        while (!currentAddress.Equals(to))
        {
            pathMatrix.MoveTo(currentAddress);
            var adjacentCoords = pathMatrix.PerpendicularAdjacentCoords
                .Where(o => pathMatrix.ReadValueAt(o) > -1 && !path.Contains(o))
                .OrderBy(o => pathMatrix.ReadValueAt(o))
                .ThenBy(o => o.Y)
                .ThenBy(o => o.X)
                .ToList();
            var bestAddress = adjacentCoords.FirstOrDefault();
            if (bestAddress == null)
                break;
            currentAddress = new MatrixAddress(bestAddress.X, bestAddress.Y);
            path.Add(currentAddress);
        }

        return path;
    }
}