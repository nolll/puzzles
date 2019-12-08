namespace Core.SpaceImages
{
    public class ImageLayer
    {
        private readonly string _data;
        public int NumberOfZeros => GetCharCount(_data, '0');
        public int NumberOfOnes => GetCharCount(_data, '1');
        public int NumberOfTwos => GetCharCount(_data, '2');

        public ImageLayer(string data)
        {
            _data = data;
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

    public class SpaceImage
    {

    }
}