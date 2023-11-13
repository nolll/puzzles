using FluentAssertions;
using NUnit.Framework;

namespace Puzzles.aoc.Puzzles.Aoc2021.Aoc202107;

public class Aoc202107Tests
{
    [Test]
    public void Part1()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(Input, false);

        result.Should().Be(37);
    }

    [Test]
    public void Part2()
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetFuel1(Input, true);

        result.Should().Be(168);
    }

    [TestCase(16, 5, 11)]
    [TestCase(1, 5, 4)]
    [TestCase(2, 2, 0)]
    public void CostPart1(int a, int b, int expected)
    {
        var result = CrabSubmarines.GetCost(a, b);

        result.Should().Be(expected);
    }

    [TestCase(16, 5, 66)]
    [TestCase(1, 5, 10)]
    [TestCase(0, 5, 15)]
    [TestCase(4, 5, 1)]
    [TestCase(7, 5, 3)]
    [TestCase(2, 5, 6)]
    [TestCase(14, 5, 45)]
    [TestCase(5, 16, 66)]
    [TestCase(5, 5, 0)]
    public void CostPart2(int a, int b, int expected)
    {
        var crabSubmarines = new CrabSubmarines();
        var result = crabSubmarines.GetCrabEnginerringCost(a, b);

        result.Should().Be(expected);
    }

    private const string Input = "16,1,2,0,4,2,7,1,2,14";
}