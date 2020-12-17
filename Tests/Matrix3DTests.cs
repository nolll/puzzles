using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class Matrix3DTests
    {
        private const char DefaultValue = '.';
        private const char WriteValue = '#';

        [Test]
        public void ExtendAllTo3()
        {
            var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            var emptyRowsValue = matrix.ReadValueAt(0, 0, 0);
            var writtenValue = matrix.ReadValueAt(1, 1, 1);
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(3));
            Assert.That(matrix.Height, Is.EqualTo(3));
            Assert.That(matrix.Depth, Is.EqualTo(3));
        }

        [Test]
        public void ExtendAll5()
        {
            var matrix = new Matrix3D<char>(1, 1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections(2);

            var emptyRowsValue = matrix.ReadValueAt(0, 0, 0);
            var writtenValue = matrix.ReadValueAt(2, 2, 2);
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(5));
            Assert.That(matrix.Height, Is.EqualTo(5));
            Assert.That(matrix.Depth, Is.EqualTo(5));
        }
    }
}