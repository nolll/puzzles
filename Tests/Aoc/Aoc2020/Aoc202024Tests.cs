using Pzl.Aoc.Puzzles.Aoc2020;
using Pzl.Tools.Grids.Grids2d;

namespace Tests.Aoc.Aoc2020;

public class Aoc202024Tests : PuzzleTest<Aoc202024>
{
    [Theory]
    [InlineData("esew")]
    [InlineData("nwwswee")]
    public void OneTileIsBlackAfterArrange(string input) => Sut.Part1(input).Should().Be(1);

    [Fact]
    public void FiveTilesAreBlackAfterArrange() => Sut.Part1(Input).Should().Be(10);

    [Fact]
    public void BlackTilesCorrectAfterEachRun()
    {
        var cache = new Dictionary<string, List<Coord>>();
        var grid = Sut.Arrange(Input);
        
        grid = Sut.Modify(grid, 1, cache); // 1
        Sut.BlackTileCount(grid).Should().Be(15);
        
        grid = Sut.Modify(grid, 1, cache); // 2
        Sut.BlackTileCount(grid).Should().Be(12);

        grid = Sut.Modify(grid, 1, cache); // 3
        Sut.BlackTileCount(grid).Should().Be(25);

        grid = Sut.Modify(grid, 1, cache); // 4
        Sut.BlackTileCount(grid).Should().Be(14);

        grid = Sut.Modify(grid, 1, cache); // 5
        Sut.BlackTileCount(grid).Should().Be(23);

        grid = Sut.Modify(grid, 1, cache); // 6
        Sut.BlackTileCount(grid).Should().Be(28);

        grid = Sut.Modify(grid, 1, cache); // 7
        Sut.BlackTileCount(grid).Should().Be(41);

        grid = Sut.Modify(grid, 1, cache); // 8
        Sut.BlackTileCount(grid).Should().Be(37);

        grid = Sut.Modify(grid, 1, cache); // 9
        Sut.BlackTileCount(grid).Should().Be(49);

        grid = Sut.Modify(grid, 1, cache); // 10
        Sut.BlackTileCount(grid).Should().Be(37);

        grid = Sut.Modify(grid, 10, cache); // 20
        Sut.BlackTileCount(grid).Should().Be(132);

        grid = Sut.Modify(grid, 10, cache); // 30
        Sut.BlackTileCount(grid).Should().Be(259);

        grid = Sut.Modify(grid, 10, cache); // 40
        Sut.BlackTileCount(grid).Should().Be(406);

        grid = Sut.Modify(grid, 10, cache); // 50
        Sut.BlackTileCount(grid).Should().Be(566);

        grid = Sut.Modify(grid, 10, cache); // 60
        Sut.BlackTileCount(grid).Should().Be(788);

        grid = Sut.Modify(grid, 10, cache); // 70
        Sut.BlackTileCount(grid).Should().Be(1106);

        grid = Sut.Modify(grid, 10, cache); // 80
        Sut.BlackTileCount(grid).Should().Be(1373);

        grid = Sut.Modify(grid, 10, cache); // 90
        Sut.BlackTileCount(grid).Should().Be(1844);

        grid = Sut.Modify(grid, 10, cache); // 100
        Sut.BlackTileCount(grid).Should().Be(2208);
    }

    private const string Input = """
                                 sesenwnenenewseeswwswswwnenewsewsw
                                 neeenesenwnwwswnenewnwwsewnenwseswesw
                                 seswneswswsenwwnwse
                                 nwnwneseeswswnenewneswwnewseswneseene
                                 swweswneswnenwsewnwneneseenw
                                 eesenwseswswnenwswnwnwsewwnwsene
                                 sewnenenenesenwsewnenwwwse
                                 wenwwweseeeweswwwnwwe
                                 wsweesenenewnwwnwsenewsenwwsesesenwne
                                 neeswseenwwswnwswswnw
                                 nenwswwsewswnenenewsenwsenwnesesenew
                                 enewnwewneswsewnwswenweswnenwsenwsw
                                 sweneswneswneneenwnewenewwneswswnese
                                 swwesenesewenwneswnwwneseswwne
                                 enesenwswwswneneswsenwnewswseenwsese
                                 wnwnesenesenenwwnenwsewesewsesesew
                                 nenewswnwewswnenesenwnesewesw
                                 eneswnwswnwsenenwnwnwwseeswneewsenese
                                 neswnwewnwnwseenwseesewsenwsweewe
                                 wseweeenwnesenwwwswnew
                                 """;
}