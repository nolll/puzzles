using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class MatrixTests
    {
        [Test]
        public void MoveToWorks()
        {
            var matrix = new Matrix(5);
            matrix.MoveTo(1, 2);

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void MoveForwardWorks()
        {
            var matrix = new Matrix(5);
            matrix.MoveTo(1, 3);
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(2));
        }

        [Test]
        public void TurnAndMoveForwardWorks()
        {
            var matrix = new Matrix(5);
            matrix.TurnRight();
            matrix.MoveForward();
            matrix.TurnRight();
            matrix.MoveForward();

            Assert.That(matrix.Address.X, Is.EqualTo(1));
            Assert.That(matrix.Address.Y, Is.EqualTo(1));
        }
    }
}