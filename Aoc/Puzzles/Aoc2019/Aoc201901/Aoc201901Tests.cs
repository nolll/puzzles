using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.Aoc.Puzzles.Aoc2019.Aoc201901;

public class Aoc201901Tests
{
    [TestCase(14, 2)]
    [TestCase(1969, 654)]
    [TestCase(100756, 33583)]
    public void RequiredFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        module.MassFuel.Should().Be(expectedFuel);
    }

    [TestCase(14, 2)]
    [TestCase(1969, 966)]
    [TestCase(100756, 50346)]
    public void TotalFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        module.TotalFuel.Should().Be(expectedFuel);
    }
}