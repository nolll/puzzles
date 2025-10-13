using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021.Aoc202113;

public class TransparentPaper
{
    private Grid<char> _grid;
    private readonly IList<string> _folds;

    public TransparentPaper(string input)
    {
        var groups = StringReader.ReadLineGroups(input);

        _grid = BuildGrid(groups.First());
        _folds = groups[1];
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

    public int DotCountAfterFirstFold()
    {
        Fold(_folds.First());
        return _grid.Values.Count(o => o == '#');
    }

    public string MessageAfterFold()
    {
        foreach (var fold in _folds) 
            Fold(fold);

        return _grid.Print();
    }

    private void Fold(string fold)
    {
        var (dimension, value) = ParseFoldInstruction(fold);
        Fold(dimension, value);
    }

    private static (char dimension, int value) ParseFoldInstruction(string s)
    {
        var parts = s.Split(' ');
        var dimension = parts[2][0];
        var value = int.Parse(parts[2][2..]);
        return (dimension, value);
    }

    private void Fold(char dimension, int value)
    {
        if (dimension == 'x')
            FoldHorizontal(value);
        else
            FoldVertical(value);
    }

    private void FoldHorizontal(int foldCol)
    {
        var keepTo = new Coord(foldCol - 1, _grid.Height - 1);
        var foldFrom = new Coord(foldCol + 1, 0);

        var newGrid = _grid.Clone().Slice(to: keepTo);
        var foldGrid = _grid.Clone().Slice(foldFrom);
        foldGrid = foldGrid.FlipHorizontal();
        var widthDiff = newGrid.Width - foldGrid.Width;

        for (var y = 0; y < newGrid.Height; y++)
        {
            for (var x = widthDiff; x < newGrid.Width; x++)
            {
                var v = foldGrid.ReadValueAt(x - widthDiff, y);
                if (v == '#')
                {
                    newGrid.WriteValueAt(x, y, v);
                }
            }
        }

        _grid = newGrid;
    }

    private void FoldVertical(int foldRow)
    {
        var keepTo = new Coord(_grid.Width - 1, foldRow - 1);
        var foldFrom = new Coord(0, foldRow + 1);

        var newGrid = _grid.Clone().Slice(to: keepTo);
        var foldGrid = _grid.Clone().Slice(foldFrom);
        foldGrid = foldGrid.FlipVertical();
        var heightDiff = newGrid.Height - foldGrid.Height;

        for (var y = heightDiff; y < newGrid.Height; y++)
        {
            for (var x = 0; x < newGrid.Width; x++)
            {
                var v = foldGrid.ReadValueAt(x, y - heightDiff);
                if (v == '#')
                {
                    newGrid.WriteValueAt(x, y, v);
                }
            }
        }

        _grid = newGrid;
    }
}