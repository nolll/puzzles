using System.Collections.Generic;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2016.Day11;

public class Year2016Day11Tests
{
    [Test]
    public void StepCountIsCorrect()
    {
        const string input = """
The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.
The second floor contains a hydrogen generator.
The third floor contains a lithium generator.
The fourth floor contains nothing relevant.
""";

        var simulator = new RadioisotopeSimulator(input);

        Assert.That(simulator.StepCount, Is.EqualTo(11));
    }

    [Test]
    public void IdIsCorrect1()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("lithium"),
            new Microchip("hydrogen"),
            new Generator("hydrogen")
        };

        var floor = new RadioisotopeFloor(items);
        Assert.That(floor.Id, Is.EqualTo("HGHMLM"));
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

    [Test]
    public void IdIsCorrect2()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("lithium"),
                    new Microchip("hydrogen"),
                    new Generator("hydrogen")
                }),
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Generator("lithium")
                }),
            new(new List<RadioisotopeItem>())
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.Id, Is.EqualTo("0:HGHMLM||LG|"));
    }

    [Test]
    public void AnonymizedIdIsCorrect()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("lithium"),
                    new Microchip("hydrogen"),
                    new Generator("hydrogen")
                }),
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Generator("lithium")
                }),
            new(new List<RadioisotopeItem>())
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.AnonymizedId, Is.EqualTo("0:1X1Y2Y||2X|"));
    }
    
    [Test]
    public void FacilityIsValid()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>())
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.IsValid, Is.True);
    }

    [Test]
    public void FacilityIsInvalid()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("hydrogen"),
                    new Generator("lithium")
                }),
            new(new List<RadioisotopeItem>())
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.IsValid, Is.False);
    }

    [Test]
    public void IsFinished()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>()),
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("hydrogen"),
                    new Generator("lithium")
                })
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.IsDone, Is.True);
    }

    [Test]
    public void IsNotFinished()
    {
        var floors = new List<RadioisotopeFloor>
        {
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("hydrogen"),
                    new Generator("lithium")
                }),
            new(new List<RadioisotopeItem>()),
            new(
                new List<RadioisotopeItem>
                {
                    new Microchip("hydrogen"),
                    new Generator("lithium")
                })
        };

        var facility = new RadioisotopeFacility(floors, 0, new IsotopeNameProvider(), new AnonymousNameProvider());
        Assert.That(facility.IsDone, Is.False);
    }
}