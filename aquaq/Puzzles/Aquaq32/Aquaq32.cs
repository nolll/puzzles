using System.Text.RegularExpressions;
using Common.Puzzles;

namespace Aquaq.Puzzles.Aquaq32;

public class Aquaq32 : AquaqPuzzle
{
    private static readonly Regex ClutterRegex = new("[^\\(\\)\\[\\]\\{\\}]");

    public override string Name => "In Parenthesis";

    protected override PuzzleResult Run()
    {
        var lines = InputFile.Split(Environment.NewLine);
        var result = lines.Count(IsBalanced);

        return new PuzzleResult(result, "7750ca3559e5b8e1f44210283368fc16");
    }

    public static bool IsBalanced(string input)
    {
        var s = RemoveMatchingParenthesis(RemoveClutter(input));
        return s.Length == 0;
    }

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

    private static string RemoveClutter(string input) => ClutterRegex.Replace(input, "");
}