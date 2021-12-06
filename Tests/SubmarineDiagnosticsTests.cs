using Core.Puzzles.Year2021.Day03;
using NUnit.Framework;

namespace Tests
{
    public class SubmarineDiagnosticsTests
    {
        [Test]
        public void Part1()
        {
            var diagnostics = new BinaryDiagnostics();
            var result = diagnostics.GetFuelConsumption(Input);

            Assert.That(result, Is.EqualTo(198));
        }

        [Test]
        public void Part2()
        {
            var diagnostics = new BinaryDiagnostics();
            var result = diagnostics.GetLifeSupportRating(Input);

            Assert.That(result, Is.EqualTo(230));
        }

        private const string Input = @"
00100
11110
10110
10111
10101
01111
00111
11100
10000
11001
00010
01010";
    }
}