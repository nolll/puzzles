using System.Linq;
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
            var house = presentDelivery.Deliver1(input);

            Assert.That(house, Is.EqualTo(8));
        }

        [Test]
        public void FindIntFactors8()
        {
            var delivery = new PresentDelivery();
            var result = delivery.FindIntFactors(8).ToList();

            Assert.That(result.Count, Is.EqualTo(4));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(4));
            Assert.That(result[3], Is.EqualTo(8));
        }

        [Test]
        public void FindIntFactors81()
        {
            var delivery = new PresentDelivery();
            var result = delivery.FindIntFactors(81).ToList();

            Assert.That(result.Count, Is.EqualTo(5));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(3));
            Assert.That(result[2], Is.EqualTo(9));
            Assert.That(result[3], Is.EqualTo(27));
            Assert.That(result[4], Is.EqualTo(81));
        }

        [Test]
        public void FindIntFactors2354()
        {
            var delivery = new PresentDelivery();
            var result = delivery.FindIntFactors(2354).ToList();

            Assert.That(result.Count, Is.EqualTo(8));
            Assert.That(result[0], Is.EqualTo(1));
            Assert.That(result[1], Is.EqualTo(2));
            Assert.That(result[2], Is.EqualTo(11));
            Assert.That(result[3], Is.EqualTo(22));
            Assert.That(result[4], Is.EqualTo(107));
            Assert.That(result[5], Is.EqualTo(214));
            Assert.That(result[6], Is.EqualTo(1177));
            Assert.That(result[7], Is.EqualTo(2354));
        }
    }
}