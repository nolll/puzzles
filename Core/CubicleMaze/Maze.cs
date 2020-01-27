using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CubicleMaze
{
    public class Maze
    {
        public int RouteLength { get; }

        public Maze(in int width, in int height, in int secretNumber, int targetX, int targetY)
        {
            var matrix = BuildMatrix(width, height, secretNumber);
            var from = new MatrixAddress(1, 1);
            var to = new MatrixAddress(targetX, targetY);
            var steps = StepCountTo(matrix, from, to);

            RouteLength = steps;
        }

        private int StepCountTo(Matrix<char> matrix, MatrixAddress from, MatrixAddress to)
        {
            var queue = new List<CoordCount> {new CoordCount(to.X, to.Y, 0)};
            while (!queue.Any(o => o.X == from.X && o.Y == from.Y))
            {
                var next = queue.First();
                queue.RemoveAt(0);
                matrix.MoveTo(next.X, next.Y);
                var adjacentCoords = matrix.Adjacent4Coords
                    .Where(o => matrix.ReadValueAt(o) == '.' && !queue.Any(q => q.X == o.X && q.Y == o.Y))
                    .ToList();
                var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o.X, o.Y, next.Count + 1));
                queue.AddRange(newCoordCounts);
            }

            var goal = queue.FirstOrDefault(o => o.X == from.X && o.Y == from.Y);
            return goal?.Count ?? 0;
        }

        private class CoordCount
        {
            public int X { get; }
            public int Y { get; }
            public int Count { get; }

            public CoordCount(int x, int y, int count)
            {
                X = x;
                Y = y;
                Count = count;
            }
        }

        private Matrix<char> BuildMatrix(in int width, in int height, in int secretNumber)
        {
            var matrix = new Matrix<char>();
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    matrix.MoveTo(x, y);
                    var value = x * x + 3 * x + 2 * x * y + y + y * y + secretNumber;
                    var binary = Convert.ToString(value, 2);
                    var binaryString = binary.ToString();
                    var numberOfSetBits = binaryString.Count(o => o == '1');
                    var isOpenSpace = numberOfSetBits % 2 == 0;
                    var c = isOpenSpace ? '.' : '#';
                    matrix.WriteValue(c);
                }
            }

            return matrix;
        }
    }
}