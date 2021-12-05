using ConsoleApp.Puzzles.Year2015.Puzzles.Day03;
using NUnit.Framework;

namespace Tests
{
    public class PresentDeliveryTests
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
}