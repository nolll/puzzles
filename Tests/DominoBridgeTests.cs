using ConsoleApp.Puzzles.Year2017.Day24;
using NUnit.Framework;

namespace Tests
{
    public class DominoBridgeTests
    {
        private const string Input = @"
0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";

        [Test]
        public void FindsStrongestBridge()
        {
            var builder = new BridgeBuilder(Input, false);
            var bridge = builder.Build();

            Assert.That(bridge.Strength, Is.EqualTo(31));
        }
    
        [Test]
        public void FindsLongestBridge()
        {
            var builder = new BridgeBuilder(Input, true);
            var bridge = builder.Build();

            Assert.That(bridge.Strength, Is.EqualTo(19));
        }
    }
}