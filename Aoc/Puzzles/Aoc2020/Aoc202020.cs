using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2020;

[Name("Jurassic Jigsaw")]
public class Aoc202020 : AocPuzzle
{
    [Puzzle("53852ec33c717ff2cc141d5403967cd3")]
    public long Part1(string input) => new ImageJigsawPuzzle(input).ProductOfCornerTileIds;

    [Puzzle("064e1e2e30b4fed6bb576ee48cd6c9c1")]
    public long Part2(string input) => new ImageJigsawPuzzle(input).NumberOfHashesThatAreNotPartOfASeaMonster;

    public class ImageJigsawPuzzle
    {
        public readonly Dictionary<long, JigsawTile> TilesById;
        private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;
        private readonly Dictionary<long, List<JigsawTile>> _matchesById;

        public long ProductOfCornerTileIds { get; }

        public ImageJigsawPuzzle(string input)
        {
            var groups = input.Trim().Split(LineBreaks.Double);
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

        private Grid<char> ArrangeTilesAndPaintImage()
        {
            var cornerTilesLeft = CornerTiles.ToList();
            var tileGrid = new Grid<long>();
            var currentTile = cornerTilesLeft.First();

            tileGrid.MoveTo(0, 0);
            tileGrid.WriteValue(currentTile.Id);

            new TopLeftCornerMatcher(_matchesByEdge).TryAllRotations(currentTile);

            while (tileGrid.Values.Count(o => o != 0) < TilesById.Values.Count)
            {
                var edgeToFit = currentTile.Edges["right"];
                var matches = _matchesByEdge[edgeToFit];
                currentTile = matches.FirstOrDefault(o => o.Id != currentTile.Id);
                if (currentTile != null)
                {
                    tileGrid.MoveRight();
                    new LeftEdgeMatcher(edgeToFit).TryAllRotations(currentTile);
                    tileGrid.WriteValue(currentTile.Id);
                }
                else
                {
                    tileGrid.MoveTo(0, tileGrid.Coord.Y);
                    currentTile = TilesById[tileGrid.ReadValue()];
                    tileGrid.MoveDown();
                    edgeToFit = currentTile.Edges["bottom"];
                    matches = _matchesByEdge[edgeToFit];
                    currentTile = matches.First(o => o.Id != currentTile.Id);
                    new TopEdgeMatcher(edgeToFit).TryAllRotations(currentTile);
                    tileGrid.WriteValue(currentTile.Id);
                }
            }

            foreach (var tile in TilesById.Values)
            {
                tile.RemoveBorder();
            }

            var imageGrid = new Grid<char>();
            for (var tileY = 0; tileY < tileGrid.Height; tileY++)
            {
                for (var tileX = 0; tileX < tileGrid.Width; tileX++)
                {
                    var tile = TilesById[tileGrid.ReadValueAt(tileX, tileY)];
                    var tileOffsetX = tileX * tile.Grid.Width;
                    var tileOffsetY = tileY * tile.Grid.Height;
                    for (var localY = 0; localY < tile.Grid.Height; localY++)
                    {
                        for (var localX = 0; localX < tile.Grid.Width; localX++)
                        {
                            var x = localX + tileOffsetX;
                            var y = localY + tileOffsetY;

                            imageGrid.WriteValueAt(x, y, tile.Grid.ReadValueAt(localX, localY));
                        }
                    }
                }
            }

            return imageGrid;
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
            var matches = new Dictionary<string, List<JigsawTile>>();
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
                    if (matchedTile is not null)
                        list.Add(matchedTile);
                }
            }

            return matches;
        }
    }
    
    public abstract class EdgeMatcher : TileMatcher
    {
        private readonly string _edgeToMatch;
        protected abstract string Edge { get; }

        protected EdgeMatcher(string edgeToMatch)
        {
            _edgeToMatch = edgeToMatch;
        }

        protected override bool IsMatch(JigsawTile tile)
        {
            return tile.Edges[Edge] == _edgeToMatch;
        }
    }

    public class JigsawTile
    {
        public long Id { get; }
        public Grid<char> Grid;

        private JigsawTile(long id, Grid<char> grid)
        {
            Id = id;
            Grid = grid;
        }

        public bool HasMatchingEdge(JigsawTile otherTile) =>
            Edges.Values.Any(edge => otherTile.Edges.Values.Any(HasMatchingEdge));

        public bool HasMatchingEdge(string edge)
        {
            var reverseEdge = edge.ReverseString();
            return Edges.Any(o => o.Value == edge || o.Value == reverseEdge);
        }

        public void RotateRight() => Grid = Grid.RotateRight();
        public void FlipVertical() => Grid = Grid.FlipVertical();
        public void FlipHorizontal() => Grid = Grid.FlipHorizontal();

        public Dictionary<string, string> Edges
        {
            get
            {
                var top = new StringBuilder();
                var right = new StringBuilder();
                var bottom = new StringBuilder();
                var left = new StringBuilder();

                var width = Grid.Width;
                var height = Grid.Height;

                const int yTop = 0;
                var yBottom = height - 1;
                for (var x = 0; x < width; x++)
                {
                    top.Append(Grid.ReadValueAt(x, yTop));
                    bottom.Append(Grid.ReadValueAt(x, yBottom));
                }

                var xRight = width - 1;
                const int xLeft = 0;
                for (var y = 0; y < height; y++)
                {
                    right.Append(Grid.ReadValueAt(xRight, y));
                    left.Append(Grid.ReadValueAt(xLeft, y));
                }

                return new Dictionary<string, string>
                {
                    { "top", top.ToString() },
                    { "right", right.ToString() },
                    { "bottom", bottom.ToString() },
                    { "left", left.ToString() }
                };
            }
        }

        public static JigsawTile Parse(string s)
        {
            var parts = s.Split(':');
            var id = long.Parse(parts[0].Split(' ')[1]);
            var grid = GridBuilder.BuildCharGrid(parts[1].Trim());
            return new JigsawTile(id, grid);
        }

        public void RemoveBorder()
        {
            Grid = Grid.Slice(new Coord(Grid.XMin + 1, Grid.YMin + 1), new Coord(Grid.XMax - 1, Grid.YMax - 1));
        }
    }
    
    public class SeaMonsterCounter
    {
        private const string SeaMonsterPattern = """
                                                 ..................#.
                                                 #....##....##....###
                                                 .#..#..#..#..#..#...
                                                 """;

        private readonly List<Func<Grid<char>, Grid<char>>> _searchFlips =
        [
            grid => grid.FlipVertical(),
            grid => grid.FlipHorizontal(),
            grid => grid.FlipVertical(),
            grid => grid.FlipHorizontal()
        ];

        private readonly Grid<char> _seaMonsterGrid;
        private readonly List<Coord> _seaMonsterHashAddresses;

        public SeaMonsterCounter()
        {
            _seaMonsterGrid = GridBuilder.BuildCharGrid(SeaMonsterPattern);
            _seaMonsterHashAddresses = _seaMonsterGrid.Coords.Where(o => _seaMonsterGrid.ReadValueAt(o) == '#').ToList();
        }

        private int Count(Grid<char> grid)
        {
            var seaMonsterCount = 0;
            for (var y = 0; y < grid.Height - _seaMonsterGrid.Height; y++)
            {
                for (var x = 0; x < grid.Width - _seaMonsterGrid.Width; x++)
                {
                    var foundSeaMonster = _seaMonsterHashAddresses.All(address => grid.ReadValueAt(x + address.X, y + address.Y) == '#');
                    seaMonsterCount += foundSeaMonster ? 1 : 0;
                }
            }

            return seaMonsterCount;
        }

        public int GetCount(Grid<char> grid)
        {
            foreach (var flip in _searchFlips)
            {
                grid = flip(grid);
                for (var i = 0; i < 4; i++)
                {
                    grid = grid.RotateRight();

                    var count = Count(grid);
                    if (count > 0)
                        return count;
                }
            }

            return 0;
        }
    }
    
    public abstract class TileMatcher
    {
        private readonly List<Action<JigsawTile>> _searchFlips = new()
        {
            (tile) => tile.FlipVertical(),
            (tile) => tile.FlipHorizontal(),
            (tile) => tile.FlipVertical(),
            (tile) => tile.FlipHorizontal()
        };

        protected abstract bool IsMatch(JigsawTile tile);

        public void TryAllRotations(JigsawTile tile)
        {
            foreach (var flip in _searchFlips)
            {
                flip(tile);
                for (var i = 0; i < 4; i++)
                {
                    tile.RotateRight();

                    if (IsMatch(tile)) 
                        return;
                }
            }
        }
    }
    
    public class LeftEdgeMatcher : EdgeMatcher
    {
        protected override string Edge => "left";

        public LeftEdgeMatcher(string edgeToMatch) : base(edgeToMatch)
        {
        }
    }
    
    public class TopEdgeMatcher : EdgeMatcher
    {
        protected override string Edge => "top";

        public TopEdgeMatcher(string edgeToMatch) : base(edgeToMatch)
        {
        }
    }
    
    public class TopLeftCornerMatcher : TileMatcher
    {
        private readonly Dictionary<string, List<JigsawTile>> _matchesByEdge;

        public TopLeftCornerMatcher(Dictionary<string, List<JigsawTile>> matchesByEdge)
        {
            _matchesByEdge = matchesByEdge;
        }

        protected override bool IsMatch(JigsawTile tile) =>
            _matchesByEdge[tile.Edges["left"]].Count == 0 &&
            _matchesByEdge[tile.Edges["top"]].Count == 0;
    }
}