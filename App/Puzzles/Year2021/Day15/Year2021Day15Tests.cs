using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day15
{
    public class Year2021Day15Tests
    {
        [Test]
        public void Part1()
        {
            var chitonRisk = new ChitonRisk(Input);
            var result = chitonRisk.FindRiskLevel();

            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void Part2()
        {
            var result = 0;

            Assert.That(result, Is.EqualTo(0));
        }

        private const string Input = @"
1163751742
1381373672
2136511328
3694931569
7463417111
1319128137
1359912421
3125421639
1293138521
2311944581";
    }

    public class ChitonRisk
    {
        private Matrix<int> _matrix;

        public ChitonRisk(string input)
        {
            _matrix = MatrixBuilder.BuildIntMatrixFromNonSeparated(input);
        }

        public int FindRiskLevel()
        {
            var from = new MatrixAddress(0, 0);
            var to = new MatrixAddress(_matrix.Width - 1, _matrix.Height - 1);
            var path = GetBestPathTo(_matrix, from, to);

            var sum = 0;
            foreach (var coord in path)
            {
                sum += _matrix.ReadValueAt(coord);
            }

            return sum;
        }

        private static IList<CoordCount> GetCoordCounts(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
        {
            var queue = new Queue<CoordCount>();
            queue.Enqueue(new CoordCount(0, 0, matrix.ReadValueAt(to)));
            var seen = new Dictionary<MatrixAddress, CoordCount>();
            while (queue.Any())
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
                    else if(existing == null)
                    {
                        var coordCount = new CoordCount(adjacentCoord.X, adjacentCoord.Y, newScore);
                        queue.Enqueue(coordCount);
                        seen[adjacentCoord] = coordCount;
                    }
                }
            }

            return seen.Values.ToList();
        }

        public static IList<MatrixAddress> GetBestPathTo(Matrix<int> matrix, MatrixAddress from, MatrixAddress to)
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
                    .Where(o => pathMatrix.ReadValueAt(o) > -1)
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
}