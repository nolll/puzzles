using Core.DominoBridge;
using NUnit.Framework;

namespace Tests
{
    public class DominoBridgeTests
    {
        [Test]
        public void FindsStrongestBridge()
        {
            const string input = @"
0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

            var builder = new BridgeBuilder(input);
            var bridgeStrength = builder.Build();

            Assert.That(bridgeStrength, Is.EqualTo(31));
        }
    }
}