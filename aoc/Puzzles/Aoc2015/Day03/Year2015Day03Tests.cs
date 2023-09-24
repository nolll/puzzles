using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2015.Day03;

public class Year2015Day03Tests
{
    [TestCase(">", 2)]
    [TestCase("^>v<", 4)]
    [TestCase("^v^v^v^v^v", 2)]
    public void DeliversToCorrectNumberOfHouses_Santa(string input, int expected)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySanta(input);

        Assert.That(grid.SantaDeliveryCount, Is.EqualTo(expected));
    }

    [TestCase("^v", 3)]
    [TestCase("^>v<", 3)]
    [TestCase("^v^v^v^v^v", 11)]
    public void DeliversToCorrectNumberOfHouses_SantaAndRobot(string input, int expected)
    {
        var grid = new DeliveryGrid();
        grid.DeliverBySantaAndRobot(input);

        Assert.That(grid.SantaDeliveryCount, Is.EqualTo(expected));
    }
}