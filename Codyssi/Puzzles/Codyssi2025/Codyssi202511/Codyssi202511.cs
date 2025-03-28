using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202511;

[Name("Games in a Storm")]
public class Codyssi202511 : CodyssiPuzzle
{
    private readonly Dictionary<char, int> _chars = BuildCharDictionary();
    
    public PuzzleResult Part1(string input)
    {
        var base10Numbers = GetBase10Numbers(input);
        return new PuzzleResult(base10Numbers.Max(), "8c350540f538dfbb227fe9c86f28e4db");
    }

    public PuzzleResult Part2(string input)
    {
        var sum = GetBase10Numbers(input).Sum();
        var base68 = ToBase68(sum);
        return new PuzzleResult(base68, "c677dee7cd5d27aa22c862b72d8317a1");
    }

    public PuzzleResult Part3(string input)
    {
        var sum = GetBase10Numbers(input).Sum();
        var b = 0;
        while (Math.Pow(b, 4) < sum)
            b++;
        
        return new PuzzleResult(b, "9b2126706485aa8c523f0ff6809cfe15");
    }

    private IEnumerable<long> GetBase10Numbers(string input)
    {
        var base10 = input.Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .Select(o => ConvertToBase10(o[0], int.Parse(o[1])));

        return base10;
    }
    
    private long ConvertToBase10(string s, int b) => 
        s.Reversed().ToArray().Select((t, i) => _chars[t] * (long)Math.Pow(b, i)).Sum();

    private static Dictionary<char, int> BuildCharDictionary()
    {
        const string cs = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        var i = 0;
        var d = new Dictionary<char, int>();
        foreach (var c in cs)
        {
            d[c] = i;
            i++;
        }

        return d;
    }

    private static string ToBase68(long v) => 
        Conversion.ToBaseX(v, 68, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#$%^");
}