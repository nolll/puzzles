using System.Text;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201605;

public class PasswordGenerator
{
    private readonly List<byte[]> _hashCache;
    private int _index;

    public PasswordGenerator()
    {
        _hashCache = new List<byte[]>();
        _index = 1;
    }

    public string Generate1(string key)
    {
        var hashFactory = new Hashfactory();
        var pwd = new StringBuilder();
        while (pwd.Length < 8)
        {
            var strToHash = $"{key}{_index}";
            var byteHash = hashFactory.ByteHashFromString(strToHash);
            if (HasFiveLeadingZeros(byteHash))
            {
                _hashCache.Add(byteHash);
                var hash = ByteConverter.ToHexString(byteHash[2]);
                pwd.Append(hash[1]);
            }

            _index++;
        }

        return pwd.ToString().ToLower();
    }
        
    public string Generate2(string key)
    {
        var hashFactory = new Hashfactory();
        const int pwdLength = 8;
        var pwdArray = new char[pwdLength];

        var filledPositions = 0;
        const int allPositionsFilled = 36;
        foreach (var cashedHash in _hashCache)
        {
            var position = cashedHash[2];
            if (position < pwdLength && pwdArray[position] == default)
            {
                var hash = ByteConverter.ToHexString(cashedHash[3]);
                pwdArray[position] = hash[0];
                filledPositions += position + 1;
            }
        }

        while (filledPositions < allPositionsFilled)
        {
            var byteHash = hashFactory.ByteHashFromString($"{key}{_index}");
            if (HasFiveLeadingZeros(byteHash))
            {
                var position = byteHash[2];
                if (position < pwdLength && pwdArray[position] == default)
                {
                    var hash = ByteConverter.ToHexString(byteHash[3]);
                    pwdArray[position] = hash[0];
                    filledPositions += position + 1;
                }
            }

            _index++;
        }

        return string.Join("", pwdArray);
    }

    private static bool HasFiveLeadingZeros(byte[] bytes)
    {
        return bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 16;
    }
}