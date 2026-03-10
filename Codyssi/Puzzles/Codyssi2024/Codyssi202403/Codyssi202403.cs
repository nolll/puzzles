using Pzl.Common;
using Pzl.Tools.Numbers;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2024.Codyssi202403;

[Name("Unformatted Readings")]
public class Codyssi202403 : CodyssiPuzzle
{
    [Puzzle("91e41490538d35c28c473cc837069068")]
    public PuzzleResult Part1(string input)
    {
        var sum = input.Split(LineBreaks.Single).Select(o => int.Parse(o.Split(' ')[1])).Sum();
        return new PuzzleResult(sum);
    }

    [Puzzle("b54e3ab42745c500fdac546b4f65242b")]
    public PuzzleResult Part2(string input)
    {
        var sum = CalculateSum(input);

        return new PuzzleResult(sum);
    }

    [Puzzle("b1273b880eaaf6e24e986fdcdd291ef9")]
    public PuzzleResult Part3(string input)
    {
        var sum = CalculateSum(input);
        var result = ToBase65(sum);
        return new PuzzleResult(result);
    }
    
    public static string ToBase65(long v) => 
        Conversion.ToBaseX(v, 65, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!@#");
    
    private static long ParseLine((string v, int b) line) => ParseLine(line.v, line.b);
    private static long ParseLine(string v, int b) => Convert.ToInt32(v, b);
    
    private static long CalculateSum(string input) =>
        input.Split(LineBreaks.Single)
            .Select(o => o.Split(' '))
            .Select(o => (o.First(), int.Parse(o.Last())))
            .Sum(ParseLine);
}