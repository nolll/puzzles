using System.Text;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

public class JigsawTile
{
    public long Id { get; }
    public Grid<char> Grid;

    private JigsawTile(long id, Grid<char> grid)
    {
        Id = id;
        Grid = grid;
    }

    public bool HasMatchingEdge(JigsawTile otherTile) => 
        Edges.Values.Any(edge => otherTile.Edges.Values.Any(HasMatchingEdge));

    public bool HasMatchingEdge(string edge)
    {
        var reverseEdge = edge.ReverseString();
        return Edges.Any(o => o.Value == edge || o.Value == reverseEdge);
    }

    public void RotateRight() => Grid = Grid.RotateRight();
    public void FlipVertical() => Grid = Grid.FlipVertical();
    public void FlipHorizontal() => Grid = Grid.FlipHorizontal();

    public Dictionary<string, string> Edges
    {
        get
        {
            var top = new StringBuilder();
            var right = new StringBuilder();
            var bottom = new StringBuilder();
            var left = new StringBuilder();

            var width = Grid.Width;
            var height = Grid.Height;

            const int yTop = 0;
            var yBottom = height - 1;
            for (var x = 0; x < width; x++)
            {
                top.Append(Grid.ReadValueAt(x, yTop));
                bottom.Append(Grid.ReadValueAt(x, yBottom));
            }

            var xRight = width - 1;
            const int xLeft = 0;
            for (var y = 0; y < height; y++)
            {
                right.Append(Grid.ReadValueAt(xRight, y));
                left.Append(Grid.ReadValueAt(xLeft, y));
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
        var grid = GridBuilder.BuildCharGrid(parts[1].Trim());
        return new JigsawTile(id, grid);
    }

    public void RemoveBorder()
    {
        Grid = Grid.Slice(new Coord(Grid.XMin + 1, Grid.YMin + 1), new Coord(Grid.XMax - 1, Grid.YMax - 1));
    }
}