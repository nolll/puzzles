using System.Linq;

namespace Core.Common.CoordinateSystems
{
    public static class MatrixBuilder
    {
        public static Matrix<char> BuildCharMatrix(string input, char defaultValue = default)
        {
            var matrix = new Matrix<char>(1, 1, defaultValue);
            var rows = input.Trim().Split('\n');
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

        public static Matrix<int> BuildIntMatrix(string input, int defaultValue = default)
        {
            var matrix = new Matrix<int>(1, 1, defaultValue);
            var rows = input.Trim().Split('\n');
            var y = 0;
            foreach (var row in rows)
            {
                var x = 0;
                var numbers = row.Trim().Split(' ').Where(o => o.Length > 0).Select(int.Parse);
                foreach (var n in numbers)
                {
                    matrix.MoveTo(x, y);
                    matrix.WriteValue(n);
                    x += 1;
                }

                y += 1;
            }

            return matrix;
        }
    }
}