using FluentAssertions;
using NUnit.Framework;

namespace Aoc.Puzzles.Aoc2020.Aoc202024;

public class Aoc202024Tests
{
    [TestCase("esew")]
    [TestCase("nwwswee")]
    public void OneTileIsBlackAfterArrange(string input)
    {
        var floor = new HexagonalFloor(input);
        floor.Arrange();
        var result = floor.BlackTileCount;

        result.Should().Be(1);
    }

    [Test]
    public void FiveTilesAreBlackAfterArrange()
    {
        var floor = new HexagonalFloor(Input.Trim());
        floor.Arrange();
        var result = floor.BlackTileCount;

        result.Should().Be(10);
    }

    [Test]
    public void FiveTilesAreBlack()
    {
        var floor = new HexagonalFloor(Input.Trim());
        floor.Arrange();
        var result = floor.BlackTileCount;

        result.Should().Be(10);
    }

    [Test]
    public void BlackTilesCorrectAfterEachRun()
    {
        var floor = new HexagonalFloor(Input.Trim());
        floor.Arrange();

        floor.Modify(1); // 1
        floor.BlackTileCount.Should().Be(15);

        floor.Modify(1); // 2
        floor.BlackTileCount.Should().Be(12);

        floor.Modify(1); // 3
        floor.BlackTileCount.Should().Be(25);

        floor.Modify(1); // 4
        floor.BlackTileCount.Should().Be(14);

        floor.Modify(1); // 5
        floor.BlackTileCount.Should().Be(23);

        floor.Modify(1); // 6
        floor.BlackTileCount.Should().Be(28);

        floor.Modify(1); // 7
        floor.BlackTileCount.Should().Be(41);

        floor.Modify(1); // 8
        floor.BlackTileCount.Should().Be(37);

        floor.Modify(1); // 9
        floor.BlackTileCount.Should().Be(49);

        floor.Modify(1); // 10
        floor.BlackTileCount.Should().Be(37);

        floor.Modify(10); // 20
        floor.BlackTileCount.Should().Be(132);

        floor.Modify(10); // 30
        floor.BlackTileCount.Should().Be(259);

        floor.Modify(10); // 40
        floor.BlackTileCount.Should().Be(406);

        floor.Modify(10); // 50
        floor.BlackTileCount.Should().Be(566);

        floor.Modify(10); // 60
        floor.BlackTileCount.Should().Be(788);

        floor.Modify(10); // 70
        floor.BlackTileCount.Should().Be(1106);

        floor.Modify(10); // 80
        floor.BlackTileCount.Should().Be(1373);

        floor.Modify(10); // 90
        floor.BlackTileCount.Should().Be(1844);

        floor.Modify(10); // 100
        floor.BlackTileCount.Should().Be(2208);
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