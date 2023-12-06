using System.Text;
using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

public class JigsawTile
{
    public long Id { get; }
    public Matrix<char> Matrix;

    private JigsawTile(long id, Matrix<char> matrix)
    {
        Id = id;
        Matrix = matrix;
    }

    public bool HasMatchingEdge(JigsawTile otherTile) => 
        Edges.Values.Any(edge => otherTile.Edges.Values.Any(HasMatchingEdge));

    public bool HasMatchingEdge(string edge)
    {
        var reverseEdge = edge.ReverseString();
        return Edges.Any(o => o.Value == edge || o.Value == reverseEdge);
    }

    public void RotateRight() => Matrix = Matrix.RotateRight();
    public void FlipVertical() => Matrix = Matrix.FlipVertical();
    public void FlipHorizontal() => Matrix = Matrix.FlipHorizontal();

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
    
    public static JigsawTile Parse(string s)
    {
        var parts = s.Split(':');
        var id = long.Parse(parts[0].Split(' ')[1]);
        var matrix = MatrixBuilder.BuildCharMatrix(parts[1].Trim());
        return new JigsawTile(id, matrix);
    }

    public void RemoveBorder()
    {
        Matrix = Matrix.Slice(new MatrixAddress(Matrix.XMin + 1, Matrix.YMin + 1), new MatrixAddress(Matrix.XMax - 1, Matrix.YMax - 1));
    }
}