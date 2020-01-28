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

            var scanner = new PackerScanner(input);

            Assert.That(scanner.Severity, Is.EqualTo(24));
        }
    }
}