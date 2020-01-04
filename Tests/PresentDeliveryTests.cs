using Core;
using Core.PresentDelivery;
using NUnit.Framework;

namespace Tests
{
    public class PresentDeliveryTests
    {
        [TestCase(">", 2)]
        [TestCase("^>v<", 4)]
        [TestCase("^v^v^v^v^v", 2)]
        public void DeliversToCorrectNumberOfHouses(string input, int expected)
        {
            var grid = new DeliveryGrid();
            grid.Deliver(input);

            Assert.That(grid.DeliveryCount, Is.EqualTo(expected));
        }
    }
}