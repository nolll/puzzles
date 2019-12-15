using Core.MakeFuel;
using NUnit.Framework;

namespace Tests
{
    public class FuelTests
    {
        [Test]
        public void Parser()
        {
            const string input = @"
10 ORE => 10 A
1 ORE => 1 B
7 A, 1 B => 1 C
7 A, 1 C => 1 D
7 A, 1 D => 1 E
7 A, 1 E => 1 FUEL";

            var reactor = new NanoReactor(input);
            var result = reactor.GetRequiredOre();

            Assert.That(result, Is.EqualTo(31));
        }
    }
}