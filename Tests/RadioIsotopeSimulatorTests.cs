using ConsoleApp.Puzzles.Year2016.Puzzles.Day11;
using NUnit.Framework;

namespace Tests
{
    public class RadioIsotopeSimulatorTests
    {
        [Test]
        public void StepCountIsCorrect()
        {
            const string input = @"
The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.
The second floor contains a hydrogen generator.
The third floor contains a lithium generator.
The fourth floor contains nothing relevant.";

            var simulator = new RadioisotopeSimulator(input);

            Assert.That(simulator.StepCount, Is.EqualTo(11));
        }
    }
}