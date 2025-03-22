using FluentAssertions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202403;

[Name("Unformatted Readings")]
public class Codyssi202403 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select(o => int.Parse(o.Split(' ')[1])).Sum();
        return new PuzzleResult(sum, "91e41490538d35c28c473cc837069068");
    }

    public PuzzleResult Part2(string input)
    {
        var sum = CalculateSum(input);

        return new PuzzleResult(sum, "b54e3ab42745c500fdac546b4f65242b");
    }

    public PuzzleResult Part3(string input)
    {
        var sum = CalculateSum(input);
        var result = ToBase65(sum);
        return new PuzzleResult(result, "b1273b880eaaf6e24e986fdcdd291ef9");
    }
    
    private static long ParseLine((string v, int b) line) => ParseLine(line.v, line.b);
    private static long ParseLine(string v, int b) => Convert.ToInt32(v, b);
    
    private static long CalculateSum(string input) =>
        input.Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .Select(o => (o.First(), int.Parse(o.Last())))
            .Sum(ParseLine);
    
    private static string ToBase65(long v) => 
        ToBaseX(v, 65, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#");

    private static string ToBaseX(long v, int radix, string digits)
    {
        const int bitsInLong = 64;
        
        if (radix < 2 || radix > digits.Length)
            throw new ArgumentException("The radix must be >= 2 and <= " + digits.Length);

        if (v == 0)
            return "0";

        var index = bitsInLong - 1;
        var currentNumber = Math.Abs(v);
        var charArray = new char[bitsInLong];

        while (currentNumber != 0)
        {
            var remainder = (int)(currentNumber % radix);
            charArray[index--] = digits[remainder];
            currentNumber /= radix;
        }

        var result = new string(charArray, index + 1, bitsInLong - index - 1);
        if (v < 0) 
            result = "-" + result;

        return result;
    }
}