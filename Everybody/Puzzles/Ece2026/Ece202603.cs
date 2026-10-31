using Pzl.Common;
using Pzl.Tools.Lists;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2026;

[Name("")]
public class Ece202603 : EverybodyEventPuzzle
{
    [Puzzle("a78aa95f2c49631f8cf0f58c476b3bf8")]
    public long Part1(string input) => input.Split(LineBreaks.Single).Sum(ConvertIsoToDecimal);

    [Puzzle("a4aad1206e2f3ebffc0fb6153b251740")]
    public long Part2(string input) => input.Split(LineBreaks.Single).Sum(ConvertIsoToDecimal);

    [Puzzle("d07911955fda275d7995c4b052ee4440")]
    public long Part3(string input) => input.Split(LineBreaks.Single).Sum(ConvertIso2ToDecimal);

    private static long ConvertIsoToDecimal(string iso)
    {
        var (baseString, digitString) = GetStrings(iso);
        return ConvertIsoToDecimal(baseString, digitString);
    }

    private static long ConvertIso2ToDecimal(string iso)
    {
        var (baseString, digitString) = GetStrings(iso);
        var result = ConvertIsoToDecimal(baseString, digitString);
        var num = long.Parse(digitString) - 1;

        while (num > 0)
        {
            var test = ConvertIsoToDecimal(baseString, num.ToString());
            if (test == result)
                return 0;
            
            num -= 1;
        }

        return result;
    }
    
    private static long ConvertIsoToDecimal(string baseString, string digitString)
    {
        var result = 0L;
        var bases = GetIntArray(baseString);
        var digits = GetIntArray(digitString);
        var zip = digits.Zip(bases).ToList();
        for (var i = 0; i < zip.Count; i++)
        {
            var (d, b) = zip[i];
            result += d * (long)Math.Pow(b, i);
        }
        
        return result;
    }

    private static (string, string) GetStrings(string iso)
    {
        var (baseString, digitString) = Numbers.DigitsFromString(iso[(iso.IndexOf('-') + 1)..]);
        return (AdjustBaseString(baseString, digitString.Length), digitString);
    }

    private static string AdjustBaseString(string baseString, int targetLength)
    {
        var adjusted = string.Concat(Enumerable.Repeat(baseString, targetLength / baseString.Length + 1));
        return adjusted.Substring(adjusted.Length - targetLength, targetLength);
    }

    private static int[] GetIntArray(string baseString) =>
        [.. baseString.ToCharArray().Reversed().Select(o => o.ToString()).Select(int.Parse)];
}