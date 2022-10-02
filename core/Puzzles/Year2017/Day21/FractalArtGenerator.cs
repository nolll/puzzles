using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Common.CoordinateSystems;
using Core.Common.Strings;

namespace Core.Puzzles.Year2017.Day21;

public class FractalArtGenerator
{
    private const string Inital = @"
.#.
..#
###";

    private IMatrix<char> _matrix;
    private readonly IList<FractalRule> _transformationRules2X2;
    private readonly IList<FractalRule> _transformationRules3X3;
    private readonly IDictionary<string, IList<MatrixVariant>> _variantCache;
    private readonly IDictionary<string, IMatrix<char>> _transformCache;

    public int PixelsOn => _matrix.Values.Count(o => o == '#');

    public FractalArtGenerator(string input)
    {
        var rules = ParseRules(input);
        _transformationRules2X2 = rules.Where(o => o.Input.Length == 5).ToList();
        _transformationRules3X3 = rules.Where(o => o.Input.Length != 5).ToList();

        _matrix = MatrixBuilder.BuildCharMatrix(Inital);
        _variantCache = new Dictionary<string, IList<MatrixVariant>>();
        _transformCache = new Dictionary<string, IMatrix<char>>();
    }

    private IList<FractalRule> ParseRules(string input)
    {
        var rows = PuzzleInputReader.ReadLines(input);
        return rows.Select(ParseRule).ToList();
    }

    private FractalRule ParseRule(string s)
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
        var size = _matrix.Width;
        var subMatrixSize = size % 2 == 0 ? 2 : 3;
        Modify(subMatrixSize);
    }

    private void Modify(int subSize)
    {
        var matrices = GetSubmatrices(subSize);
        var transformed = new List<IMatrix<char>>();
        foreach (var matrix in matrices)
        {
            transformed.Add(Transform(matrix));
        }

        _matrix = Join(transformed);
    }

    private DynamicMatrix<char> Join(List<IMatrix<char>> matrices)
    {
        var newMatrix = new DynamicMatrix<char>();
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
        private readonly IMatrix<char> _matrix;
        public string Key { get; }

        public MatrixVariant(string key, IMatrix<char> matrix)
        {
            _matrix = matrix;
            Key = key;
        }
    }

    private IList<MatrixVariant> GetVariants(IMatrix<char> matrix)
    {
        var key = MatrixToString(matrix);
        if (_variantCache.TryGetValue(key, out var variants))
            return variants;
            
        variants = CreateVariants(matrix).ToList();
        _variantCache.Add(key, variants);
        return variants;
    }

    private IEnumerable<MatrixVariant> CreateVariants(IMatrix<char> matrix)
    {
        yield return new MatrixVariant(MatrixToString(matrix), matrix);

        var flippedMatrix = FlipMatrixHorizontally(matrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        flippedMatrix = FlipMatrixVertically(matrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        var rotatedMatrix = RotateMatrixRight(matrix);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix), rotatedMatrix);

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        rotatedMatrix = RotateMatrixRight(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix), rotatedMatrix);

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        rotatedMatrix = RotateMatrixRight(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(rotatedMatrix), rotatedMatrix);

        flippedMatrix = FlipMatrixHorizontally(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);

        flippedMatrix = FlipMatrixVertically(rotatedMatrix);
        yield return new MatrixVariant(MatrixToString(flippedMatrix), flippedMatrix);
    }

    private IMatrix<char> Transform(IMatrix<char> matrix)
    {
        var key = MatrixToString(matrix);
        if (_transformCache.TryGetValue(key, out var transformedMatrix))
            return transformedMatrix;

        var variants = GetVariants(matrix);
        var size = matrix.Width;
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

    private DynamicMatrix<char> FlipMatrixHorizontally(IMatrix<char> matrix)
    {
        var width = matrix.Width;
        var flipped = new DynamicMatrix<char>();
        for (var y = 0; y < matrix.Height; y++)
        {
            for (var x = 0; x < width; x++)
            {
                flipped.MoveTo(width - x - 1, y);
                flipped.WriteValue(matrix.ReadValueAt(x, y));
            }
        }

        return flipped;
    }

    private DynamicMatrix<char> FlipMatrixVertically(IMatrix<char> matrix)
    {
        var height = matrix.Height;
        var flipped = new DynamicMatrix<char>();
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < matrix.Width; x++)
            {
                flipped.MoveTo(x, height - y - 1);
                flipped.WriteValue(matrix.ReadValueAt(x, y));
            }
        }

        return flipped;
    }

    private DynamicMatrix<char> RotateMatrixRight(IMatrix<char> matrix)
    {
        var height = matrix.Height;
        var flipped = new DynamicMatrix<char>(1, 1, ' ');
        for (var y = 0; y < height; y++)
        {
            for (var x = 0; x < matrix.Width; x++)
            {
                var value = matrix.ReadValueAt(x, y);
                flipped.MoveTo(height - y - 1, x);
                flipped.WriteValue(value);
            }
        }

        return flipped;
    }

    private string MatrixToString(IMatrix<char> matrix)
    {
        var sb = new StringBuilder();
        for (var y = 0; y < matrix.Height; y++)
        {
            for (var x = 0; x < matrix.Width; x++)
            {
                sb.Append(matrix.ReadValueAt(x, y));
            }

            sb.Append("/");
        }

        return sb.ToString().TrimEnd('/');
    }

    private IEnumerable<DynamicMatrix<char>> GetSubmatrices(int subSize)
    {
        var size = _matrix.Width;
        var x = 0;
        var y = 0;
        while (y < size)
        {
            while (x < size)
            {
                var matrix = new DynamicMatrix<char>();
                for (var localY = 0; localY < subSize; localY++)
                {
                    for (var localX = 0; localX < subSize; localX++)
                    {
                        matrix.MoveTo(localX, localY);
                        matrix.WriteValue(_matrix.ReadValueAt(x + localX, y + localY));
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