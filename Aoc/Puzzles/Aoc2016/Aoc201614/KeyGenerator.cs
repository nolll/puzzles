using System.Text;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201614;

public class KeyGenerator(int stretchCount)
{
    private const int ListLength = 1000;
    private readonly HashFactory _hashFactory = new();
    private readonly (byte, byte)[] _byteCache = BuildByteCache();

    public int GetIndexOfNThKey(string salt, int n)
    {
        var keyCount = 0;
        var index = 0;
        var list = new LinkedList<HashInfo>();
        while (keyCount < n)
        {
            var has1000 = index > ListLength;
            var hash = CreateHash($"{salt}{index}");
            var (hasThree, hasFive) = HasRepeadedChars(hash);
            list.AddLast(new HashInfo(hash, hasThree, hasFive));

            if (has1000)
            {
                list.RemoveFirst();
                if (list.First!.Value.HasThree && TryGetRepeatingByte(list.First!.Value.Hash, out var repeatingByte) && HasFiveInARowOf(list, repeatingByte))
                    keyCount++;
            }

            index++;
        }
        
        return index - ListLength - 1;
    }

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
    
    private bool HasFiveInARowOf(LinkedList<HashInfo> hashInfos, byte searchFor)
    {
        var current = hashInfos.First?.Next;
        while (current is not null)
        {
            if (current.Value.HasFive && HasFiveInARowOf(current.Value.Hash, searchFor))
                return true;

            current = current.Next;
        }

        return false;
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

    private static (bool hasThree, bool hasFive) HasRepeadedChars(byte[] hash)
    {
        var count = 0;
        var hasThree = false;
        var hasFive = false;
        
        for (var i = 1; i < hash.Length; i++)
        {
            count = hash[i] == hash[i - 1] ? count + 1 : 0;

            if (count == 2)
                hasThree = true;

            if (count == 4)
            {
                hasFive = true;
                break;
            }
        }
        
        return (hasThree, hasFive);
    }

    private byte[] CreateSimpleHash(byte[] bytes) => 
        ConvertToHexBytes(_hashFactory.ByteHash(bytes));

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
            (hexBytes[index++], hexBytes[index++]) = _byteCache[b];
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

    private class HashInfo(byte[] hash, bool hasThree, bool hasFive)
    {
        public byte[] Hash { get; } = hash;
        public bool HasThree { get; } = hasThree;
        public bool HasFive { get; } = hasFive;
    }
}