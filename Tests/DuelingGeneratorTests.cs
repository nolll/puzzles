using Core.DuelingGenerators;
using NUnit.Framework;

namespace Tests
{
    public class DuelingGeneratorTests
    {
        [Test]
        public void MatchCountIsOne()
        {
            var duel = new GeneratorDuel(65, 8921);
            duel.Run(5);

            Assert.That(duel.FinalCount, Is.EqualTo(1));
        }
    }
}