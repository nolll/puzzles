using Pzl.Aoc.Puzzles.Aoc2019;

namespace Tests.Aoc.Aoc2019;

public class Aoc201910Tests : PuzzleTest<Aoc201910>
{
    [Fact]
    public void Asteroid_3_4_DetectsTheMostAsteroids()
    {
        const string map = """
                           .#..#
                           .....
                           #####
                           ....#
                           ...##
                           """;

        var (asteroid, rayCount) = Sut.Detect(map);

        asteroid.X.Should().Be(3);
        asteroid.Y.Should().Be(4);
        rayCount.Should().Be(8);
    }

    [Fact]
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
        
        var (asteroid, rayCount) = Sut.Detect(map);

        asteroid.X.Should().Be(5);
        asteroid.Y.Should().Be(8);
        rayCount.Should().Be(33);
    }

    [Fact]
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
        
        var (asteroid, rayCount) = Sut.Detect(map);

        asteroid.X.Should().Be(1);
        asteroid.Y.Should().Be(2);
        rayCount.Should().Be(35);
    }

    [Fact]
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
        
        var (asteroid, rayCount) = Sut.Detect(map);

        asteroid.X.Should().Be(6);
        asteroid.Y.Should().Be(3);
        rayCount.Should().Be(41);
    }

    [Fact]
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
        
        var (asteroid, rayCount) = Sut.Detect(map);

        asteroid.X.Should().Be(11);
        asteroid.Y.Should().Be(13);
        rayCount.Should().Be(210);
    }

    [Fact]
    public void MapForVaporizeResultsInTheCorrectAsteroid()
    {
        const string map = """
                           .#....#####...#..
                           ##...##.#####..##
                           ##...#...#.#####.
                           ..#.....X...###..
                           ..#.#.....#....##
                           """;
        
        var (asteroid, _) = Sut.Detect(map);

        asteroid.X.Should().Be(8);
        asteroid.Y.Should().Be(3);
    }

    [Fact]
    public void VaporizeOrderIsCorrect()
    {
        const string map = """
                           .A....BCDEF...G..
                           HI...JK.LMNOP..QR
                           ST...U...V.WXYZ1.
                           ..2.....#...345..
                           ..6.7.....8....90
                           """;

        var result = Sut.Vaporize(map);

        result[0].Name.Should().Be('L');
        result[1].Name.Should().Be('E');
        result[2].Name.Should().Be('M');
        result[3].Name.Should().Be('F');
        result[4].Name.Should().Be('V');
        result[5].Name.Should().Be('O');
        result[6].Name.Should().Be('P');
        result[7].Name.Should().Be('W');
        result[8].Name.Should().Be('Q');
    }
}