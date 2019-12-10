using Core.Asteroids;
using NUnit.Framework;

namespace Tests
{
    public class AsteroidTests
    {
        [Test]
        public void Asteroid_3_4_DetectsTheMostAsteroids()
        {
            const string map = @"
.#..#
.....
#####
....#
...##";

            var detector = new AsteroidDetector();
            var result = detector.Detect(map);

            Assert.That(result.BestAsteroid.X, Is.EqualTo(3));
            Assert.That(result.BestAsteroid.Y, Is.EqualTo(4));
            Assert.That(result.RayCount, Is.EqualTo(8));
        }

        [Test]
        public void Asteroid_5_8_DetectsTheMostAsteroids()
        {
            const string map = @"
......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####";

            var detector = new AsteroidDetector();
            var result = detector.Detect(map);

            Assert.That(result.BestAsteroid.X, Is.EqualTo(5));
            Assert.That(result.BestAsteroid.Y, Is.EqualTo(8));
            Assert.That(result.RayCount, Is.EqualTo(33));
        }

        [Test]
        public void Asteroid_1_2_DetectsTheMostAsteroids()
        {
            const string map = @"
#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.";

            var detector = new AsteroidDetector();
            var result = detector.Detect(map);

            Assert.That(result.BestAsteroid.X, Is.EqualTo(1));
            Assert.That(result.BestAsteroid.Y, Is.EqualTo(2));
            Assert.That(result.RayCount, Is.EqualTo(35));
        }

        [Test]
        public void Asteroid_6_3_DetectsTheMostAsteroids()
        {
            const string map = @"
.#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..";

            var detector = new AsteroidDetector();
            var result = detector.Detect(map);

            Assert.That(result.BestAsteroid.X, Is.EqualTo(6));
            Assert.That(result.BestAsteroid.Y, Is.EqualTo(3));
            Assert.That(result.RayCount, Is.EqualTo(41));
        }

        [Test]
        public void Asteroid_11_13_DetectsTheMostAsteroids()
        {
            const string map = @"
.#..##.###...#######
##.############..##.
.#.######.########.#
.###.#######.####.#.
#####.##.#.##.###.##
..#####..#.#########
####################
#.####....###.#.#.##
##.#################
#####.##.###..####..
..######..##.#######
####.##.####...##..#
.#####..#.######.###
##...#.##########...
#.##########.#######
.####.#.###.###.#.##
....##.##.###..#####
.#.#.###########.###
#.#.#.#####.####.###
###.##.####.##.#..##";

            var detector = new AsteroidDetector();
            var result = detector.Detect(map);

            Assert.That(result.BestAsteroid.X, Is.EqualTo(11));
            Assert.That(result.BestAsteroid.Y, Is.EqualTo(13));
            Assert.That(result.RayCount, Is.EqualTo(210));
        }
    }
}