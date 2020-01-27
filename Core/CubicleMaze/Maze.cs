using System;
using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.CubicleMaze
{
    public class Maze
    {
        private readonly Matrix<char> _matrix;

        public Maze(in int width, in int height, in int secretNumber)
        {
            _matrix = BuildMatrix(width, height, secretNumber);
        }

        public int StepCountToTarget(int targetX, int targetY) => StepCountTo(new MatrixAddress(1, 1), new MatrixAddress(targetX, targetY));
        public int LocationCountAfter(int steps) => LocationCountAfter(new MatrixAddress(1, 1), steps);
        public string Print() => _matrix.Print();

        private int StepCountTo(MatrixAddress from, MatrixAddress to)
        {
            var queue = new List<CoordCount> { new CoordCount(to.X, to.Y, 0) };
            while (!queue.Any(o => o.X == from.X && o.Y == from.Y))
            {
                var next = queue.First();
                queue.RemoveAt(0);
                _matrix.MoveTo(next.X, next.Y);
                var adjacentCoords = _matrix.Adjacent4Coords
                    .Where(o => _matrix.ReadValueAt(o) == '.' &&
                                !queue.Any(q => q.X == o.X && q.Y == o.Y))
                    .ToList();
                var newCoordCounts = adjacentCoords.Select(o => new CoordCount(o.X, o.Y, next.Count + 1));
                queue.AddRange(newCoordCounts);
            }

            var goal = queue.FirstOrDefault(o => o.X == from.X && o.Y == from.Y);
            return goal?.Count ?? 0;
        }

        private int LocationCountAfter(MatrixAddress from, int steps)
        {
            var queue = new List<MatrixAddress> { from };
            var i = 0;
            while (i <= steps)
            {
                var newQueue = new List<MatrixAddress>();
                foreach (var coord in queue)
                {
                    _matrix.MoveTo(coord);
                    _matrix.WriteValue('O');
                    var adjacentCoords = _matrix.Adjacent4Coords.Where(o => _matrix.ReadValueAt(o) == '.').ToList();
                    newQueue.AddRange(adjacentCoords);
                }

                queue = newQueue;
                i++;
            }

            return _matrix.Values.Count(o => o == 'O');
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