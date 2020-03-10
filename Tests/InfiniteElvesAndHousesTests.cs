using Core.InfiniteElvesAndHouses;
using NUnit.Framework;

namespace Tests
{
    public class InfiniteElvesAndHousesTests
    {
        [Test]
        public void FirstHouseToGet150Presents()
        {
            const int input = 150;

            var presentDelivery = new PresentDelivery();
            var house = presentDelivery.Deliver(input);

            Assert.That(house, Is.EqualTo(8));
        }
    }
}