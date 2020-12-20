using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.ImageJigsaw
{
    public class JigsawTile
    {
        public long Id { get; }
        private Matrix<char> _matrix;
        public bool Done { get; set; }

        public JigsawTile(long id, Matrix<char> matrix)
        {
            Done = false;
            Id = id;
            _matrix = matrix;
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
            _matrix = _matrix.RotateRight();
        }

        public void FlipVertical()
        {
            _matrix = _matrix.FlipVertical();
        }

        public void FlipHorizontal()
        {
            _matrix = _matrix.FlipHorizontal();
        }

        public Dictionary<string, string> Edges
        {
            get
            {
                var top = new StringBuilder();
                var right = new StringBuilder();
                var bottom = new StringBuilder();
                var left = new StringBuilder();

                var width = _matrix.Width;
                var height = _matrix.Height;

                const int yTop = 0;
                var yBottom = height - 1;
                for (var x = 0; x < width; x++)
                {
                    var xTop = x;
                    var xBottom = x;// width - 1 - x;
                    top.Append(_matrix.ReadValueAt(xTop, yTop));
                    bottom.Append(_matrix.ReadValueAt(xBottom, yBottom));
                }

                var xRight = width - 1;
                const int xLeft = 0;
                for (var y = 0; y < height; y++)
                {
                    var yRight = y;
                    var yLeft = y;//height - 1 - y;
                    right.Append(_matrix.ReadValueAt(xRight, yRight));
                    left.Append(_matrix.ReadValueAt(xLeft, yLeft));
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
            return _matrix.Print();
        }

        public static JigsawTile Parse(string s)
        {
            var parts = s.Split(':');
            var id = long.Parse(parts[0].Split(' ')[1]);
            var matrix = MatrixBuilder.BuildCharMatrix(parts[1].Trim());
            return new JigsawTile(id, matrix);
        }
    }
}