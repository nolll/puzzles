using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace App.Common.Hashing
{
    public class AsciiKnotHasher
    {
        private readonly int[] _list;
        private int _listIndex;
        private int _skip;
        private readonly int _lengthIndex;
        private readonly int[] _lengths;

        public string Hash { get; }

        public AsciiKnotHasher(string input)
        {
            var lengths = input.ToCharArray().Select(o => (int)o).ToList();
            lengths.AddRange(new[] { 17, 31, 73, 47, 23 });
            _lengths = lengths.ToArray();
            _list = FillList(256);
            _listIndex = 0;
            _skip = 0;

            for (var round = 0; round < 64; round++)
            {
                for (var i = 0; i < _lengths.Length; i++)
                {
                    _lengthIndex = i;
                    var values = ReadValues();
                    var reversed = values.Reverse().ToArray();
                    WriteValues(reversed);
                    MoveForward();
                }
            }

            var denseHash = GetReducedHash().ToList();
            Hash = GetHash(denseHash);
        }

        private string GetHash(IEnumerable<int> denseHash)
        {
            var hash = new StringBuilder();
            foreach (var v in denseHash)
            {
                var str = v.ToString("X2").PadLeft(2);
                hash.Append(str);
            }
            return hash.ToString().ToLower();
        }

        private IEnumerable<int> GetReducedHash()
        {
            for (var i = 0; i < _list.Length; i += 16)
            {
                yield return _list[i] ^ 
                             _list[i + 1] ^ 
                             _list[i + 2] ^ 
                             _list[i + 3] ^ 
                             _list[i + 4] ^ 
                             _list[i + 5] ^ 
                             _list[i + 6] ^ 
                             _list[i + 7] ^
                             _list[i + 8] ^ 
                             _list[i + 9] ^ 
                             _list[i + 10] ^ 
                             _list[i + 11] ^ 
                             _list[i + 12] ^ 
                             _list[i + 13] ^ 
                             _list[i + 14] ^ 
                             _list[i + 15];
            }
        }

        private int[] FillList(int size)
        {
            var list = new int[size];
            for (var i = 0; i < size; i++) 
                list[i] = i;

            return list;
        }

        private void MoveForward()
        {
            var steps = _lengths[_lengthIndex] + _skip;
            for (var i = 0; i < steps; i++)
            {
                _listIndex++;
                if (_listIndex >= _list.Length)
                    _listIndex = 0;
            }
            _skip++;
        }

        private void WriteValues(int[] values)
        {
            var current = _listIndex;
            foreach (var v in values)
            {
                _list[current] = v;
                current++;
                if (current >= _list.Length)
                    current = 0;
            }
        }

        private IList<int> ReadValues()
        {
            var length = _lengths[_lengthIndex];
            var values = new int[length];
            var current = _listIndex;
            for (var i = 0; i < length; i++)
            {
                values[i] = _list[current];
                current++;
                if (current >= _list.Length)
                    current = 0;
            }

            return values;
        }
    }
}