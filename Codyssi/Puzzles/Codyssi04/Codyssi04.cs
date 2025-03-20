using System.Text;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi04;

[Name("Aeolian Transmissions")]
public class Codyssi04 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var score = input.Replace(LineBreaks.Single, "").Select(GetScore).Sum();
        return new PuzzleResult(score, "655c9020b1a64d3b94692c414d0aaca1");
    }

    public PuzzleResult Part2(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var score = 0;
        foreach (var line in lines)
        {
            var charsToRemove = line.Length / 10;
            var numberToInsert = line.Length - 2 * charsToRemove;
            var str = $"{line[..charsToRemove]}{numberToInsert}{line[^charsToRemove..]}";
            score += str.Select(GetScore).Sum();
        }
        return new PuzzleResult(score, "8e544343c5f171e432e0b356d86e28c6");
    }

    public PuzzleResult Part3(string input)
    {
        var lines = input.Split(LineBreaks.Single);
        var score = 0;
        foreach (var line in lines)
        {
            var sb = new StringBuilder();
            var current = ' ';
            var count = 0;
            foreach (var c in line)
            {
                if (c != current && count > 0)
                {
                    sb.Append($"{count}{current}");
                    count = 0;
                }

                current = c;
                count++;
            }
            
            sb.Append($"{count}{current}");

            var str = sb.ToString();
            score += str.Select(GetScore).Sum();
        }
        return new PuzzleResult(score, "5129cb83e24bb391c88e0378d0a19562");
    }
    
    private static int GetScore(char c) => char.IsNumber(c) 
        ? int.Parse(c.ToString()) 
        : c - 'A' + 1;
}