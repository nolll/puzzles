using System;
using System.Collections.Generic;
using System.Text;
using Aoc.Common.Hashing;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2016.Day14;

public class KeyGenerator
{
    private readonly Hashfactory _hashFactory;
    private readonly IDictionary<int, byte[]> _hashes;
    private readonly IDictionary<byte, byte[]> _byteCache;
    private readonly IDictionary<int, byte?> _repeatingByteCache;
    private readonly IDictionary<int, bool> _fiveInARowCache;
    private readonly IDictionary<(int, byte), bool> _fiveInARowOfCache;

    public KeyGenerator()
    {
        _hashFactory = new Hashfactory();
        _hashes = new Dictionary<int, byte[]>();
        _byteCache = BuildByteCache();
        _repeatingByteCache = new Dictionary<int, byte?>();
        _fiveInARowCache = new Dictionary<int, bool>();
        _fiveInARowOfCache = new Dictionary<(int, byte), bool>();
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

    public bool IsKey(string salt, int index, byte[] hash, int stretchCount)
    {
        if (!_repeatingByteCache.TryGetValue(index, out var repeatingByte))
        {
            repeatingByte = GetRepeatingByte(hash);
            _repeatingByteCache.Add(index, repeatingByte);
        }

        return repeatingByte != null && Next1000HashesHasFiveInARowOf(salt, index + 1, repeatingByte.Value, stretchCount);
    }

    public static byte? GetRepeatingByte(byte[] hash)
    {
        var limit = hash.Length - 2;
        for (var i = 0; i < limit; i++)
        {
            var c = hash[i];
            if (hash[i + 1] == c && hash[i + 2] == c)
                return c;
        }

        return null;
    }
    
    private bool Next1000HashesHasFiveInARowOf(string salt, int fromIndex, byte searchFor, int stretchCount)
    {
        for (var count = 0; count < 1000; count++)
        {
            var index = fromIndex + count;

            if (!_fiveInARowCache.TryGetValue(index, out var hasFiveInARow))
            {
                var hashedBytes = GetHash(salt, index, stretchCount);
                hasFiveInARow = HashHasFiveInARow(hashedBytes);
                _fiveInARowCache.Add(index, hasFiveInARow);
            }

            if (hasFiveInARow)
            {
                if (!_fiveInARowOfCache.TryGetValue((index, searchFor), out var hasFiveInARowOf))
                {
                    var hashedBytes = GetHash(salt, index, stretchCount);
                    hasFiveInARowOf = HashHasFiveInARowOf(hashedBytes, searchFor);
                    _fiveInARowOfCache.Add((index, searchFor), hasFiveInARowOf);
                }

                if (hasFiveInARowOf)
                    return true;
            }
        }
        
        return false;
    }
    
    public bool HashHasFiveInARow(byte[] hash)
    {
        var limit = hash.Length - 4;
        for (var i = 0; i < limit; i++)
        {
            var c = hash[i];
            if (hash[i + 1] == c &&
                hash[i + 2] == c &&
                hash[i + 3] == c &&
                hash[i + 4] == c)
                return true;
        }

        return false;
    }

    public bool HashHasFiveInARowOf(byte[] hash, byte searchFor)
    {
        var limit = hash.Length - 4;
        for (var i = 0; i < limit; i++)
        {
            if (hash[i] == searchFor &&
                hash[i + 1] == searchFor &&
                hash[i + 2] == searchFor &&
                hash[i + 3] == searchFor &&
                hash[i + 4] == searchFor)
                return true;
        }

        return false;
    }
    
    public byte[] GetHash(string salt, int index, int stretchCount = 0)
    {
        if (_hashes.TryGetValue(index, out var hash))
            return hash;

        hash = CreateHash(salt, index, stretchCount);
        _hashes.Add(index, hash);
        return hash;
    }
    
    public byte[] CreateHash(string salt, int index, int stretchCount = 0)
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

        for (var count = 0; count < iterations; count++)
        {
            hashedBytes = CreateSimpleHash(hashedBytes);
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

    private static Dictionary<byte, byte[]> BuildByteCache()
    {
        var cache = new Dictionary<byte, byte[]>();
        for (int i = byte.MinValue; i <= byte.MaxValue; i++)
        {
            var b = (byte) i;
            cache.Add(b, Encoding.ASCII.GetBytes(ByteConverter.ConvertToHexString(b)));
        }

        return cache;
    }
}