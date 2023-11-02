using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Aoc201503;

public class Aoc201503Tests
{
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void DeliversToCorrectNumberOfHouses_Santa(string input, int expected)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(input);

        grid.SantaDeliveryCount.Should().Be(expected);
    }

    [TestCase("^v", 3)]
    [TestCase("^>v<", 3)]
    [TestCase("^v^v^v^v^v", 11)]
    public void DeliversToCorrectNumberOfHouses_SantaAndRobot(string input, int expected)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(input);

        grid.SantaDeliveryCount.Should().Be(expected);
    }
}