using System.Text;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201614;

public class KeyGenerator(int stretchCount)
{
    private readonly HashFactory _hashFactory = new();
    private readonly Dictionary<int, byte[]> _hashes = new();
    private readonly Dictionary<(int, byte), bool> _fiveInARowOf = new();
    private readonly Dictionary<int, bool> _fiveInARow = new();
    private readonly (byte, byte)[] _byteCache = BuildByteCache();

    public int GetIndexOfNThKey(string salt, int n)
    {
        var keyCount = 0;
        var index = 0;
        while (keyCount < n)
        {
            if (IsKey(salt, index, GetHash(salt, index)))
                keyCount++;

            index++;
        }
        
        return index - 1;
    }

    public bool IsKey(string salt, int index, byte[] hash) => 
        TryGetRepeatingByte(hash, out var repeatingByte) && 
        Next1000HashesHasFiveInARowOf(salt, index + 1, repeatingByte);

    public static bool TryGetRepeatingByte(byte[] hash, out byte repeatingByte)
    {
        var count = 0;
        
        for (var i = 1; i < hash.Length; i++)
        {
            count = hash[i] == hash[i - 1] ? count + 1 : 0;

            if (count != 2)
                continue;
            
            repeatingByte = hash[i];
            return true;
        }

        repeatingByte = byte.MinValue;
        return false;
    }
    
    private bool Next1000HashesHasFiveInARowOf(string salt, int fromIndex, byte searchFor)
    {
        for (var index = fromIndex; index < fromIndex + 1000; index++)
        {
            if (HasFiveInARowOf(salt, index, searchFor))
                return true;
        }
        
        return false;
    }

    private bool HasFiveInARowOf(string salt, int index, byte searchFor)
    {
        if (_fiveInARow.TryGetValue(index, out var hasFiveInARow) && !hasFiveInARow)
            return false;
        
        if (_fiveInARowOf.TryGetValue((index, searchFor), out var hasFiveInARowOf))
            return hasFiveInARowOf;

        var hash = GetHash(salt, index);
        hasFiveInARow = HasFiveInARow(hash);
        _fiveInARow[index] = hasFiveInARow;

        if (!hasFiveInARow)
        {
            _fiveInARowOf[(index, searchFor)] = false;
            return false;
        }

        hasFiveInARowOf = HasFiveInARowOf(hash, searchFor);
        _fiveInARowOf[(index, searchFor)] = hasFiveInARowOf;
        return hasFiveInARowOf;
    }
    
    public static bool HasFiveInARowOf(byte[] hash, byte searchFor)
    {
        var count = 0;
        foreach (var b in hash)
        {
            count = b == searchFor ? count + 1 : 0;
            
            if(count == 5)
                return true;
        }

        return false;
    }

    private static bool HasFiveInARow(byte[] hash)
    {
        var count = 0;
        
        for (var i = 1; i < hash.Length; i++)
        {
            count = hash[i] == hash[i - 1] ? count + 1 : 0;

            if (count == 4)
                return true;
        }
        
        return false;
    }
    
    public byte[] GetHash(string salt, int index)
    {
        if (_hashes.TryGetValue(index, out var hash))
            return hash;

        hash = CreateHash(salt + index);
        _hashes.Add(index, hash);
        return hash;
    }
    
    private byte[] CreateSimpleHash(byte[] bytes) => 
        ConvertToHexBytes(_hashFactory.ByteHashFromBytes(bytes));

    public byte[] CreateHash(string str)
    {
        var hash = CreateSimpleHash(Encoding.ASCII.GetBytes(str));

        for (var count = 0; count < stretchCount; count++)
        {
            hash = CreateSimpleHash(hash);
        }

        return hash;
    }

    private byte[] ConvertToHexBytes(byte[] hashedBytes)
    {
        var hexBytes = new byte[32];
        var index = 0;
        foreach (var b in hashedBytes)
        {
            var (b1, b2) = _byteCache[b];
            hexBytes[index] = b1;
            hexBytes[index + 1] = b2;
            index += 2;
        }

        return hexBytes;
    }

    private static (byte, byte)[] BuildByteCache()
    {
        var cache = new(byte, byte)[byte.MaxValue + 1];
        for (int i = byte.MinValue; i <= byte.MaxValue; i++)
        {
            var bytes = Encoding.ASCII.GetBytes(ByteConverter.ToHexString((byte)i));
            cache[i] = (bytes[0], bytes[1]);
        }

        return cache;
    }
}