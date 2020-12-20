using System.Collections.Generic;
using System.Linq;
using Core.Tools;

namespace Core.ImageJigsaw
{
    public class ImageJigsawPuzzle
    {
        public readonly Dictionary<long, JigsawTile> TilesById;
        private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;
        private readonly Dictionary<long, List<JigsawTile>> _matchesById;
        
        public ImageJigsawPuzzle(string input)
        {
            var groups = PuzzleInputReader.ReadStringGroups(input);
            TilesById = new Dictionary<long, JigsawTile>();
            foreach (var group in groups)
            {
                var tile = JigsawTile.Parse(group);
                TilesById.Add(tile.Id, tile);
            }
            _matchesById = FindMatchingTiles(TilesById.Values.ToList());
            _matchesByEdge = FindMatchingEdges(TilesById.Values.ToList());

            var fullPuzzle = ArrangeTiles();
        }

        private Matrix<char> ArrangeTiles()
        {
            var cornerTilesLeft = CornerTiles.ToList();
            var tileMatrix = new Matrix<long>();
            
            //var currentTile = cornerTilesLeft.First();

            var currentTile = TilesById[1951];
            currentTile.FlipVertical();

            tileMatrix.MoveTo(0, 0);
            tileMatrix.WriteValue(currentTile.Id);

            RotateUntilCornerTileIsCorrect(currentTile);

            currentTile.Done = true;

            while (tileMatrix.Values.Count(o => o != 0) < TilesById.Values.Count)
            {
                var edgeToFit = currentTile.Edges["right"];
                var matches = _matchesByEdge[edgeToFit];
                currentTile = matches?.FirstOrDefault(o => o != null && o.Id != currentTile.Id);
                if (currentTile != null)
                {
                    tileMatrix.MoveRight();
                    RotateUntilLeftEdgeMatches(currentTile, edgeToFit);
                    currentTile.Done = true;
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
                    currentTile.Done = true;
                    tileMatrix.WriteValue(currentTile.Id);
                }
            }


            var puzzleMatrix = new Matrix<char>();

            return puzzleMatrix;
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

        public IList<JigsawTile> CornerTiles => _matchesById.Where(o => o.Value.Count == 2).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();
        public IList<JigsawTile> EdgeTiles => _matchesById.Where(o => o.Value.Count == 3).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();
        public IList<JigsawTile> CenterTiles => _matchesById.Where(o => o.Value.Count == 4).Select(o => TilesById[o.Key]).OrderBy(o => o.Id).ToList();

        public long ProductOfCornerTileIds => CornerTiles.Aggregate<JigsawTile, long>(1, (current, tile) => current * tile.Id);

        private Dictionary<long, List<JigsawTile>> FindMatchingTiles(IList<JigsawTile> tiles)
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
}