using System.Text;
using Pzl.Common;
using Pzl.Tools.Grids.Grids2d;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2017;

[Name("Fractal Art")]
[IsFunToOptimize]
[Comment("The grid slicing could possibly be done with the grid method, but I can't get it to work")]
public class Aoc201721 : AocPuzzle
{
    [Puzzle("f24d8ef1e8322a91dcdf1127a3ec636c")]
    public int Part1(string input) => Run(input, 5);

    [Puzzle("0e5a4e760ff761a833c010149f058fbc")]
    public int Part2(string input) => Run(input, 18);

    public int Run(string input, int iterations) => new FractalArtGenerator(input).Run(iterations);

    private class FractalArtGenerator
    {
        private const string Inital = """
                                      .#.
                                      ..#
                                      ###
                                      """;

        private Grid<char> _grid;
        private readonly IList<FractalRule> _rules2X2;
        private readonly IList<FractalRule> _rules3X3;
        private readonly IDictionary<string, IList<GridVariant>> _variantCache;
        private readonly IDictionary<string, Grid<char>> _transformCache;

        public FractalArtGenerator(string input)
        {
            var rules = ParseRules(input);
            _rules2X2 = rules.Where(o => o.Input.Length == 5).ToList();
            _rules3X3 = rules.Where(o => o.Input.Length != 5).ToList();

            _grid = GridBuilder.BuildCharGrid(Inital);
            _variantCache = new Dictionary<string, IList<GridVariant>>();
            _transformCache = new Dictionary<string, Grid<char>>();
        }

        private static IList<FractalRule> ParseRules(string input) =>
            input.Split(LineBreaks.Single).Select(ParseRule).ToList();

        private static FractalRule ParseRule(string s)
        {
            var (input, output) = s.Split(" => ");
            return new FractalRule(input, output);
        }

        public int Run(int iterations)
        {
            var i = 0;
            while (i < iterations)
            {
                Modify();
                i++;
            }
            
            return _grid.Values.Count(o => o == '#');
        }

        private void Modify()
        {
            var size = _grid.Width;
            var subgridSize = size % 2 == 0 ? 2 : 3;
            Modify(subgridSize);
        }

        private void Modify(int subSize) => _grid = Join(GetSubgrids(subSize).Select(Transform).ToList());

        private static Grid<char> Join(List<Grid<char>> grids)
        {
            var newGrid = new Grid<char>();
            var size = grids.First().Width;
            var gridsPerRow = (int)Math.Sqrt(grids.Count);
            var col = 0;
            var row = 0;
            foreach (var grid in grids)
            {
                for (var y = 0; y < grid.Height; y++)
                {
                    for (var x = 0; x < grid.Width; x++)
                    {
                        var localX = x + col * size;
                        var localY = y + row * size;
                        newGrid.MoveTo(localX, localY);
                        newGrid.WriteValue(grid.ReadValueAt(x, y));
                    }
                }

                col++;
                if (col < gridsPerRow)
                    continue;

                col = 0;
                row++;
            }

            return newGrid;
        }

        private record GridVariant(string Key);

        private IList<GridVariant> GetVariants(Grid<char> grid)
        {
            var key = GridToString(grid);
            if (_variantCache.TryGetValue(key, out var variants))
                return variants;

            variants = CreateVariants(grid).ToList();
            _variantCache.Add(key, variants);
            return variants;
        }

        private static IEnumerable<GridVariant> CreateVariants(Grid<char> grid)
        {
            yield return new(GridToString(grid));

            var flippedGrid = grid.FlipHorizontal();
            yield return new(GridToString(flippedGrid));

            flippedGrid = grid.FlipVertical();
            yield return new(GridToString(flippedGrid));

            var rotatedGrid = grid.RotateRight();
            yield return new(GridToString(rotatedGrid));

            flippedGrid = rotatedGrid.FlipHorizontal();
            yield return new(GridToString(flippedGrid));

            flippedGrid = rotatedGrid.FlipVertical();
            yield return new(GridToString(flippedGrid));

            rotatedGrid = rotatedGrid.RotateRight();
            yield return new(GridToString(rotatedGrid));

            flippedGrid = rotatedGrid.FlipHorizontal();
            yield return new(GridToString(flippedGrid));

            flippedGrid = rotatedGrid.FlipVertical();
            yield return new(GridToString(flippedGrid));

            rotatedGrid = rotatedGrid.RotateRight();
            yield return new(GridToString(rotatedGrid));

            flippedGrid = rotatedGrid.FlipHorizontal();
            yield return new(GridToString(flippedGrid));

            flippedGrid = rotatedGrid.FlipVertical();
            yield return new(GridToString(flippedGrid));
        }

        private Grid<char> Transform(Grid<char> grid)
        {
            var key = GridToString(grid);
            if (_transformCache.TryGetValue(key, out var transformedGrid))
                return transformedGrid;

            var variants = GetVariants(grid);
            var size = grid.Width;
            var rules = size == 2 ? _rules2X2 : _rules3X3;

            foreach (var rule in rules)
            {
                if (!variants.Any(variant => rule.IsMatch(variant.Key)))
                    continue;

                transformedGrid = rule.Output;
                _transformCache.Add(key, transformedGrid);
                return transformedGrid;
            }

            throw new Exception("No transformation rule matched");
        }
        
        private static string GridToString(Grid<char> grid)
        {
            var sb = new StringBuilder();
            for (var y = 0; y < grid.Height; y++)
            {
                for (var x = 0; x < grid.Width; x++)
                {
                    sb.Append(grid.ReadValueAt(x, y));
                }

                sb.Append('/');
            }

            return sb.ToString().TrimEnd('/');
        }

        private IEnumerable<Grid<char>> GetSubgrids(int subSize)
        {
            var size = _grid.Width;
            var x = 0;
            var y = 0;
            while (y < size)
            {
                while (x < size)
                {
                    var grid = new Grid<char>();
                    for (var localY = 0; localY < subSize; localY++)
                    {
                        for (var localX = 0; localX < subSize; localX++)
                        {
                            grid.WriteValueAt(localX, localY, _grid.ReadValueAt(x + localX, y + localY));
                        }
                    }

                    yield return grid;
                    x += subSize;
                }

                y += subSize;
                x = 0;
            }
        }
    }

    private class FractalRule(string input, string output)
    {
        public string Input { get; } = input;
        public Grid<char> Output { get; } = GridBuilder.BuildCharGrid(output.Replace("/", LineBreaks.Single));
        public bool IsMatch(string compare) => compare == Input;
    }
}