using Core.Puzzles.Year2016.Day16;
using NUnit.Framework;

namespace Tests
{
    public class DragonChecksumTests
    {
        [TestCase("1", "100")]
        [TestCase("0", "001")]
        [TestCase("11111", "11111000000")]
        [TestCase("111100001010", "1111000010100101011110000")]
        public void DataIsCorrect(string input, string expected)
        {
            var dragonCurve = new DragonCurve();
            var data = dragonCurve.ApplyAlgorithm(input);

            Assert.That(data, Is.EqualTo(expected));
        }

        [Test]
        public void DataAndLengthIsCorrect()
        {
            const string input = "111100001010";
            const string expected = "11110000101001010111";
            const int expectedLength = 20;

            var dragonCurve = new DragonCurve();
            var data = dragonCurve.FillDisk(input, expectedLength);

            Assert.That(data, Is.EqualTo(expected));
            Assert.That(data.Length, Is.EqualTo(expectedLength));
        }

        [Test]
        public void ChecksumIsCorrect()
        {
            const string input = "110010110100";
            const string expected = "100";

            var dragonCurve = new DragonCurve();
            var checksum = dragonCurve.Checksum(input);

            Assert.That(checksum, Is.EqualTo(expected));
        }
    }
}