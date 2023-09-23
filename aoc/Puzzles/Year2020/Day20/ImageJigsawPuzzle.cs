using System.Collections.Generic;
using System.Linq;
using Common.CoordinateSystems.CoordinateSystem2D;
using Common.Strings;

namespace Aoc.Puzzles.Year2020.Day20;

public class ImageJigsawPuzzle
{
    private const string SeaMonsterPattern = """
..................#.
#....##....##....###
.#..#..#..#..#..#...
""";

    public readonly Dictionary<long, JigsawTile> TilesById;
    private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;
    private readonly Dictionary<long, List<JigsawTile>> _matchesById;
    private readonly Matrix<char> _seaMonsterMatrix;
    private readonly List<MatrixAddress> _seaMonsterHashAddresses;

    public long ProductOfCornerTileIds { get; }
        
    public ImageJigsawPuzzle(string input)
    {
        _seaMonsterMatrix = MatrixBuilder.BuildCharMatrix(SeaMonsterPattern);
        _seaMonsterHashAddresses = _seaMonsterMatrix.Coords.Where(o => _seaMonsterMatrix.ReadValueAt(o) == '#').ToList();
        var groups = PuzzleInputReader.ReadStringGroups(input);
        TilesById = new Dictionary<long, JigsawTile>();
        foreach (var group in groups)
        {
            var tile = JigsawTile.Parse(group);
            TilesById.Add(tile.Id, tile);
        }
        _matchesById = FindMatchingTiles(TilesById.Values.ToList());
        _matchesByEdge = FindMatchingEdges(TilesById.Values.ToList());

        ProductOfCornerTileIds = CornerTiles.Aggregate<JigsawTile, long>(1, (current, tile) => current * tile.Id);

            
    }

    public long NumberOfHashesThatAreNotPartOfASeaMonster
    {
        get
        {
            var image = ArrangeTilesAndPaintImage();
            var numberOfSeaMonsters = SearchForSeaMonsters(image);
            var numberOfHashes = image.Values.Count(o => o == '#');
            var numberOfHashesInSeaMonster = 15;
            return numberOfHashes - numberOfSeaMonsters * numberOfHashesInSeaMonster;
        }
    }

    private int GetNumberOfSeaMonsters(Matrix<char> matrix)
    {
        var seaMonsterCount = 0;
        for (var y = 0; y < matrix.Height - _seaMonsterMatrix.Height; y++)
        {
            for (var x = 0; x < matrix.Width - _seaMonsterMatrix.Width; x++)
            {
                var foundSeaMonster = _seaMonsterHashAddresses.All(address => matrix.ReadValueAt(x + address.X, y + address.Y) == '#');
                seaMonsterCount += foundSeaMonster ? 1 : 0;
            }
        }

        return seaMonsterCount;
    }

    private int SearchForSeaMonsters(Matrix<char> matrix)
    {
        var numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);

        var rotationCount = 0;
        while (rotationCount < 4 && numberOfSeaMonsters == 0)
        {
            matrix = matrix.RotateRight();
            rotationCount++;
            numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
        }

        rotationCount = 0;
            
        if (numberOfSeaMonsters == 0)
        {
            matrix = matrix.FlipVertical();
            numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            while (rotationCount < 4 && numberOfSeaMonsters == 0)
            {
                matrix = matrix.RotateRight();
                rotationCount++;
                numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            }
        }

        rotationCount = 0;
        numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
        if (numberOfSeaMonsters == 0)
        {
            matrix = matrix.FlipHorizontal();
            numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            while (rotationCount < 4 && numberOfSeaMonsters == 0)
            {
                matrix = matrix.RotateRight();
                rotationCount++;
                numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            }
        }

        rotationCount = 0;
        if (numberOfSeaMonsters == 0)
        {
            matrix = matrix.FlipVertical();
            numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            while (rotationCount < 4 && numberOfSeaMonsters == 0)
            {
                matrix = matrix.RotateRight();
                rotationCount++;
                numberOfSeaMonsters = GetNumberOfSeaMonsters(matrix);
            }
        }

        return numberOfSeaMonsters;
    }

    private string GetPrintout(Matrix<char> matrix)
    {
        return matrix.Print().Replace("\r\n", "");
    }

    public IList<JigsawTile> CornerTiles => _matchesById.Where(o => o.Value.Count == 2).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();
    public IList<JigsawTile> EdgeTiles => _matchesById.Where(o => o.Value.Count == 3).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();
    public IList<JigsawTile> CenterTiles => _matchesById.Where(o => o.Value.Count == 4).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();

    private Matrix<char> ArrangeTilesAndPaintImage()
    {
        var cornerTilesLeft = CornerTiles.ToList();
        var tileMatrix = new Matrix<long>();
        var currentTile = cornerTilesLeft.First();

        tileMatrix.MoveTo(0, 0);
        tileMatrix.WriteValue(currentTile.Id);

        RotateUntilCornerTileIsCorrect(currentTile);

        while (tileMatrix.Values.Count(o => o != 0) < TilesById.Values.Count)
        {
            var edgeToFit = currentTile.Edges["right"];
            var matches = _matchesByEdge[edgeToFit];
            currentTile = matches?.FirstOrDefault(o => o != null && o.Id != currentTile.Id);
            if (currentTile != null)
            {
                tileMatrix.MoveRight();
                RotateUntilLeftEdgeMatches(currentTile, edgeToFit);
                tileMatrix.WriteValue(currentTile.Id);
            }
            else
            {
                tileMatrix.MoveTo(0, tileMatrix.Address.Y);
                currentTile = TilesById[tileMatrix.ReadValue()];
                tileMatrix.MoveDown();
                edgeToFit = currentTile.Edges["bottom"];
                matches = _matchesByEdge[edgeToFit];
                currentTile = matches.First(o => o.Id != currentTile.Id);
                RotateUntilTopEdgeMatches(currentTile, edgeToFit);
                tileMatrix.WriteValue(currentTile.Id);
            }
        }

        foreach (var tile in TilesById.Values)
        {
            tile.RemoveBorder();
        }

        var imageMatrix = new Matrix<char>();
        for (var tileY = 0; tileY < tileMatrix.Height; tileY++)
        {
            for (var tileX = 0; tileX < tileMatrix.Width; tileX++)
            {
                var tile = TilesById[tileMatrix.ReadValueAt(tileX, tileY)];
                var tileOffsetX = tileX * tile.Matrix.Width;
                var tileOffsetY = tileY * tile.Matrix.Height;
                for (var localY = 0; localY < tile.Matrix.Height; localY++)
                {
                    for (var localX = 0; localX < tile.Matrix.Width; localX++)
                    {
                        var x = localX + tileOffsetX;
                        var y = localY + tileOffsetY;

                        imageMatrix.WriteValueAt(x, y, tile.Matrix.ReadValueAt(localX, localY));
                    }
                }
            }
        }
        return imageMatrix;
    }
        
    private void RotateUntilLeftEdgeMatches(JigsawTile currentTile, string edgeToFit)
    {
        var rotationCount = 0;
        while (rotationCount < 4 && currentTile.Edges["left"] != edgeToFit)
        {
            currentTile.RotateRight();
            rotationCount++;
        }

        rotationCount = 0;
        if (currentTile.Edges["left"] != edgeToFit)
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && currentTile.Edges["left"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (currentTile.Edges["left"] != edgeToFit)
        {
            currentTile.FlipHorizontal();
            while (rotationCount < 4 && currentTile.Edges["left"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (currentTile.Edges["left"] != edgeToFit)
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && currentTile.Edges["left"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }
    }

    private void RotateUntilTopEdgeMatches(JigsawTile currentTile, string edgeToFit)
    {
        var rotationCount = 0;
        while (rotationCount < 4 && currentTile.Edges["top"] != edgeToFit)
        {
            currentTile.RotateRight();
            rotationCount++;
        }

        rotationCount = 0;
        if (currentTile.Edges["top"] != edgeToFit)
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && currentTile.Edges["top"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (currentTile.Edges["top"] != edgeToFit)
        {
            currentTile.FlipHorizontal();
            while (rotationCount < 4 && currentTile.Edges["top"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (currentTile.Edges["top"] != edgeToFit)
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && currentTile.Edges["top"] != edgeToFit)
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }
    }

    private void RotateUntilCornerTileIsCorrect(JigsawTile currentTile)
    {
        var rotationCount = 0;
        while (rotationCount < 4 && !IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
        {
            currentTile.RotateRight();
            rotationCount++;
        }

        rotationCount = 0;
        if (!IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && !IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (!IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
        {
            currentTile.FlipHorizontal();
            while (rotationCount < 4 && !IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }

        rotationCount = 0;
        if (!IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
        {
            currentTile.FlipVertical();
            while (rotationCount < 4 && !IsCornerPieceRotatedCorrectly(currentTile, "top", "left"))
            {
                currentTile.RotateRight();
                rotationCount++;
            }
        }
    }

    private bool IsCornerPieceRotatedCorrectly(JigsawTile tile, string edge1, string edge2)
    {
        var matchingTilesEdge1 = _matchesByEdge[tile.Edges[edge1]];
        var matchingTilesEdge2 = _matchesByEdge[tile.Edges[edge2]];

        return matchingTilesEdge1.Count == 1 && matchingTilesEdge2.Count == 1;
    }

    private static Dictionary<long, List<JigsawTile>> FindMatchingTiles(IList<JigsawTile> tiles)
    {
        var matches = new Dictionary<long, List<JigsawTile>>();
        foreach (var tile in tiles)
        {
            var tileMatches = tiles.Where(o => o.Id != tile.Id && o.HasMatchingEdge(tile)).ToList();
            matches.Add(tile.Id, tileMatches);
        }

        return matches;
    }

    private Dictionary<string, List<JigsawTile>> FindMatchingEdges(IList<JigsawTile> tiles)
    {
        var matches = new Dictionary<string, List<JigsawTile>> ();
        foreach (var tile in tiles)
        {
            foreach (var edge in tile.Edges.Values)
            {
                var reversedEdge = edge.Reverse();
                if (!matches.TryGetValue(edge, out var list))
                {
                    list = new List<JigsawTile>();
                    matches.Add(edge, list);
                    matches.Add(reversedEdge, list);
                }

                var matchedTile = TilesById.Values.FirstOrDefault(o => o.HasMatchingEdge(edge) && o.Id != tile.Id);
                list.Add(matchedTile);
            }
        }

        return matches;
    }
}