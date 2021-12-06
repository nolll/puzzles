using System.Collections.Generic;
using Core.Puzzles.Year2016.Day11;
using NUnit.Framework;

namespace Tests
{
    public class RadioisotopeFloorTests
    {
        [Test]
        public void IdIsCorrect()
        {
            var items = new List<RadioisotopeItem>
            {
                new Microchip("lithium"),
                new Microchip("hydrogen"),
                new Generator("hydrogen")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.Id, Is.EqualTo("HG-HM-LM"));
        }

        [Test]
        public void EmptyFloorIsValid()
        {
            var items = new List<RadioisotopeItem>();

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.True);
        }

        [Test]
        public void OnlyGeneratorsIsValid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Generator("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.True);
        }

        [Test]
        public void OnlyMicrochipsIsValid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Microchip("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.True);
        }

        [Test]
        public void MatchingItemsIsValid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Microchip("lithium"),
                new Generator("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.True);
        }

        [Test]
        public void NonMatchingItemsIsInvalid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Microchip("hydrogen"),
                new Generator("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.False);
        }

        [Test]
        public void ExtraChipIsInvalid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Microchip("hydrogen"),
                new Microchip("lithium"),
                new Generator("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.False);
        }

        [Test]
        public void ExtraGeneratorIsValid()
        {
            var items = new List<RadioisotopeItem>
            {
                new Generator("hydrogen"),
                new Microchip("lithium"),
                new Generator("lithium")
            };

            var floor = new RadioisotopeFloor(items);
            Assert.That(floor.IsValid, Is.True);
        }
    }
}