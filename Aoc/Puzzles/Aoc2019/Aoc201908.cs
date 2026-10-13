using System.Text;
using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Space Image Format")]
public class Aoc201908 : AocPuzzle
{
    [Puzzle("f120f42ddc8c176e63cab4413a41bd99")]
    public int Part1(string input) => GetChecksum(GetLayers(input).ToList());

    [Puzzle("a51c490e0a182d6faf996faa2205c829")]
    public string Part2(string input) => OcrSmallFont.ReadString(Print(ComposeImage([.. GetLayers(input)])));

    private IEnumerable<Layer> GetLayers(string imageData)
    {
        const int layerLength = Dimensions.Width * Dimensions.Height;
        for (var i = 0; i < imageData.Length; i += layerLength)
        {
            yield return new Layer(imageData.Substring(i, layerLength));
        }
    }

    private List<List<char>> ComposeImage(List<Layer> layers)
    {
        var rows = new List<List<char>>();
        for (var y = 0; y < Dimensions.Height; y++)
        {
            var pixels = new List<char>();
            for (var x = 0; x < Dimensions.Width; x++)
            {
                pixels.Add(GetCharForPixel(layers, x, y));
            }

            rows.Add(pixels);
        }

        return [.. rows];
    }

    private static char GetCharForPixel(List<Layer> layers, int x, int y)
    {
        foreach (var layer in layers)
        {
            var c = layer.GetChar(x, y);
            if (c != '2')
                return c;
        }

        return '2';
    }

    private static int GetChecksum(List<Layer> layers)
    {
        var layer = LayerWithFewestZeros(layers);
        return layer.NumberOfOnes * layer.NumberOfTwos;
    }

    private static Layer LayerWithFewestZeros(List<Layer> layers) => layers.OrderBy(o => o.NumberOfZeros).First();

    private static string Print(List<List<char>> grid)
    {
        var sb = new StringBuilder();
        foreach (var row in grid)
        {
            foreach (var pixel in row)
            {
                var output = pixel == '1' ? '#' : '.';
                sb.Append(output);
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }
    
    private static class Dimensions
    {
        public const int Width = 25;
        public const int Height = 6;
    }

    public class Layer
    {
        private readonly string _data;
        private readonly int _width;
        private readonly List<List<char>> _grid;

        public int NumberOfZeros => GetCharCount(_data, '0');
        public int NumberOfOnes => GetCharCount(_data, '1');
        public int NumberOfTwos => GetCharCount(_data, '2');

        public Layer(string data, int width = Dimensions.Width)
        {
            _data = data;
            _width = width;
            _grid = CreateGrid(data);
        }

        private List<List<char>> CreateGrid(string data) => new([.. GetRows(data)]);

        private IEnumerable<List<char>> GetRows(string imageData)
        {
            for (var i = 0; i < imageData.Length; i += _width)
            {
                yield return [.. imageData.Substring(i, _width).ToCharArray()];
            }
        }

        public char GetChar(int x, int y) => _grid[y][x];
        private static int GetCharCount(string data, char character) => data.Count(c => c == character);
    }
}