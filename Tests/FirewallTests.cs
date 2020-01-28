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