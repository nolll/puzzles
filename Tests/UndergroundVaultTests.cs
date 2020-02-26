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

        [Test]
        public void ShortestPathIsFound3()
        {
            const string input = @"
########################
#...............b.C.D.f#
#.######################
#.....@.a.B.c.d.A.e.F.g#
########################";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(132));
        }

        [Test]
        public void ShortestPathIsFound4()
        {
            const string input = @"
#################
#i.G..c...e..H.p#
########.########
#j.A..b...f..D.o#
########@########
#k.E..a...g..B.n#
########.########
#l.F..d...h..C.m#
#################";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(136));
        }

        [Test]
        public void ShortestPathIsFound5()
        {
            const string input = @"
########################
#@..............ac.GI.b#
###d#e#f################
###A#B#C################
###g#h#i################
########################";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(81));
        }
    }
}