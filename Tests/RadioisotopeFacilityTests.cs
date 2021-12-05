using System.Collections.Generic;
using ConsoleApp.Puzzles.Year2016.Puzzles.Day11;
using NUnit.Framework;

namespace Tests
{
    public class RadioisotopeFacilityTests
    {
        [Test]
        public void IdIsCorrect()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("lithium"),
                        new Microchip("hydrogen"),
                        new Generator("hydrogen")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Generator("lithium")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>())
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.Id, Is.EqualTo("0:HG-HM-LM||LG|"));
        }

        [Test]
        public void AnonymizedIdIsCorrect()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("lithium"),
                        new Microchip("hydrogen"),
                        new Generator("hydrogen")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Generator("lithium")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>())
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.AnonymizedId, Is.EqualTo("0:1X-1Y-2Y||2X|"));
        }

        [Test]
        public void FacilityIsValid()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>())
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.IsValid, Is.True);
        }

        [Test]
        public void FacilityIsInvalid()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("hydrogen"),
                        new Generator("lithium")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>())
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.IsValid, Is.False);
        }

        [Test]
        public void IsFinished()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("hydrogen"),
                        new Generator("lithium")
                    })
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.IsDone, Is.True);
        }

        [Test]
        public void IsNotFinished()
        {
            var floors = new List<RadioisotopeFloor>
            {
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("hydrogen"),
                        new Generator("lithium")
                    }),
                new RadioisotopeFloor(new List<RadioisotopeItem>()),
                new RadioisotopeFloor(
                    new List<RadioisotopeItem>
                    {
                        new Microchip("hydrogen"),
                        new Generator("lithium")
                    })
            };

            var facility = new RadioisotopeFacility(floors, 0);
            Assert.That(facility.IsDone, Is.False);
        }
    }
}