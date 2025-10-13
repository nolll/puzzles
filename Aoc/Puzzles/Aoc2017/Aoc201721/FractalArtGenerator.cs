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
    private readonly IDictionary<string, IList<MatrixVariant>> _variantCache;
    private readonly IDictionary<string, Grid<char>> _transformCache;

    public int PixelsOn => _grid.Values.Count(o => o == '#');

    public FractalArtGenerator(string input)
    {
        var rules = ParseRules(input);
        _transformationRules2X2 = rules.Where(o => o.Input.Length == 5).ToList();
        _transformationRules3X3 = rules.Where(o => o.Input.Length != 5).ToList();

        _grid = GridBuilder.BuildCharGrid(Inital);
        _variantCache = new Dictionary<string, IList<MatrixVariant>>();
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
        var subMatrixSize = size % 2 == 0 ? 2 : 3;
        Modify(subMatrixSize);
    }

    private void Modify(int subSize)
    {
        var matrices = GetSubmatrices(subSize);
        var transformed = new List<Grid<char>>();
        foreach (var matrix in matrices)
        {
            transformed.Add(Transform(matrix));
        }

        _grid = Join(transformed);
    }

    private static Grid<char> Join(List<Grid<char>> matrices)
    {
        var newMatrix = new Grid<char>();
        var size = matrices.First().Width;
        var matricesPerRow = (int)Math.Sqrt(matrices.Count);
        var col = 0;
        var row = 0;
        foreach (var matrix in matrices)
        {
            for (var y = 0; y < matrix.Height; y++)
            {
                for (var x = 0; x < matrix.Width; x++)
                {
                    var localX = x + col * size;
                    var localY = y + row * size;
                    newMatrix.MoveTo(localX, localY);
                    newMatrix.WriteValue(matrix.ReadValueAt(x, y));
                }
            }

            col++;
            if (col >= matricesPerRow)
            {
                col = 0;
                row++;
            }
        }

        return newMatrix;
    }

    private class MatrixVariant
    {
        public string Key { get; }

        public MatrixVariant(string key)
        {
            Key = key;
        }
    }

    private IList<MatrixVariant> GetVariants(Grid<char> grid)
    {
        var key = MatrixToString(grid);
        if (_variantCache.TryGetValue(key, out var variants))
            return variants;
            
        variants = CreateVariants(grid).ToList();
        _variantCache.Add(key, variants);
        return variants;
    }

    private static IEnumerable<MatrixVariant> CreateVariants(Grid<char> grid)
    {
        yield return new MatrixVariant(MatrixToString(grid));

        var flippedMatrix = FlipMatrixHorizontally(grid);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        flippedMatrix = FlipMatrixVertically(grid);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        var rotatedMatrix = RotateMatrixRight(grid);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix));

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        rotatedMatrix = RotateMatrixRight(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix));

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        rotatedMatrix = RotateMatrixRight(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix));

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix));
    }

    private Grid<char> Transform(Grid<char> grid)
    {
        var key = MatrixToString(grid);
        if (_transformCache.TryGetValue(key, out var transformedMatrix))
            return transformedMatrix;

        var variants = GetVariants(grid);
        var size = grid.Width;
        var rules = size == 2 ? _transformationRules2X2 : _transformationRules3X3;

        foreach (var rule in rules)
        {
            foreach (var variant in variants)
            {
                if (rule.IsMatch(variant.Key))
                {
                    transformedMatrix = rule.Output;
                    _transformCache.Add(key, transformedMatrix);
                    return transformedMatrix;
                }
                        
            }
        }

        throw new Exception("No transformation rule matched");
    }

    private static Grid<char> FlipMatrixHorizontally(Grid<char> grid)
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

    private static Grid<char> FlipMatrixVertically(Grid<char> grid)
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

    private static Grid<char> RotateMatrixRight(Grid<char> grid)
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

    private static string MatrixToString(Grid<char> grid)
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

    private IEnumerable<Grid<char>> GetSubmatrices(int subSize)
    {
        var size = _grid.Width;
        var x = 0;
        var y = 0;
        while (y < size)
        {
            while (x < size)
            {
                var matrix = new Grid<char>();
                for (var localY = 0; localY < subSize; localY++)
                {
                    for (var localX = 0; localX < subSize; localX++)
                    {
                        matrix.MoveTo(localX, localY);
                        matrix.WriteValue(_grid.ReadValueAt(x + localX, y + localY));
                    }
                }

                x += subSize;
                yield return matrix;
            }

            y += subSize;
            x = 0;
        }
            
    }
}