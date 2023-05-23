using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aoc.Common.Hashing;
using Aoc.Common.Strings;

namespace Aoc.Puzzles.Year2016.Day05;

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
                var hash = hashFactory.StringHashFromString(strToHash);
                pwd.Append(hash[5..6]);
            }

            _index++;
        }

        return pwd.ToString().ToLower();
    }
        
    public string Generate2(string key)
    {
        var hashFactory = new Hashfactory();
        const int pwdLength = 8;
        var pwdArray = new char?[pwdLength];

        while (_hashCache.Any())
        {
            var byteHash = _hashCache.First();
            _hashCache.RemoveAt(0);
            var position = byteHash[2];
            if (position < 8 && pwdArray[position] == null)
            {
                var hash = ByteConverter.ConvertToHexString(byteHash);
                var result = hash[6..7];
                pwdArray[position] = result[0];
            }
        }
            
        while (pwdArray.Any(o => o == null))
        {
            var byteHash = hashFactory.ByteHashFromString($"{key}{_index}");
            if (HasFiveLeadingZeros(byteHash))
            {
                var position = byteHash[2];
                if (position < 8 && pwdArray[position] == null)
                {
                    var hash = ByteConverter.ConvertToHexString(byteHash);
                    var result = hash.Substring(6, 1);
                    pwdArray[position] = result[0];
                }
            }

            _index++;
        }

        var pwd = new StringBuilder();
        foreach (var c in pwdArray)
        {
            pwd.Append(c);
        }
        return pwd.ToString().ToLower();
    }

    private static bool HasFiveLeadingZeros(IReadOnlyList<byte> bytes)
    {
        return bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 16;
    }
}