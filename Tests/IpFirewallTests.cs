using Core.IpFirewall;
using NUnit.Framework;

namespace Tests
{
    public class IpFirewallTests
    {
        [Test]
        public void FindsUnblockedIps()
        {
            const string input = @"
5-8
0-2
4-7";

            var rules = new FirewallRules(input);
            var lowestIp = rules.GetLowestUnblockedIp();

            Assert.That(lowestIp, Is.EqualTo(3));
        }

        [Test]
        public void AllowedIpCountIsCorrect()
        {
            const string input = @"
5-8
0-2
4-7";

            var rules = new FirewallRules(input);
            var lowestIp = rules.GetAllowedIpCount(9);

            Assert.That(lowestIp, Is.EqualTo(2));
        }
    }
}