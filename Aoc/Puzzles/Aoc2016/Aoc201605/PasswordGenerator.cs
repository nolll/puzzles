using System.Text;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016.Aoc201605;

public class PasswordGenerator
{
    private readonly List<byte[]> _cache = [];
    private int _index = 1;

    public string Generate1(string key)
    {
        var hashFactory = new HashFactory();
        var pwd = new StringBuilder();
        var keyBytes = Encoding.ASCII.GetBytes(key);
        while (pwd.Length < 8)
        {
            var bytesToHash = Encoding.ASCII.GetBytes(_index.ToString());
            var byteHash = hashFactory.ByteHash([..keyBytes, ..bytesToHash]);
            if (HasFiveLeadingZeros(byteHash))
            {
                _cache.Add(byteHash);
                var hash = ByteConverter.ToHexString(byteHash[2]);
                pwd.Append(hash[1]);
            }

            _index++;
        }

        return pwd.ToString().ToLower();
    }
        
    public string Generate2(string key)
    {
        var hashFactory = new HashFactory();
        const int pwdLength = 8;
        var pwdArray = new char[pwdLength];
        var keyBytes = Encoding.ASCII.GetBytes(key);

        var filledPositions = 0;
        const int allPositionsFilled = 36;
        foreach (var cashedHash in _cache)
        {
            var position = cashedHash[2];
            if (position >= pwdLength || pwdArray[position] != default)
                continue;
            
            var hash = ByteConverter.ToHexString(cashedHash[3]);
            pwdArray[position] = hash[0];
            filledPositions += position + 1;
        }

        while (filledPositions < allPositionsFilled)
        {
            var bytesToHash = Encoding.ASCII.GetBytes(_index.ToString());
            var byteHash = hashFactory.ByteHash([..keyBytes, ..bytesToHash]);
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

    private static bool HasFiveLeadingZeros(byte[] bytes) => bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 16;
}