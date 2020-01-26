using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class MathToolsTests
    {
        [TestCase(9, 9, 3)]
        [TestCase(90915, 435, 33, 57)]
        [TestCase(616, 2, 4, 8, 77)]
        [TestCase(616, 2, 8, 77)]
        public void FindsLcm(long expected, params long[] numbers)
        {
            var result = MathTools.Lcm(numbers);

            Assert.That(result, Is.EqualTo(expected));
        }
    }

    public class MatrixTests
    {
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
    }
}