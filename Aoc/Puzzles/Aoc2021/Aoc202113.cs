using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Ocr;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Transparent Origami")]
public class Aoc202113 : AocPuzzle
{
    [Puzzle("d90cdd38e041f8d021655ac90de64e69")]
    public int Part1(string input)
    {
        var (grid, folds) = Parse(input);
        grid = Fold(grid, folds.First());
        return grid.Values.Count(o => o == '#');
    }

    [Puzzle("e96b781220e2551d8c04eaa523de4934")]
    public string Part2(string input) => OcrSmallFont.ReadString(MessageAfterFold(input));

    public string MessageAfterFold(string input)
    {
        var (grid, folds) = Parse(input);
        foreach (var fold in folds)
            grid = Fold(grid, fold);

        return grid.Print();
    }

    private static Grid<char> Fold(Grid<char> grid, string fold)
    {
        var (dimension, value) = ParseFoldInstruction(fold);
        return Fold(grid, dimension, value);
    }

    private static (char dimension, int value) ParseFoldInstruction(string s)
    {
        var parts = s.Split(' ');
        var dimension = parts[2][0];
        var value = int.Parse(parts[2][2..]);
        return (dimension, value);
    }

    private static Grid<char> Fold(Grid<char> grid, char dimension, int value) => dimension == 'x'
        ? FoldHorizontal(grid, value)
        : FoldVertical(grid, value);

    private static Grid<char> FoldHorizontal(Grid<char> grid, int foldCol)
    {
        var keepTo = new Coord(foldCol - 1, grid.Height - 1);
        var foldFrom = new Coord(foldCol + 1, 0);

        var newGrid = grid.Clone().Slice(to: keepTo);
        var foldGrid = grid.Clone().Slice(foldFrom);
        foldGrid = foldGrid.FlipHorizontal();
        var widthDiff = newGrid.Width - foldGrid.Width;

        for (var y = 0; y < newGrid.Height; y++)
        {
            for (var x = widthDiff; x < newGrid.Width; x++)
            {
                var v = foldGrid.ReadValueAt(x - widthDiff, y);
                if (v == '#')
                    newGrid.WriteValueAt(x, y, v);
            }
        }

        return newGrid;
    }

    private static Grid<char> FoldVertical(Grid<char> grid, int foldRow)
    {
        var keepTo = new Coord(grid.Width - 1, foldRow - 1);
        var foldFrom = new Coord(0, foldRow + 1);

        var newGrid = grid.Clone().Slice(to: keepTo);
        var foldGrid = grid.Clone().Slice(foldFrom);
        foldGrid = foldGrid.FlipVertical();
        var heightDiff = newGrid.Height - foldGrid.Height;

        for (var y = heightDiff; y < newGrid.Height; y++)
        {
            for (var x = 0; x < newGrid.Width; x++)
            {
                var v = foldGrid.ReadValueAt(x, y - heightDiff);
                if (v == '#')
                    newGrid.WriteValueAt(x, y, v);
            }
        }

        return newGrid;
    }

    private static Grid<char> BuildGrid(IEnumerable<string> rows)
    {
        var grid = new Grid<char>(defaultValue: '.');

        foreach (var row in rows)
        {
            var parts = row.Split(',').Select(int.Parse).ToArray();
            var x = parts[0];
            var y = parts[1];

            grid.WriteValueAt(x, y, '#');
        }

        return grid;
    }

    private static (Grid<char>, IList<string>) Parse(string input)
    {
        var groups = input
            .Split(LineBreaks.Double)
            .Select(o => o.Split(LineBreaks.Single))
            .ToList();

        var grid = BuildGrid(groups.First());
        var folds = groups[1];
        return (grid, folds);
    }
}