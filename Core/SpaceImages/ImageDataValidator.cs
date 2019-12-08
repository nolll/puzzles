using System.Collections.Generic;
using System.Linq;

namespace Core.SpaceImages
{
    public class ImageDataValidator
    {
        private IList<ImageLayer> _layers;

        public ImageDataValidator(string imageData)
        {
            _layers = GetLayers(imageData).ToList();
        }

        private IEnumerable<ImageLayer> GetLayers(string imageData)
        {
            const int layerLength = 25 * 6;
            for (var i = 0; i < imageData.Length; i += layerLength)
            {
                yield return new ImageLayer(imageData.Substring(i, layerLength));
            }
        }

        public int Checksum
        {
            get
            {
                var layer = LayerWithFewestZeros;
                return layer.NumberOfOnes * layer.NumberOfTwos;
            }
        }

        private ImageLayer LayerWithFewestZeros
        {
            get { return _layers.OrderBy(o => o.NumberOfZeros).First(); }
        }
    }
}