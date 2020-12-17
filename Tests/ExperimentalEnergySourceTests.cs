using Core.ExperimentalEnergySource;
using NUnit.Framework;

namespace Tests
{
    public class ExperimentalEnergySourceTests
    {
        [Test]
        public void AfterSixIterations()
        {
            const string input = @"
.#.
..#
###";

            var cube = new ConwayCube();
            var activeCubes = cube.Boot(input, 6);

            Assert.That(activeCubes, Is.EqualTo(112));
        }
    }
}