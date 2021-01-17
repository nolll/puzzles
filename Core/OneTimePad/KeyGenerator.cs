using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Tools;

namespace Core.OneTimePad
{
    public class KeyGenerator
    {
        private readonly Hashfactory _hashFactory;
        private readonly IDictionary<int, byte[]> _hashes;
        private readonly Dictionary<byte, byte[]> _byteCache;
        private readonly Dictionary<int, bool> _fiveInARowCache;

        public KeyGenerator()
        {
            _hashFactory = new Hashfactory();
            _hashes = new Dictionary<int, byte[]>();
            _byteCache = BuildByteCache();
            _fiveInARowCache = new Dictionary<int, bool>();
        }

        public int GetIndexOf64ThKey(string salt, int stretchCount = 0)
        {
            var keys = new List<byte[]>();
            var index = 0;
            while (keys.Count < 64)
            {
                var hashedBytes = GetHash(salt, index, stretchCount);
                var isKey = IsKey(salt, index, hashedBytes, stretchCount);
                if (isKey)
                    keys.Add(hashedBytes);

                index++;
            }

            return index - 1;
        }

        public bool IsKey(string salt, int index, byte[] hashedBytes, int stretchCount)
        {
            var repeatingByte = GetRepeatingChar(hashedBytes);
            if (repeatingByte != null)
            {
                if (Next1000HashesHasFiveInARowOf(salt, index + 1, repeatingByte.Value, stretchCount))
                {
                    return true;
                }
            }

            return false;
        }

        public byte? GetRepeatingChar(byte[] bytes)
        {
            for (var i = 0; i < bytes.Length - 2; i++)
            {
                var v = bytes[i];
                if (bytes[i + 1] == v && bytes[i + 2] == v)
                    return v;
            }

            return null;
        }
        
        private bool Next1000HashesHasFiveInARowOf(string salt, int fromIndex, byte searchFor, int stretchCount)
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

        private bool HashHasFiveInARow(byte[] bytes)
        {
            for (var i = 0; i < bytes.Length - 4; i++)
            {
                var b = bytes[i];
                if (bytes[i + 1] == b && bytes[i + 2] == b && bytes[i + 3] == b && bytes[i + 4] == b)
                    return true;
            }

            return false;
        }

        public bool HashHasFiveInARowOf(byte[] bytes, byte b)
        {
            for (var i = 0; i < bytes.Length - 4; i++)
            {
                if (bytes[i] == b && bytes[i + 1] == b && bytes[i + 2] == b && bytes[i + 3] == b && bytes[i + 4] == b)
                    return true;
            }

            return false;
        }

        public byte[] GetHash(string salt, int index, int stretchCount)
        {
            if (_hashes.TryGetValue(index, out var hash))
                return hash;
            hash = CreateHash(salt, index, stretchCount);
            _hashes.Add(index, hash);
            return hash;
        }

        private byte[] CreateHash(string salt, int index, int stretchCount)
        {
            var str = string.Concat(salt, index.ToString());
            return CreateStretchedHash(str, stretchCount);
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