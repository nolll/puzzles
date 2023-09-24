using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Day01;

public class Year2019Day01Tests
{
    [TestCase(14, 2)]
    [TestCase(1969, 654)]
    [TestCase(100756, 33583)]
    public void RequiredFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        Assert.That(module.MassFuel, Is.EqualTo(expectedFuel));
    }

    [TestCase(14, 2)]
    [TestCase(1969, 966)]
    [TestCase(100756, 50346)]
    public void TotalFuelIsCorrect(int mass, int expectedFuel)
    {
        var module = new Module(mass);
        Assert.That(module.TotalFuel, Is.EqualTo(expectedFuel));
    }
}