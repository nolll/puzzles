using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.BugLife
{
    public class RecursiveBugLifeSimulator
    {
        private const int Size = 5;
        private IDictionary<int, Matrix<char>> _matrixes;

        public string String(int level) => string.Join("", _matrixes[level].Values);

        public RecursiveBugLifeSimulator(string input)
        {
            _matrixes = new Dictionary<int, Matrix<char>>();
            _matrixes[0] = BuildMatrix(input);
        }

        public void Run(int iterations)
        {
            for (var i = 0; i < iterations; i++)
            {
                NextIteration();
            }
        }

        private Matrix<char> GetMatrix(int level)
        {
            if (_matrixes.TryGetValue(level, out var matrix))
                return matrix;

            matrix = new Matrix<char>(Size, Size, '.');
            _matrixes.Add(level, matrix);
            return matrix;
        }

        private void NextIteration()
        {
            var newMatrixes = new Dictionary<int, Matrix<char>>();
            foreach (var level in _matrixes.Keys)
            {
                var matrix = GetMatrix(level);
                var newMatrix = new Matrix<char>();
                for (var y = 0; y < Size; y++)
                {
                    for (var x = 0; x < Size; x++)
                    {
                        matrix.MoveTo(x, y);
                        var currentValue = matrix.ReadValue();
                        var neighborCount = GetNeighborCount(level, x, y);
                        var newValue = GetNewValue(currentValue, neighborCount);
                        newMatrix.MoveTo(x, y);
                        newMatrix.WriteValue(newValue);
                    }
                }

                newMatrixes.Add(level, new Matrix<char>());
            }

            _matrixes = newMatrixes;
        }

        private int GetNeighborCount(int level, int x, int y)
        {
            var adjacentValues = GetAdjacentValues(level, x, y);
            return adjacentValues.Count(o => o == '#');
        }

        private IEnumerable<char> GetAdjacentValues(int level, int x, int y)
        {
            // Find all adjacentValues for all 25 positions
            yield break;
        }

        private char GetNewValue(char currentValue, int neighborCount)
        {
            if (currentValue == '#' && neighborCount != 1)
                return '.';

            if (currentValue == '.' && (neighborCount == 1 || neighborCount == 2))
                return '#';

            return currentValue;
        }

        public long BiodiversityRating
        {
            get
            {
                long totalScore = 0;
                var currentScore = 1;
                foreach (var c in _matrixes[0].Values)
                {
                    if(c == '#')
                        totalScore += currentScore;
                    currentScore *= 2;
                }

                return totalScore;
            }
        }

        private Matrix<char> BuildMatrix(string map)
        {
            var matrix = new Matrix<char>(1, 1);
            var rows = map.Trim().Split('\n');
            var y = 0;
            foreach (var row in rows)
            {
                var x = 0;
                var chars = row.Trim().ToCharArray();
                foreach (var c in chars)
                {
                    matrix.MoveTo(x, y);
                    matrix.WriteValue(c);
                    x += 1;
                }

                y += 1;
            }

            return matrix;
        }
    }
}