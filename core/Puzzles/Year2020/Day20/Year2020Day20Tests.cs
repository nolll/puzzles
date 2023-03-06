using NUnit.Framework;

namespace Core.Puzzles.Year2020.Day20;

public class Year2020Day20Tests
{
    [TestCase(2311)]
    public void EdgesAreCorrect(long tileId)
    {
        const string input = """
Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###
""";

        var tile = JigsawTile.Parse(input);

        Assert.That(tile.Edges["top"], Is.EqualTo("..##.#..#."));
        Assert.That(tile.Edges["right"], Is.EqualTo("...#.##..#"));
        Assert.That(tile.Edges["bottom"], Is.EqualTo("..###..###"));
        Assert.That(tile.Edges["left"], Is.EqualTo(".#####..#."));
    }

    [TestCase(2311, 3079)]
    public void TilesHasMatchingEdge(long tileId1, long tileId2)
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var tile1 = puzzle.TilesById[tileId1];
        var tile2 = puzzle.TilesById[tileId2];

        var hasMatchingEdge = tile1.HasMatchingEdge(tile2);

        Assert.That(hasMatchingEdge, Is.True);
    }

    [Test]
    public void CornerTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.CornerTiles;

        Assert.That(cornerTiles.Count, Is.EqualTo(4));
        Assert.That(cornerTiles[0].Id, Is.EqualTo(1171));
        Assert.That(cornerTiles[1].Id, Is.EqualTo(1951));
        Assert.That(cornerTiles[2].Id, Is.EqualTo(2971));
        Assert.That(cornerTiles[3].Id, Is.EqualTo(3079));
    }

    [Test]
    public void EdgeTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.EdgeTiles;

        Assert.That(cornerTiles.Count, Is.EqualTo(4));
        Assert.That(cornerTiles[0].Id, Is.EqualTo(1489));
        Assert.That(cornerTiles[1].Id, Is.EqualTo(2311));
        Assert.That(cornerTiles[2].Id, Is.EqualTo(2473));
        Assert.That(cornerTiles[3].Id, Is.EqualTo(2729));
    }

    [Test]
    public void CenterTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.CenterTiles;

        Assert.That(cornerTiles.Count, Is.EqualTo(1));
        Assert.That(cornerTiles[0].Id, Is.EqualTo(1427));
    }

    [Test]
    public void CornerTileProductIsCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var product = puzzle.ProductOfCornerTileIds;

        Assert.That(product, Is.EqualTo(20899048083289));
    }

    [Test]
    public void NumberOfHashesNotPartOfSeaMonsters()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var hashes = puzzle.NumberOfHashesThatAreNotPartOfASeaMonster;

        Assert.That(hashes, Is.EqualTo(273));
    }

    private const string Input = """
Tile 2311:
..##.#..#.
##..#.....
#...##..#.
####.#...#
##.##.###.
##...#.###
.#.#.#..##
..#....#..
###...#.#.
..###..###

Tile 1951:
#.##...##.
#.####...#
.....#..##
#...######
.##.#....#
.###.#####
###.##.##.
.###....#.
..#.#..#.#
#...##.#..

Tile 1171:
####...##.
#..##.#..#
##.#..#.#.
.###.####.
..###.####
.##....##.
.#...####.
#.##.####.
####..#...
.....##...

Tile 1427:
###.##.#..
.#..#.##..
.#.##.#..#
#.#.#.##.#
....#...##
...##..##.
...#.#####
.#.####.#.
..#..###.#
..##.#..#.

Tile 1489:
##.#.#....
..##...#..
.##..##...
..#...#...
#####...#.
#..#.#.#.#
...#.#.#..
##.#...##.
..##.##.##
###.##.#..

Tile 2473:
#....####.
#..#.##...
#.##..#...
######.#.#
.#...#.#.#
.#########
.###.#..#.
########.#
##...##.#.
..###.#.#.

Tile 2971:
..#.#....#
#...###...
#.#.###...
##.##..#..
.#####..##
.#..####.#
#..#.#..#.
..####.###
..#.#.###.
...#.#.#.#

Tile 2729:
...#.#.#.#
####.#....
..#.#.....
....#..#.#
.##..##.#.
.#.####...
####.#.#..
##.####...
##..#.##..
#.##...##.

Tile 3079:
#.#.#####.
.#..######
..#.......
######....
####.#..#.
.#...#.##.
#.#####.##
..#.###...
..#.......
..#.###...
""";
}