using NUnit.Framework;

namespace App.Puzzles.Year2020.Day24
{
    public class Year2020Day24Tests
    {
        [TestCase("esew")]
        [TestCase("nwwswee")]
        public void OneTileIsBlackAfterArrange(string input)
        {
            var floor = new HexagonalFloor(input);
            floor.Arrange();
            var result = floor.BlackTileCount;

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void FiveTilesAreBlackAfterArrange()
        {
            var floor = new HexagonalFloor(Input);
            floor.Arrange();
            var result = floor.BlackTileCount;

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void FiveTilesAreBlack()
        {
            var floor = new HexagonalFloor(Input);
            floor.Arrange();
            var result = floor.BlackTileCount;

            Assert.That(result, Is.EqualTo(10));
        }

        [Test]
        public void BlackTilesCorrectAfterEachRun()
        {
            var floor = new HexagonalFloor(Input);
            floor.Arrange();

            floor.Modify(1); // 1
            Assert.That(floor.BlackTileCount, Is.EqualTo(15));

            floor.Modify(1); // 2
            Assert.That(floor.BlackTileCount, Is.EqualTo(12));

            floor.Modify(1); // 3
            Assert.That(floor.BlackTileCount, Is.EqualTo(25));

            floor.Modify(1); // 4
            Assert.That(floor.BlackTileCount, Is.EqualTo(14));

            floor.Modify(1); // 5
            Assert.That(floor.BlackTileCount, Is.EqualTo(23));

            floor.Modify(1); // 6
            Assert.That(floor.BlackTileCount, Is.EqualTo(28));

            floor.Modify(1); // 7
            Assert.That(floor.BlackTileCount, Is.EqualTo(41));

            floor.Modify(1); // 8
            Assert.That(floor.BlackTileCount, Is.EqualTo(37));

            floor.Modify(1); // 9
            Assert.That(floor.BlackTileCount, Is.EqualTo(49));

            floor.Modify(1); // 10
            Assert.That(floor.BlackTileCount, Is.EqualTo(37));

            floor.Modify(10); // 20
            Assert.That(floor.BlackTileCount, Is.EqualTo(132));

            floor.Modify(10); // 30
            Assert.That(floor.BlackTileCount, Is.EqualTo(259));

            floor.Modify(10); // 40
            Assert.That(floor.BlackTileCount, Is.EqualTo(406));

            floor.Modify(10); // 50
            Assert.That(floor.BlackTileCount, Is.EqualTo(566));

            floor.Modify(10); // 60
            Assert.That(floor.BlackTileCount, Is.EqualTo(788));

            floor.Modify(10); // 70
            Assert.That(floor.BlackTileCount, Is.EqualTo(1106));

            floor.Modify(10); // 80
            Assert.That(floor.BlackTileCount, Is.EqualTo(1373));

            floor.Modify(10); // 90
            Assert.That(floor.BlackTileCount, Is.EqualTo(1844));

            floor.Modify(10); // 100
            Assert.That(floor.BlackTileCount, Is.EqualTo(2208));
        }

        private const string Input = @"
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
wseweeenwnesenwwwswnew";
    }
}