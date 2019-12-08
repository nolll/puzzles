using System.Collections.Generic;
using System.Linq;

namespace Core.SpaceImages
{
    public class SpaceImageLayer
    {
        private readonly string _data;
        private readonly IList<IList<char>> _matrix;
        
        public int NumberOfZeros => GetCharCount(_data, '0');
        public int NumberOfOnes => GetCharCount(_data, '1');
        public int NumberOfTwos => GetCharCount(_data, '2');
        
        public SpaceImageLayer(string data)
        {
            _data = data;
            _matrix = CreateMatrix(data);
        }

        private IList<IList<char>> CreateMatrix(string data)
        {
            var rows = GetRows(data).ToList();
            return new List<IList<char>>(rows);
        }

        private IEnumerable<IList<char>> GetRows(string imageData)
        {
            const int rowLength = SpaceImageDimensions.Width;
            for (var i = 0; i < imageData.Length; i += rowLength)
            {
                yield return new List<char>(imageData.Substring(i, rowLength).ToCharArray());
            }
        }

        public char GetChar(int x, int y)
        {
            return _matrix[y][x];
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