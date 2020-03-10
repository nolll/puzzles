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
            var lowestIp = rules.GetLowestUnblockedIp(9);

            Assert.That(lowestIp, Is.EqualTo(3));
        }
    }
}