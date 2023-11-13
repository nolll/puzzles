using System.Text;
using Puzzles.common.Cryptography;
using Puzzles.common.Strings;

namespace Puzzles.aoc.Puzzles.Aoc2016.Aoc201614;

public class KeyGenerator
{
    private readonly Hashfactory _hashFactory;
    private readonly IDictionary<int, byte[]> _hashes;
    private readonly IDictionary<byte, byte[]> _byteCache;
    private readonly IDictionary<int, byte?> _repeatingByteCache;
    private readonly IDictionary<(int, byte), bool> _fiveInARowOfCache;

    public KeyGenerator()
    {
        _hashFactory = new Hashfactory();
        _hashes = new Dictionary<int, byte[]>();
        _byteCache = BuildByteCache();
        _repeatingByteCache = new Dictionary<int, byte?>();
        _fiveInARowOfCache = new Dictionary<(int, byte), bool>();
    }

    public int GetIndexOfNThKey(string salt, int n, int stretchCount)
    {
        var keyCount = 0;
        var index = 0;
        while (keyCount < n)
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

            if (!_fiveInARowOfCache.TryGetValue((index, searchFor), out var hasFiveInARowOf))
            {
                var hashedBytes = GetHash(salt, index, stretchCount);
                hasFiveInARowOf = HasFiveInARowOf(hashedBytes, searchFor);
                _fiveInARowOfCache.Add((index, searchFor), hasFiveInARowOf);
            }

            if (hasFiveInARowOf)
                return true;
        }
        
        return false;
    }
    
    public static bool HasFiveInARowOf(byte[] hash, byte searchFor)
    {
        for (var i = 0; i < hash.Length - 4; i++)
        {

            if (hash[i] == searchFor &&
                hash[i + 1] == searchFor &&
                hash[i + 2] == searchFor &&
                hash[i + 3] == searchFor &&
                hash[i + 4] == searchFor)
                return true;

            //if (hash[i] == searchFor &&
            //    hash[i + 1] == searchFor &&
            //    hash[i + 2] == searchFor &&
            //    hash[i + 3] == searchFor &&
            //    hash[i + 4] == searchFor)
            //    return true;
        }

        return false;
    }
    
    public byte[] GetHash(string salt, int index, int stretchCount)
    {
        if (_hashes.TryGetValue(index, out var hash))
            return hash;

        hash = CreateHash(salt + index, stretchCount);
        _hashes.Add(index, hash);
        return hash;
    }
    
    private byte[] CreateSimpleHash(byte[] bytes) => 
        ConvertToHexBytes(_hashFactory.ByteHashFromBytes(bytes));

    public byte[] CreateHash(string str, int stretchCount)
    {
        var hash = CreateSimpleHash(Encoding.ASCII.GetBytes(str));

        for (var count = 0; count < stretchCount; count++)
        {
            hash = CreateSimpleHash(hash);
        }

        return hash;
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
            cache.Add(b, Encoding.ASCII.GetBytes(ByteConverter.ToHexString(b)));
        }

        return cache;
    }
}