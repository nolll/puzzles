namespace Pzl.Aoc.Puzzles.Aoc2015.Aoc201511;

public class CorporatePasswordValidator
{
    public static bool IsValid(string pwd) => 
        !ContainsForbiddenCharacters(pwd) && ContainsTwoPairs(pwd) && ContainsSequence(pwd);

    public static string FindNextPassword(string pwd)
    {
        do
        {
            pwd = Next(pwd);
        } while (!IsValid(pwd));

        return pwd;
    }

    private static string Next(string pwd)
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

    private static bool ContainsForbiddenCharacters(string pwd) => 
        pwd.Contains('i') || pwd.Contains('o') || pwd.Contains('l');

    private static bool ContainsSequence(string pwd)
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

    private static bool ContainsTwoPairs(string pwd) => GetPairs(pwd).Distinct().Count() >= 2;

    private static IEnumerable<string> GetPairs(string pwd)
    {
        for (var i = 0; i < pwd.Length - 1; i++)
        {
            var current = pwd[i];
            var next = pwd[i + 1];
            if (current != next) 
                continue;
            
            yield return string.Concat(current, next);
            i++;
        }
    }
}