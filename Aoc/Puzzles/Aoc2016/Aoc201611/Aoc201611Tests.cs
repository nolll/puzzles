namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201611;

public class Aoc201611Tests
{
    [Fact]
    public void StepCountIsCorrect()
    {
        const string input = """
                             The first floor contains a hydrogen-compatible microchip and a lithium-compatible microchip.
                             The second floor contains a hydrogen generator.
                             The third floor contains a lithium generator.
                             The fourth floor contains nothing relevant.
                             """;

        var simulator = new RadioisotopeSimulator(input);

        simulator.StepCount.Should().Be(11);
    }

    [Fact]
    public void IdIsCorrect1()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("lithium"),
            new Microchip("hydrogen"),
            new Generator("hydrogen")
        };

        var floor = new RadioisotopeFloor(items);
        floor.Id.Should().Be("HGHMLM");
    }

    [Fact]
    public void EmptyFloorIsValid()
    {
        var items = new List<RadioisotopeItem>();

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyGeneratorsIsValid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Generator("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyMicrochipsIsValid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void MatchingItemsIsValid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("lithium"),
            new Generator("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void NonMatchingItemsIsInvalid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("hydrogen"),
            new Generator("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ExtraChipIsInvalid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Microchip("hydrogen"),
            new Microchip("lithium"),
            new Generator("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ExtraGeneratorIsValid()
    {
        var items = new List<RadioisotopeItem>
        {
            new Generator("hydrogen"),
            new Microchip("lithium"),
            new Generator("lithium")
        };

        var floor = new RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
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
        facility.Id.Should().Be("0:HGHMLM||LG|");
    }

    [Fact]
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
        facility.AnonymizedId.Should().Be("0:1X1Y2Y||2X|");
    }
    
    [Fact]
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
        facility.IsValid.Should().BeTrue();
    }

    [Fact]
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
        facility.IsValid.Should().BeFalse();
    }

    [Fact]
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
        facility.IsDone.Should().BeTrue();
    }

    [Fact]
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
        facility.IsDone.Should().BeFalse();
    }
}