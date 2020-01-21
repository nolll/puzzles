using Core.FuelSquare;
using NUnit.Framework;

namespace Tests
{
    public class FuelSquareTests
    {
        [TestCase(122, 79, 57, -5)]
        [TestCase(217, 196, 39, 0)]
        [TestCase(101, 153, 71, 4)]
        public void SinglePowerLevelIsCorrect(int x, int y, int serialNumber, int expected)
        {
            var grid = new PowerGrid(300, serialNumber);
            var level = grid.GetSinglePowerLevel(x, y);

            Assert.That(level, Is.EqualTo(expected));
        }

        [TestCase(18, "90,269,16")]
        [TestCase(42, "232,251,12")]
        public void AnySizePowerLevelIsCorrect(int serialNumber, string expected)
        {
            var grid = new PowerGrid(10, serialNumber);
            var (coords, size) = grid.GetMaxCoordsAnySizeSlow();
            var str = $"{coords.X},{coords.Y},{size}";

            Assert.That(str, Is.EqualTo(expected));
        }
    }
}