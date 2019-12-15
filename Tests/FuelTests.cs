using Core.MakeFuel;
using NUnit.Framework;

namespace Tests
{
    public class FuelTests
    {
        [Test]
        public void NumberOfOresIs31()
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

        [Test]
        public void NumberOfOresIs165()
        {
            const string input = @"
9 ORE => 2 A
8 ORE => 3 B
7 ORE => 5 C
3 A, 4 B => 1 AB
5 B, 7 C => 1 BC
4 C, 1 A => 1 CA
2 AB, 3 BC, 4 CA => 1 FUEL";

            var reactor = new NanoReactor(input);
            var result = reactor.GetRequiredOre();

            Assert.That(result, Is.EqualTo(165));
        }

    }


}