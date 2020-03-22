using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class FractalArtTests
    {
        [Test]
        public void TwelvePixelsOnAfterTwoIterations()
        {
            const string input = @"
../.# => ##./#../...
.#./..#/### => #..#/..../..../#..#";

            var generator = new FractalArtGenerator(input);
            generator.Run(2);

            Assert.That(generator.PixelsOn, Is.EqualTo(12));
        }
    }

    public class FractalArtGenerator
    {
        private const string Inital = @"
.#.
..#
###";

        private Matrix<char> _matrix;
        private IList<FractalRule> _transformationRules;
        public int PixelsOn => _matrix.Values.Count(o => o == '#');

        public FractalArtGenerator(string input)
        {
            _transformationRules = ParseRules(input);

            _matrix = MatrixBuilder.BuildCharMatrix(Inital);
        }

        private IList<FractalRule> ParseRules(string input)
        {
            var rows = PuzzleInputReader.Read(input);
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
            throw new Exception("Matrix not divisible by two or three");
        }

        private void Modify(int subSize)
        {
            var matrices = GetSubmatrices(2);
            var transformed = new List<Matrix<char>>();
            foreach (var matrix in matrices)
            {
                transformed.Add(Transform(matrix));
            }

            _matrix = Join(transformed);
        }

        private Matrix<char> Join(List<Matrix<char>> matrices)
        {
            var newMatrix = new Matrix<char>();
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

        private Matrix<char> Transform(Matrix<char> matrix)
        {
            foreach (var rule in _transformationRules)
            {
                if (rule.IsMatch(MatrixToString(matrix)))
                    return rule.Output;

                var rotatedMatrix = RotateMatrix(matrix);
                if (rule.IsMatch(MatrixToString(rotatedMatrix)))
                    return rule.Output;

                rotatedMatrix = RotateMatrix(rotatedMatrix);
                if (rule.IsMatch(MatrixToString(rotatedMatrix)))
                    return rule.Output;

                rotatedMatrix = RotateMatrix(rotatedMatrix);
                if (rule.IsMatch(MatrixToString(rotatedMatrix)))
                    return rule.Output;

                var flippedMatrix1 = FlipMatrixHorizontally(matrix);
                if (rule.IsMatch(MatrixToString(flippedMatrix1)))
                    return rule.Output;

                var flippedMatrix2 = FlipMatrixVertically(matrix);
                if (rule.IsMatch(MatrixToString(flippedMatrix2)))
                    return rule.Output;
            }

            throw new Exception("No transformation rule matched");
        }

        private Matrix<char> FlipMatrixHorizontally(Matrix<char> matrix)
        {
            var width = matrix.Width;
            var flipped = new Matrix<char>();
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

        private Matrix<char> FlipMatrixVertically(Matrix<char> matrix)
        {
            var height = matrix.Height;
            var flipped = new Matrix<char>();
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

        private string MatrixToString(Matrix<char> matrix)
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

        private IEnumerable<Matrix<char>> GetSubmatrices(int subSize)
        {
            var size = _matrix.Width;
            var x = 0;
            var y = 0;
            while (y < size)
            {
                while (x < size)
                {
                    var matrix = new Matrix<char>();
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
            }
            
        }
    }

    public class FractalRule
    {
        private readonly string _input;
        public Matrix<char> Output { get; }

        public FractalRule(string input, string output)
        {
            _input = input;
            Output = MatrixBuilder.BuildCharMatrix(output.Replace("/", "\n"));
        }

        public bool IsMatch(string compare)
        {
            return compare == _input;
        }
    }
}