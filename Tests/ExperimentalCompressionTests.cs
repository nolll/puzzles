using Core.ExperimentalCompression;
using NUnit.Framework;

namespace Tests
{
    public class ExperimentalCompressionTests
    {
        [TestCase("ADVENT", "ADVENT")]
        [TestCase("A(1x5)BC", "ABBBBBC")]
        [TestCase("(3x3)XYZ", "XYZXYZXYZ")]
        [TestCase("A(2x2)BCD(2x2)EFG", "ABCBCDEFEFG")]
        [TestCase("(6x1)(1x3)A", "(1x3)A")]
        [TestCase("X(8x2)(3x3)ABCY", "X(3x3)ABC(3x3)ABCY")]
        public void DecompressesFiles(string input, string expected)
        {
            var decompressor = new FileDecompressor(input);

            Assert.That(decompressor.Decompressed, Is.EqualTo(expected));
        }
    }
}