using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ImageJigsaw
{
    public class ImageJigsawPuzzle
    {
        public readonly Dictionary<long, JigsawTile> _tiles;
        private readonly Dictionary<long, List<JigsawTile>> _matches;
        
        public ImageJigsawPuzzle(string input)
        {
            var groups = PuzzleInputReader.ReadStringGroups(input);
            _tiles = new Dictionary<long, JigsawTile>();
            foreach (var group in groups)
            {
                var tile = JigsawTile.Parse(group);
                _tiles.Add(tile.Id, tile);
            }
            _matches = FindMatches(_tiles.Values.ToList());
        }

        public IList<JigsawTile> CornerTiles => _matches.Where(o => o.Value.Count == 2).Select(o => _tiles[o.Key]).OrderBy(o => o.Id).ToList();

        public long ProductOfCornerTileIds => CornerTiles.Aggregate<JigsawTile, long>(1, (current, tile) => current * tile.Id);

        private Dictionary<long, List<JigsawTile>> FindMatches(IList<JigsawTile> tiles)
        {
            var matches = new Dictionary<long, List<JigsawTile>>();
            foreach (var tile in tiles)
            {
                var tileMatches = tiles.Where(o => o.Id != tile.Id && o.HasMatchingEdge(tile)).ToList();
                matches.Add(tile.Id, tileMatches);
            }

            return matches;
        }
    }
}