using System.Collections.Generic;
using System.Linq;

namespace App.Puzzles.Year2015.Day11;

public class CorporatePasswordValidator
{
    public bool IsValid(string pwd)
    {
        if (ContainsForbiddenCharacters(pwd))
            return false;

        if (!ContainsTwoPairs(pwd))
            return false;

        if (!ContainsSequence(pwd))
            return false;

        return true;
    }

    public string FindNextPassword(string pwd)
    {
        do
        {
            pwd = Next(pwd);
        } while (!IsValid(pwd));

        return pwd;
    }

    private string Next(string pwd)
    {
        var chars = pwd.ToCharArray();
        var i = chars.Length - 1;
        while (chars[i] == 'z')
        {
            chars[i] = 'a';
            i--;
        }

        chars[i] = (char)(chars[i] + 1);

        return string.Concat(chars);
    }

    private bool ContainsForbiddenCharacters(string pwd)
    {
        return pwd.Contains('i') || pwd.Contains('o') || pwd.Contains('l');
    }

    private bool ContainsSequence(string pwd)
    {
        for (var i = 0; i < pwd.Length - 2; i++)
        {
            var current = pwd[i];
            var secondChar = current + 1;
            var thirdChar = current + 2;

            if (secondChar == pwd[i + 1] && thirdChar == pwd[i + 2])
                return true;
        }

        return false;
    }

    private bool ContainsTwoPairs(string pwd)
    {
        var pairs = GetPairs(pwd).Distinct();
        return pairs.Count() >= 2;
    }

    private IEnumerable<string> GetPairs(string pwd)
    {
        for (var i = 0; i < pwd.Length - 1; i++)
        {
            var current = pwd[i];
            var next = pwd[i + 1];
            if (current == next)
            {
                yield return string.Concat(current, next);
                i++;
            }
        }
    }
}