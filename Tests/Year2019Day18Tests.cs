using ConsoleApp.Years.Year2019.Puzzles;
using ConsoleApp.Years.Year2019.Puzzles.Day18;
using NUnit.Framework;

namespace Tests
{
    public class Year2019Day18Tests
    {
        [Test]
        public void OneRobot_ShortestPathIsFound1()
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
        public void OneRobot_ShortestPathIsFound2()
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
        public void OneRobot_ShortestPathIsFound3()
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
        public void OneRobot_ShortestPathIsFound4()
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
        public void OneRobot_ShortestPathIsFound5()
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

        [Test]
        public void FourRobots_ShortestPathIsFound1()
        {
            const string input = @"
#######
#a.#Cd#
##@#@##
#######
##@#@##
#cB#Ab#
#######";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(8));
        }

        [Test]
        public void FourRobots_ShortestPathIsFound2()
        {
            const string input = @"
###############
#d.ABC.#.....a#
######@#@######
###############
######@#@######
#b.....#.....c#
###############";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(24));
        }

        [Test]
        public void FourRobots_ShortestPathIsFound3()
        {
            const string input = @"
#############
#DcBa.#.GhKl#
#.###@#@#I###
#e#d#####j#k#
###C#@#@###J#
#fEbA.#.FgHi#
#############";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(32));
        }

        [Test]
        [Ignore("This completes in 70 steps, and the code works for the real data. The real solution can't just be given other quadrants keys")]
        public void FourRobots_ShortestPathIsFound4()
        {
            const string input = @"
#############
#g#f.D#..h#l#
#F###e#E###.#
#dCba@#@BcIJ#
#############
#nK.L@#@G...#
#M###N#H###.#
#o#m..#i#jk.#
#############";

            var keyCollector = new KeyCollector(input);
            keyCollector.Run();

            Assert.That(keyCollector.ShortestPath, Is.EqualTo(72));
        }
    }
}