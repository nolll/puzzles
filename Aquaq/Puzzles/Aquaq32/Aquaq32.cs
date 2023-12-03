﻿using System.Text.RegularExpressions;
using Puzzles.Common.Puzzles;
using Puzzles.Common.Strings;

namespace Puzzles.Aquaq.Puzzles.Aquaq32;

public class Aquaq32 : AquaqPuzzle
{
    private static readonly Regex ClutterRegex = new("[^\\(\\)\\[\\]\\{\\}]");

    public override string Name => "In Parenthesis";

    protected override PuzzleResult Run()
    {
        var lines = StringReader.ReadLines(InputFile);
        var result = lines.Count(IsBalanced);

        return new PuzzleResult(result, "8b52d401a6c9cf4350dc85e2cebcec81");
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