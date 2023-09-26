using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2019.Aoc201910;

public class Aoc201910Tests
{
    [Test]
    public void Asteroid_3_4_DetectsTheMostAsteroids()
    {
        const string map = """
.#..#
.....
#####
....#
...##
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(3));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(4));
        Assert.That(result.RayCount, Is.EqualTo(8));
    }

    [Test]
    public void Asteroid_5_8_DetectsTheMostAsteroids()
    {
        const string map = """
......#.#.
#..#.#....
..#######.
.#.#.###..
.#..#.....
..#....#.#
#..#....#.
.##.#..###
##...#..#.
.#....####
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(5));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(8));
        Assert.That(result.RayCount, Is.EqualTo(33));
    }

    [Test]
    public void Asteroid_1_2_DetectsTheMostAsteroids()
    {
        const string map = """
#.#...#.#.
.###....#.
.#....#...
##.#.#.#.#
....#.#.#.
.##..###.#
..#...##..
..##....##
......#...
.####.###.
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(1));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(2));
        Assert.That(result.RayCount, Is.EqualTo(35));
    }

    [Test]
    public void Asteroid_6_3_DetectsTheMostAsteroids()
    {
        const string map = """
.#..#..###
####.###.#
....###.#.
..###.##.#
##.##.#.#.
....###..#
..#.#..#.#
#..#.#.###
.##...##.#
.....#.#..
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(6));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(3));
        Assert.That(result.RayCount, Is.EqualTo(41));
    }

    [Test]
    public void Asteroid_11_13_DetectsTheMostAsteroids()
    {
        const string map = """
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
###.##.####.##.#..##
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(11));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(13));
        Assert.That(result.RayCount, Is.EqualTo(210));
    }

    [Test]
    public void MapForVaporizeResultsInTheCorrectAsteroid()
    {
        const string map = """
.#....#####...#..
##...##.#####..##
##...#...#.#####.
..#.....X...###..
..#.#.....#....##
""";

        var detector = new AsteroidDetector();
        var result = detector.Detect(map.Trim());

        Assert.That(result.BestAsteroid.X, Is.EqualTo(8));
        Assert.That(result.BestAsteroid.Y, Is.EqualTo(3));
    }

    [Test]
    public void VaporizeOrderIsCorrect()
    {
        const string map = """
.A....BCDEF...G..
HI...JK.LMNOP..QR
ST...U...V.WXYZ1.
..2.....#...345..
..6.7.....8....90
""";

        var detector = new AsteroidVaporizer();
        var result = detector.Vaporize(map.Trim());

        Assert.That(result.DestroyedAsteroids[0].Name, Is.EqualTo('L'));
        Assert.That(result.DestroyedAsteroids[1].Name, Is.EqualTo('E'));
        Assert.That(result.DestroyedAsteroids[2].Name, Is.EqualTo('M'));
        Assert.That(result.DestroyedAsteroids[3].Name, Is.EqualTo('F'));
        Assert.That(result.DestroyedAsteroids[4].Name, Is.EqualTo('V'));
        Assert.That(result.DestroyedAsteroids[5].Name, Is.EqualTo('O'));
        Assert.That(result.DestroyedAsteroids[6].Name, Is.EqualTo('P'));
        Assert.That(result.DestroyedAsteroids[7].Name, Is.EqualTo('W'));
        Assert.That(result.DestroyedAsteroids[8].Name, Is.EqualTo('Q'));
    }
}