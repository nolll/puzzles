using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Aoc.Puzzles.Aoc2020.Aoc202020;

public class Aoc202020Tests
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

        tile.Edges["top"].Should().Be("..##.#..#.");
        tile.Edges["right"].Should().Be("...#.##..#");
        tile.Edges["bottom"].Should().Be("..###..###");
        tile.Edges["left"].Should().Be(".#####..#.");
    }

    [TestCase(2311, 3079)]
    public void TilesHasMatchingEdge(long tileId1, long tileId2)
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var tile1 = puzzle.TilesById[tileId1];
        var tile2 = puzzle.TilesById[tileId2];

        var hasMatchingEdge = tile1.HasMatchingEdge(tile2);

        hasMatchingEdge.Should().BeTrue();
    }

    [Test]
    public void CornerTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.CornerTiles;

        cornerTiles.Count.Should().Be(4);
        cornerTiles[0].Id.Should().Be(1171);
        cornerTiles[1].Id.Should().Be(1951);
        cornerTiles[2].Id.Should().Be(2971);
        cornerTiles[3].Id.Should().Be(3079);
    }

    [Test]
    public void EdgeTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.EdgeTiles;

        cornerTiles.Count.Should().Be(4);
        cornerTiles[0].Id.Should().Be(1489);
        cornerTiles[1].Id.Should().Be(2311);
        cornerTiles[2].Id.Should().Be(2473);
        cornerTiles[3].Id.Should().Be(2729);
    }

    [Test]
    public void CenterTilesAreCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var cornerTiles = puzzle.CenterTiles;

        cornerTiles.Count.Should().Be(1);
        cornerTiles[0].Id.Should().Be(1427);
    }

    [Test]
    public void CornerTileProductIsCorrect()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var product = puzzle.ProductOfCornerTileIds;

        product.Should().Be(20899048083289);
    }

    [Test]
    public void RemoveBorders()
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

        const string expected = """
                                #..#....
                                ...##..#
                                ###.#...
                                #.##.###
                                #...#.##
                                #.#.#..#
                                .#....#.
                                ##...#.#
                                """;

        var tile = JigsawTile.Parse(input);
        tile.RemoveBorder();

        tile.Matrix.Print().Should().Be(expected);
    }

    [Test]
    public void NumberOfHashesNotPartOfSeaMonsters()
    {
        var puzzle = new ImageJigsawPuzzle(Input);
        var hashes = puzzle.NumberOfHashesThatAreNotPartOfASeaMonster;

        hashes.Should().Be(273);
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

    private const string Expected = """
                                    .#.#..#.##...#.##..#####
                                    ###....#.#....#..#......
                                    ##.##.###.#.#..######...
                                    ###.#####...#.#####.#..#
                                    ##.#....#.##.####...#.##
                                    ...########.#....#####.#
                                    ....#..#...##..#.#.###..
                                    .####...#..#.....#......
                                    #..#.##..#..###.#.##....
                                    #.####..#.####.#.#.###..
                                    ###.#.#...#.######.#..##
                                    #.####....##..########.#
                                    ##..##.#...#...#.#.#.#..
                                    ...#..#..#.#.##..###.###
                                    .#.#....#.##.#...###.##.
                                    ###.#...#..#.##.######..
                                    .#.#.###.##.##.#..#.##..
                                    .####.###.#...###.#..#.#
                                    ..#.#..#..#.#.#.####.###
                                    #..####...#.#.#.###.###.
                                    #####..#####...###....##
                                    #.##..#..#...#..####...#
                                    .#.###..##..##..####.##.
                                    ...###...##...#...#..###
                                    """;
}