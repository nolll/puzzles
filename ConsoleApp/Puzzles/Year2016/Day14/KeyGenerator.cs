using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Tools;

namespace ConsoleApp.Puzzles.Year2016.Day14
{
    public class KeyGenerator
    {
        private readonly Hashfactory _hashFactory;
        private readonly IDictionary<int, string> _hashes;
        private readonly Dictionary<byte, byte[]> _byteCache;
        private readonly Dictionary<int, bool> _fiveInARowCache;

        public KeyGenerator()
        {
            _hashFactory = new Hashfactory();
            _hashes = new Dictionary<int, string>();
            _byteCache = BuildByteCache();
            _fiveInARowCache = new Dictionary<int, bool>();
        }

        public int GetIndexOf64ThKey(string salt, int stretchCount = 0)
        {
            var keyCount = 0;
            var index = 0;
            while (keyCount < 64)
            {
                var hash = GetHash(salt, index, stretchCount);
                var isKey = IsKey(salt, index, hash, stretchCount);
                if (isKey)
                    keyCount++;

                index++;
            }

            return index - 1;
        }

        public bool IsKey(string salt, int index, string hash, int stretchCount)
        {
            var repeatingChar = GetRepeatingChar(hash);
            if (repeatingChar != null)
            {
                var searchFor = new string(repeatingChar.Value, 5);
                if (Next1000HashesHasFiveInARowOf(salt, index + 1, searchFor, stretchCount))
                {
                    return true;
                }
            }

            return false;
        }

        public char? GetRepeatingChar(string hash)
        {
            var regex = new Regex("(.)\\1{2,}");
            var match = regex.Match(hash);
            if (match.Success)
                return match.Value.First();

            return null;
        }

        private bool Next1000HashesHasFiveInARowOf(string salt, int fromIndex, string searchFor, int stretchCount)
        {
            var count = 0;
            while (count < 1000)
            {
                var index = fromIndex + count;
                var hashedBytes = GetHash(salt, index, stretchCount);
                
                if (!_fiveInARowCache.TryGetValue(index, out var hasFiveInARow))
                {
                    hasFiveInARow = HashHasFiveInARow(hashedBytes);
                    _fiveInARowCache.Add(index, hasFiveInARow);
                }
                
                if (hasFiveInARow)
                {
                    if (HashHasFiveInARowOf(hashedBytes, searchFor))
                        return true;
                }

                count++;
            }

            return false;
        }

        private bool HashHasFiveInARow(string hash)
        {
            var regex = new Regex("(.)\\1{4,}");
            var match = regex.Match(hash);
            return match.Success;
        }

        public bool HashHasFiveInARowOf(string hash, string searchFor)
        {
            return hash.Contains(searchFor);
        }

        public string GetHash(string salt, int index, int stretchCount)
        {
            if (_hashes.TryGetValue(index, out var hash))
                return hash;
            hash = CreateHash(salt, index, stretchCount);
            _hashes.Add(index, hash);
            return hash;
        }

        private string CreateHash(string salt, int index, int stretchCount)
        {
            var str = string.Concat(salt, index.ToString());
            var hashedBytes = CreateStretchedHash(str, stretchCount);
            return ByteConverter.ConvertToString(hashedBytes);
        }

        private byte[] CreateSimpleHash(byte[] bytes)
        {
            return ConvertToHexBytes(_hashFactory.ByteHashFromBytes(bytes));
        }

        public byte[] CreateStretchedHash(string str, int iterations)
        {
            var hashedBytes = CreateSimpleHash(Encoding.ASCII.GetBytes(str));

            var count = 0;
            while (count < iterations)
            {
                hashedBytes = CreateSimpleHash(hashedBytes);
                count++;
            }

            return hashedBytes;
        }

        private byte[] ConvertToHexBytes(IEnumerable<byte> hashedBytes)
        {
            var hexBytes = new byte[32];
            var index = 0;
            foreach (var hashedByte in hashedBytes)
            {
                Buffer.BlockCopy(_byteCache[hashedByte], 0, hexBytes, index, 2);
                index += 2;
            }

            return hexBytes;
        }

        private Dictionary<byte, byte[]> BuildByteCache()
        {
            var cache = new Dictionary<byte, byte[]>();
            for (int i = byte.MinValue; i <= byte.MaxValue; i++)
            {
                var b = (byte) i;
                var str = ByteConverter.ConvertToHexString(b);
                var bytes = Encoding.ASCII.GetBytes(str);
                cache.Add(b, bytes);
            }

            return cache;
        }
    }
}