using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.ImageJigsaw
{
    public class JigsawTile
    {
        public long Id { get; }
        private readonly Matrix<char> _matrix;
        public Dictionary<string, string> Edges { get; }

        public JigsawTile(long id, Matrix<char> matrix)
        {
            Id = id;
            _matrix = matrix;
            Edges = GetEdges();
        }

        public int MatchingEdgeCount(IList<JigsawTile> tiles)
        {
            var matchCount = 0;
            foreach (var tile in tiles)
            {
                if (tile.Id != Id)
                {
                    if (HasMatchingEdge(tile))
                        matchCount++;
                }
            }

            return matchCount;
        }

        public bool HasMatchingEdge(JigsawTile otherTile)
        {
            foreach (var edge in Edges.Values)
            {
                var reverseEdge = Reverse(edge);
                if (otherTile.Edges.Any(o => o.Value == edge || o.Value == reverseEdge))
                    return true;
            }

            return false;
        }

        public static string Reverse(string s)
        {
            var charArray = s.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private Dictionary<string, string> GetEdges()
        {
            var top = new StringBuilder();
            var right = new StringBuilder();
            var bottom = new StringBuilder();
            var left = new StringBuilder();

            const int yTop = 0;
            var yBottom = _matrix.Height - 1;
            for (var x = 0; x < _matrix.Width; x++)
            {
                top.Append(_matrix.ReadValueAt(x, yTop));
                bottom.Append(_matrix.ReadValueAt(x, yBottom));
            }

            var xRight = _matrix.Width - 1;
            const int xLeft = 0;
            for (var y = 0; y < _matrix.Height; y++)
            {
                right.Append(_matrix.ReadValueAt(xRight, y));
                left.Append(_matrix.ReadValueAt(xLeft, y));
            }

            return new Dictionary<string, string>
            {
                {"top", top.ToString()},
                {"right", right.ToString()},
                {"bottom", bottom.ToString()},
                {"left", left.ToString()}
            };
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