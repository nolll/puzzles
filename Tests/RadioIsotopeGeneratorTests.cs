using System.Collections.Generic;
using System.Linq;
using Core.Tools;
using NUnit.Framework;

namespace Tests
{
    public class RadioIsotopeGeneratorTests
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

    public class RadioisotopeSimulator
    {
        public int StepCount { get; }

        public RadioisotopeSimulator(string input)
        {
            var floors = ParseFloors(input);
            var x = 0;
        }

        private IList<Floor> ParseFloors(string input)
        {
            var strFloors = PuzzleInputReader.Read(input);
            return strFloors.Select(ParseFloor).ToList();
        }

        private Floor ParseFloor(string s)
        {
            s = s.Replace(" microchip", "-microchip").Replace(" generator", "-generator").Replace(",", "").Replace(".", "");
            var parts = s.Split(" ");
            var microchips = parts
                .Where(o => o.EndsWith("microchip"))
                .Select(o => o.Split('-').First())
                .ToList();
            var generators = parts
                .Where(o => o.EndsWith("generator"))
                .Select(o => o.Split('-').First())
                .ToList();
            return new Floor(microchips, generators);
        }
    }

    public class Floor
    {
        public IList<string> Microship { get; }
        public IList<string> Generators { get; }

        public Floor(IList<string> microship, IList<string> generators)
        {
            Microship = microship;
            Generators = generators;
        }
    }
}