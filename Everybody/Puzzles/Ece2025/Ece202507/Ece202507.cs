using Pzl.Common;
using Pzl.Tools.HashSets;
using Pzl.Tools.Strings;

namespace Pzl.Everybody.Puzzles.Ece2025.Ece202507;

[Name("Namegraph")]
public class Ece202507 : EverybodyEventPuzzle
{
    private const int MinLength = 7;
    private const int MaxLength = 11;

    public PuzzleResult Part1(string input)
    {
        var (names, rules) = Parse(input);
        var name = names.First(o => IsValidName(o, rules));
        
        return new PuzzleResult(name, "f58cf5d880834e0e0823d1891e8b7a9e");
    }

    public PuzzleResult Part2(string input)
    {
        var (names, rules) = Parse(input);

        var sum = 0;
        for (var i = 0; i < names.Length; i++)
        {
            if (IsValidName(names[i], rules))
                sum += i + 1;
        }
        
        return new PuzzleResult(sum, "8a08f6570e988d7a1b4c17645d937b1f");
    }

    public PuzzleResult Part3(string input)
    {
        var (prefixes, rules) = Parse(input);
        prefixes = prefixes.Where(o => IsValidName(o, rules)).ToArray();

        var allNames = new HashSet<string>();
        foreach (var prefix in prefixes)
        {
            allNames.AddRange(GetNamesFromPrefix(prefix, rules));
        }

        return new PuzzleResult(allNames.Count, "cabe960d882be6a00b754e46052381df");
    }

    private static List<string> GetNamesFromPrefix(string prefix, Dictionary<char, char[]> rules)
    {
        var minLength = MinLength - prefix.Length;
        var maxLength = MaxLength - prefix.Length;
        var names = new List<string>();
        for (var length = minLength; length <= maxLength; length++)
        {
            names.AddRange(GetNames(prefix, rules, length));
        }
        
        return names;
    }

    private static List<string> GetNames(string s, Dictionary<char,char[]> rules, int level)
    {
        if (level == 0)
            return [s];
        
        if (!rules.TryGetValue(s.Last(), out var rule))
            return [];

        var names = new List<string>();
        foreach (var next in rule)
        {
            names.AddRange(GetNames(s + next, rules, level - 1));
        }
        
        return names;
    }

    private static bool IsValidName(string name, Dictionary<char, char[]> rules)
    {
        for (var i = 0; i < name.Length - 1; i++)
        {
            var c = name[i];
            if (!rules.TryGetValue(c, out var rule))
                continue;
            
            if (!rule.Contains(name[i + 1]))
                return false;
        }

        return true;
    }

    private static (string[], Dictionary<char, char[]>) Parse(string input)
    {
        var groups = input.Split(LineBreaks.Double);
        var names = groups[0].Split(',');
        var rules = groups[1].Split(LineBreaks.Single)
            .Select(o => o.Split(" > "))
            .ToDictionary(k => k[0][0], v => v[1].Split(',').Select(o => o[0]).ToArray());
        return (names, rules);
    }
}