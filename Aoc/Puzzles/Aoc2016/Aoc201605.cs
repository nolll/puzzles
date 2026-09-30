using System.Text;
using Pzl.Common;
using Pzl.Tools.Cryptography;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2016;

[Name("How About a Nice Game of Chess?")]
public class Aoc201605 : AocPuzzle
{
    private const int PwdLength = 8;

    [Puzzle("40c5b62ed7b9f223838482c66c629a2a")]
    public string Part1(string input)
    {
        var index = 1;
        var hashFactory = new HashFactory();
        var pwd = new StringBuilder();
        var keyBytes = Encoding.ASCII.GetBytes(input);
        while (pwd.Length < PwdLength)
        {
            var bytesToHash = Encoding.ASCII.GetBytes(index.ToString());
            var byteHash = hashFactory.ByteHash([.. keyBytes, .. bytesToHash]);
            if (HasFiveLeadingZeros(byteHash))
            {
                var hash = ByteConverter.ToHexString(byteHash[2]);
                pwd.Append(hash[1]);
            }

            index++;
        }

        return pwd.ToString().ToLower();
    }

    [Puzzle("73bc206f743ba68d2e5dea0e9fbf96a4")]
    public string Part2(string input)
    {
        var index = 1;
        var hashFactory = new HashFactory();
        var pwdArray = new char[PwdLength];
        var keyBytes = Encoding.ASCII.GetBytes(input);

        var filledPositions = 0;
        const int allPositionsFilled = 36;

        while (filledPositions < allPositionsFilled)
        {
            var bytesToHash = Encoding.ASCII.GetBytes(index.ToString());
            var byteHash = hashFactory.ByteHash([.. keyBytes, .. bytesToHash]);
            if (HasFiveLeadingZeros(byteHash))
            {
                var position = byteHash[2];
                if (position < PwdLength && pwdArray[position] == default)
                {
                    var hash = ByteConverter.ToHexString(byteHash[3]);
                    pwdArray[position] = hash[0];
                    filledPositions += position + 1;
                }
            }

            index++;
        }

        return string.Join("", pwdArray);
    }

    private static bool HasFiveLeadingZeros(byte[] bytes) => bytes[0] == 0 && bytes[1] == 0 && bytes[2] < 16;
}