using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.CoordinateSystems;

namespace App.Puzzles.Year2020.Day20
{
    public class JigsawTile
    {
        public long Id { get; }
        public Matrix<char> Matrix;
        public bool Done { get; set; }

        public JigsawTile(long id, Matrix<char> matrix)
        {
            Done = false;
            Id = id;
            Matrix = matrix;
        }

        public bool HasMatchingEdge(JigsawTile otherTile)
        {
            foreach (var edge in Edges.Values)
            {
                if (otherTile.Edges.Values.Any(HasMatchingEdge))
                    return true;
            }

            return false;
        }

        public bool HasMatchingEdge(string edge)
        {
            var reverseEdge = edge.Reverse();
            if (Edges.Any(o => o.Value == edge || o.Value == reverseEdge))
                return true;

            return false;
        }

        public void RotateRight()
        {
            Matrix = Matrix.RotateRight();
        }

        public void FlipVertical()
        {
            Matrix = Matrix.FlipVertical();
        }

        public void FlipHorizontal()
        {
            Matrix = Matrix.FlipHorizontal();
        }

        public Dictionary<string, string> Edges
        {
            get
            {
                var top = new StringBuilder();
                var right = new StringBuilder();
                var bottom = new StringBuilder();
                var left = new StringBuilder();

                var width = Matrix.Width;
                var height = Matrix.Height;

                const int yTop = 0;
                var yBottom = height - 1;
                for (var x = 0; x < width; x++)
                {
                    top.Append(Matrix.ReadValueAt(x, yTop));
                    bottom.Append(Matrix.ReadValueAt(x, yBottom));
                }

                var xRight = width - 1;
                const int xLeft = 0;
                for (var y = 0; y < height; y++)
                {
                    right.Append(Matrix.ReadValueAt(xRight, y));
                    left.Append(Matrix.ReadValueAt(xLeft, y));
                }

                return new Dictionary<string, string>
                {
                    {"top", top.ToString()},
                    {"right", right.ToString()},
                    {"bottom", bottom.ToString()},
                    {"left", left.ToString()}
                };
            }
        }

        public string Print()
        {
            return Matrix.Print();
        }

        public static JigsawTile Parse(string s)
        {
            var parts = s.Split(':');
            var id = long.Parse(parts[0].Split(' ')[1]);
            var matrix = MatrixBuilder.BuildCharMatrix(parts[1].Trim());
            return new JigsawTile(id, matrix);
        }

        public void RemoveBorder()
        {
            var width = Matrix.Width;
            var height = Matrix.Height;
            var newMatrix = new Matrix<char>();
            for (var y = 1; y < height - 1; y++)
            {
                for (var x = 1; x < width - 1; x++)
                {
                    var newX = x - 1;
                    var newY = y - 1;
                    newMatrix.MoveTo(newX, newY);
                    newMatrix.WriteValue(Matrix.ReadValueAt(x, y));
                }
            }

            Matrix = newMatrix;
        }
    }
}