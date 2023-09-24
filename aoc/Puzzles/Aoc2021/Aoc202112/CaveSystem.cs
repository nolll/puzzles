using System;
using System.Collections.Generic;
using System.Linq;
using Common.Strings;

namespace Aoc.Puzzles.Aoc2021.Aoc202112;

public class CaveSystem
{
    private readonly bool _allowSmallRevisit;
    private readonly Dictionary<string, HashSet<string>> _connections;

    public CaveSystem(string input, bool allowSmallRevisit)
    {
        _allowSmallRevisit = allowSmallRevisit;
        var lines = PuzzleInputReader.ReadLines(input);
        _connections = new Dictionary<string, HashSet<string>>();
        foreach (var line in lines)
        {
            var parts = line.Split('-');
            var left = parts[0];
            var right = parts[1];

            AddConnection(left, right);
            AddConnection(right, left);
        }
    }

    private void AddConnection(string from, string to)
    {
        if (!_connections.TryGetValue(from, out var connection))
        {
            connection = new HashSet<string>();
            _connections.Add(from, connection);
        }

        connection.Add(to);
    }
        
    public int CountPaths()
    {
        var paths = FindPaths("-", "start", "-");

        return paths.Count;
    }

    private List<string> FindPaths(string path, string current, string lowercasePath)
    {
        var paths = new List<string>();
        path = $"{path}{current}-";
        if (StringTools.IsLower(current))
            lowercasePath = $"{lowercasePath}{current}-";
        var links = _connections[current];

        if (current == "end")
            return new List<string> { path };

        foreach (var link in links)
        {
            var isUpper = StringTools.IsUpper(link);
            var wasUsed = WasUsed(lowercasePath, link);
            var canBeUsed = isUpper || !wasUsed;
            if (canBeUsed)
                paths.AddRange(FindPaths(path, link, lowercasePath));
        }

        return paths;
    }

    private bool WasUsed(string lowercasePath, string cave)
    {
        if (cave == "start")
            return true;

        if (_allowSmallRevisit)
        {
            var list = lowercasePath.Trim('-').Split('-');
            var distinct = list.Distinct();

            if (list.Length == distinct.Count())
                return false;
        }

        return lowercasePath.IndexOf(cave, StringComparison.Ordinal) > -1;
    }
}