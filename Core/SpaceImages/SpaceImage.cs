using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.SpaceImages
{
    public class SpaceImage
    {
        private readonly IList<SpaceImageLayer> _layers;
        private readonly IList<IList<char>> _matrix;

        public SpaceImage(string imageData)
        {
            _layers = GetLayers(imageData).ToList();
            _matrix = ComposeImage();
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
            var sb = new StringBuilder();
            foreach (var row in _matrix)
            {
                foreach (var pixel in row)
                {
                    var output = pixel == '1' ? 'X' : ' ';
                    sb.Append(output);
                }

                sb.AppendLine();
            }

            return sb.ToString();
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
}