using Puzzles.Common.CoordinateSystems.CoordinateSystem2D;
using Puzzles.Common.Strings;
using StringReader = Puzzles.Common.Strings.StringReader;

namespace Puzzles.Aoc.Puzzles.Aoc2020.Aoc202020;

public class ImageJigsawPuzzle
{
    public readonly Dictionary<long, JigsawTile> TilesById;
    private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;
    private readonly Dictionary<long, List<JigsawTile>> _matchesById;
    
    public long ProductOfCornerTileIds { get; }
        
    public ImageJigsawPuzzle(string input)
    {
        var groups = StringReader.ReadStringGroups(input);
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
            var numberOfSeaMonsters = new SeaMonsterCounter().GetCount(image); 
            var numberOfHashes = image.Values.Count(o => o == '#');
            const int numberOfHashesInSeaMonster = 15;
            return numberOfHashes - numberOfSeaMonsters * numberOfHashesInSeaMonster;
        }
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

        new TopLeftCornerMatcher(_matchesByEdge).TryAllRotations(currentTile);

        while (tileMatrix.Values.Count(o => o != 0) < TilesById.Values.Count)
        {
            var edgeToFit = currentTile.Edges["right"];
            var matches = _matchesByEdge[edgeToFit];
            currentTile = matches.FirstOrDefault(o => o.Id != currentTile.Id);
            if (currentTile != null)
            {
                tileMatrix.MoveRight();
                new LeftEdgeMatcher(edgeToFit).TryAllRotations(currentTile);
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
                new TopEdgeMatcher(edgeToFit).TryAllRotations(currentTile);
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
                var reversedEdge = edge.ReverseString();
                if (!matches.TryGetValue(edge, out var list))
                {
                    list = new List<JigsawTile>();
                    matches.Add(edge, list);
                    matches.Add(reversedEdge, list);
                }

                var matchedTile = TilesById.Values.FirstOrDefault(o => o.HasMatchingEdge(edge) && o.Id != tile.Id);
                if(matchedTile is not null)
                    list.Add(matchedTile);
            }
        }

        return matches;
    }
}