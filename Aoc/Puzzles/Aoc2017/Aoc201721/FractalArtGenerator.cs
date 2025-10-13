using System.Text;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017.Aoc201721;

public class FractalArtGenerator
{
    private const string Inital = """
                                  .#.
                                  ..#
                                  ###
                                  """;

    private Grid<char> _grid;
    private readonly IList<FractalRule> _transformationRules2X2;
    private readonly IList<FractalRule> _transformationRules3X3;
    private readonly IDictionary<string, IList<GridVariant>> _variantCache;
    private readonly IDictionary<string, Grid<char>> _transformCache;

    public int PixelsOn => _grid.Values.Count(o => o == '#');

    public FractalArtGenerator(string input)
    {
        var rules = ParseRules(input);
        _transformationRules2X2 = rules.Where(o => o.Input.Length == 5).ToList();
        _transformationRules3X3 = rules.Where(o => o.Input.Length != 5).ToList();

        _grid = GridBuilder.BuildCharGrid(Inital);
        _variantCache = new Dictionary<string, IList<GridVariant>>();
        _transformCache = new Dictionary<string, Grid<char>>();
    }

    private static IList<FractalRule> ParseRules(string input)
    {
        var rows = StringReader.ReadLines(input);
        return rows.Select(ParseRule).ToList();
    }

    private static FractalRule ParseRule(string s)
    {
        var parts = s.Split(" => ");
        var input = parts[0];
        var output = parts[1];

        return new FractalRule(input, output);
    }

    public void Run(int iterations)
    {
        var iteration = 0;
        while (iteration < iterations)
        {
            Modify();
            iteration++;
        }
    }

    private void Modify()
    {
        var size = _grid.Width;
        var subgridSize = size % 2 == 0 ? 2 : 3;
        Modify(subgridSize);
    }

    private void Modify(int subSize)
    {
        _grid = Join(GetSubgrids(subSize).Select(Transform).ToList());
    }

    private static Grid<char> Join(List<Grid<char>> grids)
    {
        var newGrid = new Grid<char>();
        var size = grids.First().Width;
        var gridsPerRow = (int)Math.Sqrt(grids.Count);
        var col = 0;
        var row = 0;
        foreach (var grid in grids)
        {
            for (var y = 0; y < grid.Height; y++)
            {
                for (var x = 0; x < grid.Width; x++)
                {
                    var localX = x + col * size;
                    var localY = y + row * size;
                    newGrid.MoveTo(localX, localY);
                    newGrid.WriteValue(grid.ReadValueAt(x, y));
                }
            }

            col++;
            if (col >= gridsPerRow)
            {
                col = 0;
                row++;
            }
        }

        return newGrid;
    }

    private record GridVariant(string Key);

    private IList<GridVariant> GetVariants(Grid<char> grid)
    {
        var key = GridToString(grid);
        if (_variantCache.TryGetValue(key, out var variants))
            return variants;
            
        variants = CreateVariants(grid).ToList();
        _variantCache.Add(key, variants);
        return variants;
    }

    private static IEnumerable<GridVariant> CreateVariants(Grid<char> grid)
    {
        yield return new GridVariant(GridToString(grid));

        var flippedGrid = FlipGridHorizontally(grid);
        yield return new GridVariant(GridToString(flippedGrid));

        flippedGrid = FlipGridVertically(grid);
        yield return new GridVariant(GridToString(flippedGrid));

        var rotatedGrid = RotateGridRight(grid);
        yield return new GridVariant(GridToString(rotatedGrid));

        flippedGrid = FlipGridHorizontally(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));

        flippedGrid = FlipGridVertically(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));

        rotatedGrid = RotateGridRight(rotatedGrid);
        yield return new GridVariant(GridToString(rotatedGrid));

        flippedGrid = FlipGridHorizontally(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));

        flippedGrid = FlipGridVertically(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));

        rotatedGrid = RotateGridRight(rotatedGrid);
        yield return new GridVariant(GridToString(rotatedGrid));

        flippedGrid = FlipGridHorizontally(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));

        flippedGrid = FlipGridVertically(rotatedGrid);
        yield return new GridVariant(GridToString(flippedGrid));
    }

    private Grid<char> Transform(Grid<char> grid)
    {
        var key = GridToString(grid);
        if (_transformCache.TryGetValue(key, out var transformedGrid))
            return transformedGrid;

        var variants = GetVariants(grid);
        var size = grid.Width;
        var rules = size == 2 ? _transformationRules2X2 : _transformationRules3X3;

        foreach (var rule in rules)
        {
            foreach (var variant in variants)
            {
                if (rule.IsMatch(variant.Key))
                {
                    transformedGrid = rule.Output;
                    _transformCache.Add(key, transformedGrid);
                    return transformedGrid;
                }
                        
            }
        }

        throw new Exception("No transformation rule matched");
    }

    private static Grid<char> FlipGridHorizontally(Grid<char> grid)
    {
        var width = grid.Width;
        var flipped = new Grid<char>();
        for (var y = 0; y < grid.Height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                flipped.MoveTo(width - x - 1, y);
                flipped.WriteValue(grid.ReadValueAt(x, y));
            }
        }

        return flipped;
    }

    private static Grid<char> FlipGridVertically(Grid<char> grid)
    {
        var height = grid.Height;
        var flipped = new Grid<char>();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                flipped.MoveTo(x, height - y - 1);
                flipped.WriteValue(grid.ReadValueAt(x, y));
            }
        }

        return flipped;
    }

    private static Grid<char> RotateGridRight(Grid<char> grid)
    {
        var height = grid.Height;
        var flipped = new Grid<char>(1, 1, ' ');
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                var value = grid.ReadValueAt(x, y);
                flipped.MoveTo(height - y - 1, x);
                flipped.WriteValue(value);
            }
        }

        return flipped;
    }

    private static string GridToString(Grid<char> grid)
    {
        var sb = new StringBuilder();
        for (var y = 0; y < grid.Height; y++)
        {
            for (var x = 0; x < grid.Width; x++)
            {
                sb.Append(grid.ReadValueAt(x, y));
            }

            sb.Append("/");
        }

        return sb.ToString().TrimEnd('/');
    }

    private IEnumerable<Grid<char>> GetSubgrids(int subSize)
    {
        var size = _grid.Width;
        var x = 0;
        var y = 0;
        while (y < size)
        {
            while (x < size)
            {
                var grid = new Grid<char>();
                for (var localY = 0; localY < subSize; localY++)
                {
                    for (var localX = 0; localX < subSize; localX++)
                    {
                        grid.MoveTo(localX, localY);
                        grid.WriteValue(_grid.ReadValueAt(x + localX, y + localY));
                    }
                }

                x += subSize;
                yield return grid;
            }

            y += subSize;
            x = 0;
        }
            
    }
}