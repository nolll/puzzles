using Core.UndergroundVault;
using NUnit.Framework;

namespace Tests
{
    public class UndergroundVaultTests
    {
        [Test]
        public void ShortestPathIsFound1()
        {
            const string input = @"
#########
#b.A.@.a#
#########";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(8));
        }
        
        [Test]
        public void ShortestPathIsFound2()
        {
            const string input = @"
########################
#f.D.E.e.C.b.A.@.a.B.c.#
######################.#
#d.....................#
########################";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(86));
        }
    }
}