using System.Linq;
using Core.Common.CoordinateSystems;
using NUnit.Framework;

namespace Core.CommonTests
{
    public class Matrix4DTests
    {
        private const char DefaultValue = '.';
        private const char WriteValue = '#';

        [Test]
        public void ExtendAllTo3()
        {
            var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            var emptyRowsValue = matrix.ReadValueAt(0, 0, 0, 0);
            var writtenValue = matrix.ReadValueAt(1, 1, 1, 1);
            Assert.That(matrix.Values.Count, Is.EqualTo(81));
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(3));
            Assert.That(matrix.Height, Is.EqualTo(3));
            Assert.That(matrix.Depth, Is.EqualTo(3));
            Assert.That(matrix.Duration, Is.EqualTo(3));
        }

        [Test]
        public void ExtendAll5()
        {
            var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections(2);

            var emptyRowsValue = matrix.ReadValueAt(0, 0, 0, 0);
            var writtenValue = matrix.ReadValueAt(2, 2, 2, 2);
            Assert.That(matrix.Values.Count, Is.EqualTo(625));
            Assert.That(emptyRowsValue, Is.EqualTo(DefaultValue));
            Assert.That(writtenValue, Is.EqualTo(WriteValue));
            Assert.That(matrix.Width, Is.EqualTo(5));
            Assert.That(matrix.Height, Is.EqualTo(5));
            Assert.That(matrix.Depth, Is.EqualTo(5));
            Assert.That(matrix.Duration, Is.EqualTo(5));
        }

        [Test]
        public void AllAdjacentExists()
        {
            var matrix = new Matrix4D<char>(1, 1, 1, 1, DefaultValue);
            matrix.WriteValue(WriteValue);
            matrix.ExtendAllDirections();

            matrix.MoveTo(1, 1, 1, 1);
            
            Assert.That(matrix.AllAdjacentCoords.Count, Is.EqualTo(80));

            var adjacentCoords = matrix.AllAdjacentCoords;
            var cubesAtXZero = adjacentCoords.Where(o => o.X == 0).ToList();
            var cubesAtYZero = adjacentCoords.Where(o => o.Y == 0).ToList();
            var cubesAtZZero = adjacentCoords.Where(o => o.Z == 0).ToList();
            var cubesAtWZero = adjacentCoords.Where(o => o.W == 0).ToList();
            Assert.That(cubesAtXZero.Count, Is.EqualTo(27));
            Assert.That(cubesAtYZero.Count, Is.EqualTo(27));
            Assert.That(cubesAtZZero.Count, Is.EqualTo(27));
            Assert.That(cubesAtWZero.Count, Is.EqualTo(27));
        }
    }
}