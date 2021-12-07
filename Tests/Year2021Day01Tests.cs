using Core.Puzzles.Year2021.Day01;
using NUnit.Framework;

namespace Tests
{
    public class Year2021Day01Tests
    {
        [Test]
        public void Part1()
        {
            var validator = new DepthMeasurement();
            var result = validator.GetNumberOfIncreasingMeasurements(Input, false);

            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Part2()
        {
            var validator = new DepthMeasurement();
            var result = validator.GetNumberOfIncreasingMeasurements(Input, true);

            Assert.That(result, Is.EqualTo(5));
        }

        private const string Input = @"
199
200
208
210
200
207
240
269
260
263";
    }
}