using System.Collections.Generic;
using System.Linq;
using App.Common.CoordinateSystems;
using App.Common.Strings;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace App.Puzzles.Year2021.Day13
{
    public class Year2021Day13Tests
    {
        [Test]
        public void Part1()
        {
            var paper = new TransparentPaper(Input);
            var result = paper.DotCountAfterFold(1);

            Assert.That(result, Is.EqualTo(17));
        }

        [Test]
        public void Part2()
        {
            var result = 0;

            Assert.That(result, Is.EqualTo(0));
        }

        private const string Input = @"
6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5";
    }

    public class TransparentPaper
    {
        private Matrix<char> _matrix;
        private IList<string> _folds;

        public TransparentPaper(string input)
        {
            var groups = PuzzleInputReader.ReadLineGroups(input);

            _matrix = BuildMatrix(groups.First());
            _folds = groups[1];
        }

        private Matrix<char> BuildMatrix(IList<string> rows)
        {
            var matrix = new Matrix<char>(defaultValue: '.');

            foreach (var row in rows)
            {
                var parts = row.Split(',').Select(int.Parse).ToArray();
                var x = parts[0];
                var y = parts[1];

                matrix.MoveTo(x, y);
                matrix.WriteValue('#');
            }

            matrix.MoveTo(0, 0);

            return matrix;
        }

        public int DotCountAfterFold(int? maxFolds = null)
        {
            var foldCount = 0;
            foreach (var fold in _folds)
            {
                var parts = fold.Split(' ');
                var dimension = parts[2][0];
                var value = int.Parse(parts[2][2..]);

                Fold(dimension, value);

                foldCount++;
                if (foldCount >= maxFolds)
                    break;
            }

            return _matrix.Values.Count(o => o == '#');
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
            

        }

        private void FoldVertical(int foldRow)
        {
            var newMatrix = _matrix.Copy().Slice(new MatrixAddress(0, 0), new MatrixAddress(_matrix.Width - 1, foldRow - 1));
            var foldMatrix = _matrix.Copy().Slice(new MatrixAddress(0, foldRow + 1), new MatrixAddress(_matrix.Width - 1, _matrix.Height - 1));
            foldMatrix = foldMatrix.FlipVertical();
            var heightDiff = newMatrix.Height - foldMatrix.Height;

            for (var y = 0; y < newMatrix.Height; y++)
            {
                for (var x = 0; x < newMatrix.Width; x++)
                {
                    var v = foldMatrix.ReadValueAt(x, y);
                    if (v == '#')
                    {
                        newMatrix.MoveTo(x, y);
                        newMatrix.WriteValue(v);
                    }
                }
            }

            _matrix = newMatrix;
        }
    }
}