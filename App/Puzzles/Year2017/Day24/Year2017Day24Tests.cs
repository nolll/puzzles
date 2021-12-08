using NUnit.Framework;

namespace App.Puzzles.Year2017.Day24
{
    public class Year2017Day24Tests
    {
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

        private const string Input = @"
0/2
2/2
2/3
3/4
3/5
0/1
10/1
9/10";
    }
}