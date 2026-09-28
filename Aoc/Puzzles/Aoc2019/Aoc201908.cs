using System.Text;
using Pzl.Common;
using Pzl.Tools.Ocr;

namespace Pzl.Aoc.Puzzles.Aoc2019;

[Name("Space Image Format")]
public class Aoc201908 : AocPuzzle
{
    [Puzzle("f120f42ddc8c176e63cab4413a41bd99")]
    public int Part1(string input) => new SpaceImage(input).Checksum;

    [Puzzle("a51c490e0a182d6faf996faa2205c829")]
    public string Part2(string input) => OcrSmallFont.ReadString(new SpaceImage(input).Print());
    
    public class SpaceImage
    {
        private readonly IList<SpaceImageLayer> _layers;
        private readonly IList<IList<char>> _grid;

        public SpaceImage(string imageData)
        {
            _layers = GetLayers(imageData).ToList();
            _grid = ComposeImage();
        }

        private IEnumerable<SpaceImageLayer> GetLayers(string imageData)
        {
            const int layerLength = SpaceImageDimensions.Width * SpaceImageDimensions.Height;
            for (var i = 0; i < imageData.Length; i += layerLength)
            {
                yield return new SpaceImageLayer(imageData.Substring(i, layerLength));
            }
        }

        private IList<IList<char>> ComposeImage()
        {
            var rows = new List<IList<char>>();
            for (var y = 0; y < SpaceImageDimensions.Height; y++)
            {
                var pixels = new List<char>();
                for (var x = 0; x < SpaceImageDimensions.Width; x++)
                {
                    pixels.Add(GetCharForPixel(x, y));
                }
                rows.Add(pixels);
            }
            return new List<IList<char>>(rows);
        }

        private char GetCharForPixel(int x, int y)
        {
            foreach (var layer in _layers)
            {
                var c = layer.GetChar(x, y);
                if (c != '2')
                    return c;
            }

            return '2';
        }

        public string Print()
        {
            var printer = new SpaceImagePrinter();
            return printer.Print(_grid);
        }

        public int Checksum
        {
            get
            {
                var layer = LayerWithFewestZeros;
                return layer.NumberOfOnes * layer.NumberOfTwos;
            }
        }

        private SpaceImageLayer LayerWithFewestZeros
        {
            get { return _layers.OrderBy(o => o.NumberOfZeros).First(); }
        }
    }
    
    public class SpaceImagePrinter
    {
        public string Print(IList<IList<char>> grid)
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

            return sb.ToString().Trim();
        }
    }
    
    public class SpaceImageDimensions
    {
        public const int Width = 25;
        public const int Height = 6;
    }
    
    public class SpaceImageLayer
    {
        private readonly string _data;
        private readonly int _width;
        private readonly IList<IList<char>> _grid;
        
        public int NumberOfZeros => GetCharCount(_data, '0');
        public int NumberOfOnes => GetCharCount(_data, '1');
        public int NumberOfTwos => GetCharCount(_data, '2');
        
        public SpaceImageLayer(string data, int width = SpaceImageDimensions.Width)
        {
            _data = data;
            _width = width;
            _grid = CreateGrid(data);
        }

        private IList<IList<char>> CreateGrid(string data)
        {
            var rows = GetRows(data).ToList();
            return new List<IList<char>>(rows);
        }

        private IEnumerable<IList<char>> GetRows(string imageData)
        {
            for (var i = 0; i < imageData.Length; i += _width)
            {
                yield return new List<char>(imageData.Substring(i, _width).ToCharArray());
            }
        }

        public char GetChar(int x, int y)
        {
            return _grid[y][x];
        }

        public string Print()
        {
            var printer = new SpaceImagePrinter();
            return printer.Print(_grid);
        }

        private int GetCharCount(string data, char character)
        {
            var count = 0;
            foreach (var c in data)
            {
                if (c == character)
                    count++;
            }
            return count;
        }
    }
}