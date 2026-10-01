using Pzl.Aoc.Puzzles.Aoc2016;

namespace Tests.Aoc.Aoc2016;

public class Aoc201611Tests : PuzzleTest<Aoc201611>
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

        Sut.Solve(input).Should().Be(11);
    }

    [Fact]
    public void IdIsCorrect1()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Microchip("lithium"),
            new Aoc201611.Microchip("hydrogen"),
            new Aoc201611.Generator("hydrogen")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.Id.Should().Be("HGHMLM");
    }

    [Fact]
    public void EmptyFloorIsValid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>();

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyGeneratorsIsValid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Generator("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void OnlyMicrochipsIsValid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Microchip("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void MatchingItemsIsValid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Microchip("lithium"),
            new Aoc201611.Generator("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void NonMatchingItemsIsInvalid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Microchip("hydrogen"),
            new Aoc201611.Generator("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ExtraChipIsInvalid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Microchip("hydrogen"),
            new Aoc201611.Microchip("lithium"),
            new Aoc201611.Generator("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeFalse();
    }

    [Fact]
    public void ExtraGeneratorIsValid()
    {
        var items = new List<Aoc201611.RadioisotopeItem>
        {
            new Aoc201611.Generator("hydrogen"),
            new Aoc201611.Microchip("lithium"),
            new Aoc201611.Generator("lithium")
        };

        var floor = new Aoc201611.RadioisotopeFloor(items);
        floor.IsValid.Should().BeTrue();
    }

    [Fact]
    public void IdIsCorrect2()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("lithium"),
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("hydrogen")
                }),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Generator("lithium")
                }),
            new(new List<Aoc201611.RadioisotopeItem>())
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.Id.Should().Be("0:HGHMLM||LG|");
    }

    [Fact]
    public void AnonymizedIdIsCorrect()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("lithium"),
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("hydrogen")
                }),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Generator("lithium")
                }),
            new(new List<Aoc201611.RadioisotopeItem>())
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.AnonymizedId.Should().Be("0:1X1Y2Y||2X|");
    }
    
    [Fact]
    public void FacilityIsValid()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>())
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.IsValid.Should().BeTrue();
    }

    [Fact]
    public void FacilityIsInvalid()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("lithium")
                }),
            new(new List<Aoc201611.RadioisotopeItem>())
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.IsValid.Should().BeFalse();
    }

    [Fact]
    public void IsFinished()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("lithium")
                })
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.IsDone.Should().BeTrue();
    }

    [Fact]
    public void IsNotFinished()
    {
        var floors = new List<Aoc201611.RadioisotopeFloor>
        {
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("lithium")
                }),
            new(new List<Aoc201611.RadioisotopeItem>()),
            new(
                new List<Aoc201611.RadioisotopeItem>
                {
                    new Aoc201611.Microchip("hydrogen"),
                    new Aoc201611.Generator("lithium")
                })
        };

        var facility = new Aoc201611.RadioisotopeFacility(floors, 0, new Aoc201611.IsotopeNameProvider(), new Aoc201611.AnonymousNameProvider());
        facility.IsDone.Should().BeFalse();
    }
}