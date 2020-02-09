using Core.DuelingGenerators;
using NUnit.Framework;

namespace Tests
{
    public class DuelingGeneratorTests
    {
        [Test]
        public void Part1_MatchCountIsOne()
        {
            var duel = new GeneratorDuel(65, 8921);
            duel.Run(5);

            Assert.That(duel.FinalCount, Is.EqualTo(1));
        }

        [Test]
        public void Part2_Finds309PairsIn5MillionIterators()
        {
            var duel = new GeneratorDuel(65, 8921);
            duel.Run2(5_000_000);

            Assert.That(duel.FinalCount, Is.EqualTo(309));
        }
    }
}