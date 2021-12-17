using System.Collections.Generic;

namespace App.Puzzles.Year2019.Day04;

public class PasswordValidator
{
    public bool IsValidPart1(int pwd)
    {
        var chars = pwd.ToString().ToCharArray();
        var hasPair = PasswordAnalyzer.HasGroup(chars);
        if (!hasPair)
            return false;

        var hasCorrectOrder = HasCorrectOrder(chars);
        if (!hasCorrectOrder)
            return false;

        return true;
    }

    public bool IsValidPart2(int pwd)
    {
        var chars = pwd.ToString().ToCharArray();
        var hasPair = PasswordAnalyzer.HasGroupOfTwo(chars);
        if (!hasPair)
            return false;

        var hasCorrectOrder = HasCorrectOrder(chars);
        if (!hasCorrectOrder)
            return false;

        return true;
    }

    private static bool HasCorrectOrder(IEnumerable<char> chars)
    {
        var lastChar = ' ';
        foreach (var c in chars)
        {
            if (c < lastChar)
                return false;

            lastChar = c;
        }

        return true;
    }
}