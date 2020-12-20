using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class MatrixTests
    {
        private const char DefaultValue = '.';
        private const char WriteValue = '#';

        [Test]
        public void MoveToWorks()
        {
            var matrix = new Matrix<int>(5, 5);
            matrix.MoveTo(1, 2);

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void MoveForwardWorks()
        {
            var matrix = new Matrix<int>(5, 5);
            matrix.MoveTo(1, 3);
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void TurnAndMoveForwardWorks()
        {
            var matrix = new Matrix<int>(5, 5);
            matrix.TurnRight();
            matrix.MoveForward();
            matrix.TurnRight();
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(1));
        }

        [Test]
        public void ExtendAllTo3()
        {
            var matrix = new Matrix<char>(1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            var emptyRowsValue = matrix.ReadValueAt(0, 0);
            var writtenValue = matrix.ReadValueAt(1, 1);
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(3));
            Assert.That(matrix.Height, Is.EqualTo(3));
        }

        [Test]
        public void ExtendAll5()
        {
            var matrix = new Matrix<char>(1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections(2);

            var emptyRowsValue = matrix.ReadValueAt(0, 0);
            var writtenValue = matrix.ReadValueAt(2, 2);
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(5));
            Assert.That(matrix.Height, Is.EqualTo(5));
        }

        [Test]
        public void PerpendicularAdjacentCoordsExist()
        {
            var matrix = new Matrix<char>(1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            matrix.MoveTo(1, 1);

            Assert.That(matrix.PerpendicularAdjacentCoords.Count, Is.EqualTo(4));

            var adjacentCoords = matrix.PerpendicularAdjacentCoords;
            var squaresAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
            var squaresAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
            Assert.That(squaresAtXZero.Count, Is.EqualTo(1));
            Assert.That(squaresAtYZero.Count, Is.EqualTo(1));
        }

        [Test]
        public void AllAdjacentCoordsExists()
        {
            var matrix = new Matrix<char>(1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            matrix.MoveTo(1, 1);

            Assert.That(matrix.AllAdjacentCoords.Count, Is.EqualTo(8));

            var adjacentCoords = matrix.AllAdjacentCoords;
            var squaresAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
            var squaresAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
            Assert.That(squaresAtXZero.Count, Is.EqualTo(3));
            Assert.That(squaresAtYZero.Count, Is.EqualTo(3));
        }

        [Test]
        public void RotateRight()
        {
            const string input = @"
#..
#..
...";

            const string expected = @"
.##
...
...";

            var matrix = MatrixBuilder.BuildCharMatrix(input);
            var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

            matrix = matrix.RotateRight();

            Assert.That(matrix.Print(), Is.EqualTo(expectedMatrix.Print()));
        }

        [Test]
        public void RotateLeft()
        {
            const string input = @"
#..
#..
...";

            const string expected = @"
...
...
##.";

            var matrix = MatrixBuilder.BuildCharMatrix(input);
            var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

            matrix = matrix.RotateLeft();

            Assert.That(matrix.Print(), Is.EqualTo(expectedMatrix.Print()));
        }

        [Test]
        public void FlipVertical()
        {
            const string input = @"
#..
#..
...";

            const string expected = @"
...
#..
#..";

            var matrix = MatrixBuilder.BuildCharMatrix(input);
            var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

            matrix = matrix.FlipVertical();

            Assert.That(matrix.Print(), Is.EqualTo(expectedMatrix.Print()));
        }

        [Test]
        public void FlipHorizontal()
        {
            const string input = @"
#..
#..
...";

            const string expected = @"
..#
..#
...";

            var matrix = MatrixBuilder.BuildCharMatrix(input);
            var expectedMatrix = MatrixBuilder.BuildCharMatrix(expected);

            matrix = matrix.FlipHorizontal();

            Assert.That(matrix.Print(), Is.EqualTo(expectedMatrix.Print()));
        }
    }
}