using Core.Firewall;
using NUnit.Framework;

namespace Tests
{
    public class FirewallTests
    {
        [Test]
        public void SeverityIsCorrect()
        {
            const string input = @"
0: 3
1: 2
4: 4
6: 4";

            var scanner = new PacketScanner(input);
            var severity = scanner.GetSeverity();
            Assert.That(severity, Is.EqualTo(24));
        }

        [TestCase(0, 0, 0)]
        [TestCase(1, 0, 0)]
        [TestCase(2, 0, 0)]
        [TestCase(2, 1, 1)]
        [TestCase(2, 2, 0)]
        [TestCase(3, 2, 2)]
        [TestCase(3, 3, 1)]
        [TestCase(3, 4, 0)]
        public void PositionAfterIterations(int range, int iteration, int expected)
        {
            var layer = new FirewallLayer(range);
            var pos = layer.GetPos(iteration);

            Assert.That(pos, Is.EqualTo(expected));
        }

        //[TestCase(0, 0, true)]
        //[TestCase(1, 0, true)]
        //[TestCase(2, 0, true)]
        //[TestCase(2, 1, false)]
        //[TestCase(2, 2, false)]
        //[TestCase(3, 2, false)]
        //public void IsAtZeroIterations(int range, int iteration, bool expected)
        //{
        //    var layer = new FirewallLayer(range);
        //    var isAtZero = layer.IsAtZero(iteration);

        //    Assert.That(isAtZero, Is.EqualTo(expected));
        //}

        [Test]
        public void DelayUntilPassIsCorrect()
        {
            const string input = @"
0: 3
1: 2
4: 4
6: 4";

            var scanner = new PacketScanner(input);
            var delay = scanner.DelayUntilPass();
            Assert.That(delay, Is.EqualTo(10));
        }
    }
}