using Pzl.Common;
using Pzl.Tools.Chars;
using Pzl.Tools.Strings;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202508;

[Name("Risky Shortcut")]
public class Codyssi202508 : CodyssiPuzzle
{
    public PuzzleResult Part1(string input)
    {
        var count = input.Count(Chars.IsAlphabetic);
        return new PuzzleResult(count, "6a585e7eb1dcbd71879f4142df959659");
    }

    public PuzzleResult Part2(string input)
    {
        var count = input.Split(LineBreaks.Single).Select(o => Reduce(o, CanBeReducedPart2).Length).Sum();
        return new PuzzleResult(count, "4a22a07fa4753a619b3ea70e509f1e15");
    }

    public PuzzleResult Part3(string input)
    {
        var count = input.Split(LineBreaks.Single).Select(o => Reduce(o, CanBeReducedPart3).Length).Sum();
        return new PuzzleResult(count, "b976227ab97881f7991bcdad55f92f31");
    }
    
    private static string Reduce(string s, Func<char, char, bool> reduceCondition)
    {
        var last = "";
        var current = s;
        while (last != current)
        {
            last = current;
            for (var i = 0; i < current.Length - 1; i++)
            {
                if (!reduceCondition(current[i], current[i + 1]))
                    continue;
                
                current = current[..i] + current[(i + 2)..];
                break;
            }
        }

        return current;
    }
    
    private static bool CanBeReducedPart2(char a, char b)
    {
        var aNumeric = Chars.IsNumeric(a);
        var bNumeric = Chars.IsNumeric(b);

        return aNumeric && !bNumeric || !aNumeric && bNumeric;
    }
    
    private static bool CanBeReducedPart3(char a, char b) => 
        Chars.IsNumeric(a) && Chars.IsAlphabetic(b) || Chars.IsAlphabetic(a) && Chars.IsNumeric(b);
}