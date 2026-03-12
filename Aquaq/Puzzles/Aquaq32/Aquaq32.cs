using System.Text.RegularExpressions;
using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aquaq.Puzzles.Aquaq32;

[Name("In Parenthesis")]
public partial class Aquaq32 : AquaqPuzzle
{
    [Puzzle("8b52d401a6c9cf4350dc85e2cebcec81")]
    public int Solve(string input) => input.Split(LineBreaks.Single).Count(IsBalanced);

    public static bool IsBalanced(string input) => RemoveMatchingParenthesis(RemoveClutter(input)).Length == 0;

    private static string RemoveMatchingParenthesis(string input)
    {
        var s = input;
        var lastLength = int.MaxValue;
        while (s.Length < lastLength)
        {
            lastLength = s.Length;
            s = s.Replace("()", "").Replace("{}", "").Replace("[]", "");
        }

        return s;
    }

    private static string RemoveClutter(string input) => ClutterRegex().Replace(input, "");
    
    [GeneratedRegex("[^\\(\\)\\[\\]\\{\\}]")]
    private static partial Regex ClutterRegex();
}