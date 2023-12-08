using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2019.Aoc201910;

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

        result.BestAsteroid.X.Should().Be(3);
        result.BestAsteroid.Y.Should().Be(4);
        result.RayCount.Should().Be(8);
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

        result.BestAsteroid.X.Should().Be(5);
        result.BestAsteroid.Y.Should().Be(8);
        result.RayCount.Should().Be(33);
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

        result.BestAsteroid.X.Should().Be(1);
        result.BestAsteroid.Y.Should().Be(2);
        result.RayCount.Should().Be(35);
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

        result.BestAsteroid.X.Should().Be(6);
        result.BestAsteroid.Y.Should().Be(3);
        result.RayCount.Should().Be(41);
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

        result.BestAsteroid.X.Should().Be(11);
        result.BestAsteroid.Y.Should().Be(13);
        result.RayCount.Should().Be(210);
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

        result.BestAsteroid.X.Should().Be(8);
        result.BestAsteroid.Y.Should().Be(3);
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

        result.DestroyedAsteroids[0].Name.Should().Be('L');
        result.DestroyedAsteroids[1].Name.Should().Be('E');
        result.DestroyedAsteroids[2].Name.Should().Be('M');
        result.DestroyedAsteroids[3].Name.Should().Be('F');
        result.DestroyedAsteroids[4].Name.Should().Be('V');
        result.DestroyedAsteroids[5].Name.Should().Be('O');
        result.DestroyedAsteroids[6].Name.Should().Be('P');
        result.DestroyedAsteroids[7].Name.Should().Be('W');
        result.DestroyedAsteroids[8].Name.Should().Be('Q');
    }
}