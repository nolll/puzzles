using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Passage Pathing")]
public class Aoc202112 : AocPuzzle
{
    [Puzzle("f0ddaeeb33f1a0ff7a113ef020e9decd")]
    public int Part1(string input) => Solve(input, false);

    [Puzzle("435c45d6610ccd392e06c43e52654eb5")]
    public int Part2(string input) => Solve(input, true);

    private static int Solve(string input, bool allowRevisit)
    {
        var lines = input.Split(LineBreaks.Single);
        var connections = new Dictionary<string, HashSet<string>>();
        foreach (var line in lines)
        {
            var parts = line.Split('-');
            var left = parts[0];
            var right = parts[1];

            AddConnection(connections, left, right);
            AddConnection(connections, right, left);
        }

        return FindPaths(connections, allowRevisit, "-", "start", "-").Count;
    }
    
    private static void AddConnection(Dictionary<string, HashSet<string>> connections, string from, string to)
    {
        if (!connections.TryGetValue(from, out var connection))
        {
            connection = [];
            connections.Add(from, connection);
        }

        connection.Add(to);
    }

    private static List<string> FindPaths(Dictionary<string, HashSet<string>> connections, bool allowRevisit, string path, string current,
        string lowercasePath)
    {
        var paths = new List<string>();
        path = $"{path}{current}-";
        if (current.IsLower())
            lowercasePath = $"{lowercasePath}{current}-";
        var links = connections[current];

        if (current == "end")
            return [path];

        foreach (var link in links)
        {
            var wasUsed = WasUsed(lowercasePath, link, allowRevisit);
            var canBeUsed = link.IsUpper() || !wasUsed;
            if (canBeUsed)
                paths.AddRange(FindPaths(connections, allowRevisit, path, link, lowercasePath));
        }

        return paths;
    }

    private static bool WasUsed(string lowercasePath, string cave, bool allowRevisit)
    {
        if (cave == "start")
            return true;

        if (allowRevisit)
        {
            var list = lowercasePath.Trim('-').Split('-');
            var distinct = list.Distinct();

            if (list.Length == distinct.Count())
                return false;
        }

        return lowercasePath.IndexOf(cave, StringComparison.Ordinal) > -1;
    }
}