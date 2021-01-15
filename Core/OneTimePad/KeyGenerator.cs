using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Tools;

namespace Core.OneTimePad
{
    public class KeyGenerator
    {
        private readonly Hashfactory _hashFactory;
        private readonly IDictionary<int, string> _hashes;
        private readonly Dictionary<byte, byte[]> _byteCache;

        public KeyGenerator()
        {
            _hashFactory = new Hashfactory();
            _hashes = new Dictionary<int, string>();
            _byteCache = BuildByteCache();
        }

        public int GetIndexOf64ThKey(string salt, int stretchCount = 0)
        {
            var keys = new List<string>();
            var index = 0;
            while (keys.Count < 64)
            {
                var hash = GetHash(salt, index, stretchCount);
                var isKey = IsKey(salt, index, hash, stretchCount);
                if (isKey)
                    keys.Add(hash);

                index++;
            }

            return index - 1;
        }

        private bool IsKey(string salt, int index, string hash, int stretchCount)
        {
            var repeatingChar = GetRepeatingChar(hash);
            if (repeatingChar != null)
            {
                if (Next1000HashesHasFiveInARowOf(salt, index + 1, repeatingChar.Value, stretchCount))
                {
                    return true;
                }
            }

            return false;
        }

        private char? GetRepeatingChar(string hash)
        {
            var regex = new Regex("(.)\\1{2,}");
            var match = regex.Match(hash);
            if (match.Success)
            {
                return match.Value.First();
            }

            return null;
        }

        private bool Next1000HashesHasFiveInARowOf(string salt, int fromIndex, char searchFor, int stretchCount)
        {
            var count = 0;
            var stringToSearchFor = new string(searchFor, 5);
            while (count < 1000)
            {
                var index = fromIndex + count;
                var hash = GetHash(salt, index, stretchCount);
                if (hash.Contains(stringToSearchFor))
                    return true;
                count++;
            }

            return false;
        }

        private string GetHash(string salt, int index, int stretchCount)
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
            return CreateStretchedHash(str, stretchCount);
        }

        private byte[] CreateSimpleHash(byte[] bytes)
        {
            return _hashFactory.ByteHashFromBytes(bytes);
        }

        public string CreateStretchedHash(string str, int iterations)
        {
            var hashedBytes = CreateSimpleHash(Encoding.ASCII.GetBytes(str));
            var bytes = new byte[32];

            var count = 0;
            while (count < iterations)
            {
                ConvertToHexBytes(ref bytes, hashedBytes);
                hashedBytes = CreateSimpleHash(bytes);
                count++;
            }

            return ByteConverter.ConvertToString(hashedBytes);
        }

        private void ConvertToHexBytes(ref byte[] workingBytes, byte[] hashedBytes)
        {
            var index = 0;
            foreach (var hashedByte in hashedBytes)
            {
                Buffer.BlockCopy(_byteCache[hashedByte], 0, workingBytes, index, 2);
                index += 2;
            }
        }

        private Dictionary<byte, byte[]> BuildByteCache()
        {
            var cache = new Dictionary<byte, byte[]>();
            for (int i = byte.MinValue; i <= byte.MaxValue; i++)
            {
                var b = (byte) i;
                var str = ByteConverter.ConvertToString(b);
                var bytes = Encoding.ASCII.GetBytes(str);
                cache.Add(b, bytes);
            }

            return cache;
        }
    }
}