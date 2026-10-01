using System.Text;
using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[IsSlow] // 13.5s for part 2
[Name("One-Time Pad")]
[Comment("Slow hashing")]
public class Aoc201614 : AocPuzzle
{
    private const int ListLength = 1000;
    private readonly HashFactory _hashFactory = new();

    [Puzzle("ab424c3c48235af9c7eadd8da2414dea")]
    public int Part1(string input) => GetIndexOfNThKey(0, input, 64);

    [Puzzle("f84f1a02e789615187ec700dcf71ab79")]
    public int Part2(string input) => GetIndexOfNThKey(2016, input, 64);

    public int GetIndexOfNThKey(int stretchCount, string salt, int n)
    {
        var byteCache = BuildByteCache();
        var keyCount = 0;
        var index = 0;
        var list = new LinkedList<HashInfo>();
        while (keyCount < n)
        {
            var hash = CreateHash(byteCache, stretchCount, $"{salt}{index}");
            list.AddLast(GetHashInfo(hash));

            if (index > ListLength)
            {
                list.RemoveFirst();
                if (list.First!.Value.HasThree && TryGetRepeatingByte(list.First!.Value.Hash, out var repeatingByte) &&
                    HasFiveInARowOf(list, repeatingByte))
                    keyCount++;
            }

            index++;
        }

        return index - ListLength - 1;
    }

    public bool TryGetRepeatingByte(byte[] hash, out byte repeatingByte)
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

    public bool HasFiveInARowOf(byte[] hash, byte searchFor)
    {
        var count = 0;
        foreach (var b in hash)
        {
            count = b == searchFor ? count + 1 : 0;

            if (count == 5)
                return true;
        }

        return false;
    }

    private static HashInfo GetHashInfo(byte[] hash)
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

        return new(hash, hasThree, hasFive);
    }

    private byte[] CreateSimpleHash((byte, byte)[] byteCache, byte[] bytes) => ConvertToHexBytes(byteCache, _hashFactory.ByteHash(bytes));

    public byte[] CreateHash((byte, byte)[] byteCache, int stretchCount, string str)
    {
        var hash = CreateSimpleHash(byteCache, Encoding.ASCII.GetBytes(str));

        for (var count = 0; count < stretchCount; count++)
        {
            hash = CreateSimpleHash(byteCache, hash);
        }

        return hash;
    }

    private byte[] ConvertToHexBytes((byte, byte)[] byteCache, byte[] hashedBytes)
    {
        var hexBytes = new byte[32];
        var index = 0;
        foreach (var b in hashedBytes)
        {
            (hexBytes[index++], hexBytes[index++]) = byteCache[b];
        }

        return hexBytes;
    }

    public (byte, byte)[] BuildByteCache()
    {
        var cache = new (byte, byte)[byte.MaxValue + 1];
        for (int i = byte.MinValue; i <= byte.MaxValue; i++)
        {
            var bytes = Encoding.ASCII.GetBytes(ByteConverter.ToHexString((byte)i));
            cache[i] = (bytes[0], bytes[1]);
        }

        return cache;
    }

    private record HashInfo(byte[] Hash, bool HasThree, bool HasFive);
}