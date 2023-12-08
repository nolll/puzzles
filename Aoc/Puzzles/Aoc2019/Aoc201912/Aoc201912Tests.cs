using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201912;

public class Aoc201912Tests
{
    [Test]
    public void After1Step()
    {
        const string map = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.Run(1);

        moonTracker.Moons[0].X.Should().Be(2);
        moonTracker.Moons[0].Y.Should().Be(-1);
        moonTracker.Moons[0].Z.Should().Be(1);

        moonTracker.Moons[1].X.Should().Be(3);
        moonTracker.Moons[1].Y.Should().Be(-7);
        moonTracker.Moons[1].Z.Should().Be(-4);

        moonTracker.Moons[2].X.Should().Be(1);
        moonTracker.Moons[2].Y.Should().Be(-7);
        moonTracker.Moons[2].Z.Should().Be(5);

        moonTracker.Moons[3].X.Should().Be(2);
        moonTracker.Moons[3].Y.Should().Be(2);
        moonTracker.Moons[3].Z.Should().Be(0);
    }

    [Test]
    public void After5Steps()
    {
        const string map = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.Run(5);

        moonTracker.Moons[0].X.Should().Be(-1);
        moonTracker.Moons[0].Y.Should().Be(-9);
        moonTracker.Moons[0].Z.Should().Be(2);

        moonTracker.Moons[1].X.Should().Be(4);
        moonTracker.Moons[1].Y.Should().Be(1);
        moonTracker.Moons[1].Z.Should().Be(5);

        moonTracker.Moons[2].X.Should().Be(2);
        moonTracker.Moons[2].Y.Should().Be(2);
        moonTracker.Moons[2].Z.Should().Be(-4);

        moonTracker.Moons[3].X.Should().Be(3);
        moonTracker.Moons[3].Y.Should().Be(-7);
        moonTracker.Moons[3].Z.Should().Be(-1);
    }

    [Test]
    public void After2770Steps()
    {
        const string map = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.Run(2770);

        moonTracker.Moons[0].X.Should().Be(2);
        moonTracker.Moons[0].Y.Should().Be(-1);
        moonTracker.Moons[0].Z.Should().Be(1);

        moonTracker.Moons[1].X.Should().Be(3);
        moonTracker.Moons[1].Y.Should().Be(-7);
        moonTracker.Moons[1].Z.Should().Be(-4);

        moonTracker.Moons[2].X.Should().Be(1);
        moonTracker.Moons[2].Y.Should().Be(-7);
        moonTracker.Moons[2].Z.Should().Be(5);

        moonTracker.Moons[3].X.Should().Be(2);
        moonTracker.Moons[3].Y.Should().Be(2);
        moonTracker.Moons[3].Z.Should().Be(0);
    }

    [Test]
    public void TotalEnergyAfter10Steps()
    {
        const string map = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.Run(10);

        moonTracker.TotalEnergy.Should().Be(179);
    }

    [Test]
    public void TotalEnergyAfter100Steps()
    {
        const string map = """
                           <x=-8, y=-10, z=0>
                           <x=5, y=5, z=10>
                           <x=2, y=-7, z=3>
                           <x=9, y=-8, z=-3>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.Run(100);

        moonTracker.TotalEnergy.Should().Be(1940);
        moonTracker.Moons[0].X.Should().Be(8);
        moonTracker.Moons[0].Y.Should().Be(-12);
        moonTracker.Moons[0].Z.Should().Be(-9);
        moonTracker.Moons[1].X.Should().Be(13);
        moonTracker.Moons[1].Y.Should().Be(16);
        moonTracker.Moons[1].Z.Should().Be(-3);
        moonTracker.Moons[2].X.Should().Be(-29);
        moonTracker.Moons[2].Y.Should().Be(-11);
        moonTracker.Moons[2].Z.Should().Be(-1);
        moonTracker.Moons[3].X.Should().Be(16);
        moonTracker.Moons[3].Y.Should().Be(-13);
        moonTracker.Moons[3].Z.Should().Be(23);
        moonTracker.Moons[0].Vx.Should().Be(-7);
        moonTracker.Moons[0].Vy.Should().Be(3);
        moonTracker.Moons[0].Vz.Should().Be(0);
        moonTracker.Moons[1].Vx.Should().Be(3);
        moonTracker.Moons[1].Vy.Should().Be(-11);
        moonTracker.Moons[1].Vz.Should().Be(-5);
        moonTracker.Moons[2].Vx.Should().Be(-3);
        moonTracker.Moons[2].Vy.Should().Be(7);
        moonTracker.Moons[2].Vz.Should().Be(4);
        moonTracker.Moons[3].Vx.Should().Be(7);
        moonTracker.Moons[3].Vy.Should().Be(1);
        moonTracker.Moons[3].Vz.Should().Be(1);
    }

    [Test]
    public void CycleLengthIs2772()
    {
        const string map = """
                           <x=-1, y=0, z=2>
                           <x=2, y=-10, z=-7>
                           <x=4, y=-8, z=8>
                           <x=3, y=5, z=-1>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.RunUntilRepeat();

        moonTracker.Iterations.Should().Be(2772);
    }

    [Test]
    public void CycleLengthIs4686774924()
    {
        const string map = """
                           <x=-8, y=-10, z=0>
                           <x=5, y=5, z=10>
                           <x=2, y=-7, z=3>
                           <x=9, y=-8, z=-3>
                           """;

        var moonTracker = new MoonTracker(map);
        moonTracker.RunUntilRepeat();

        moonTracker.Iterations.Should().Be(4686774924);
    }
}