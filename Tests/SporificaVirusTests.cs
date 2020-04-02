using Core.SporificaVirus;
using NUnit.Framework;

namespace Tests
{
    public class SporificaVirusTests
    {
        [TestCase(7, 5)]
        [TestCase(70, 41)]
        [TestCase(10000, 5587)]
        public void InfectionCountIsCorrect(int iterations, int expected)
        {
            var input = @"
..#
#..
...";

            var infection = new VirusInfection(input);
            var infectionCount = infection.Run(iterations);

            Assert.That(infectionCount, Is.EqualTo(expected));
        }
    }
}