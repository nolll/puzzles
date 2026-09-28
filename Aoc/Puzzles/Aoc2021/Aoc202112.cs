using Pzl.Common;
using Pzl.Tools.Strings;

namespace Pzl.Aoc.Puzzles.Aoc2021;

[Name("Passage Pathing")]
public class Aoc202112 : AocPuzzle
{
    [Puzzle("f0ddaeeb33f1a0ff7a113ef020e9decd")]
    public int Part1(string input) => new CaveSystem(input, false).CountPaths();

    [Puzzle("435c45d6610ccd392e06c43e52654eb5")]
    public int Part2(string input) => new CaveSystem(input, true).CountPaths();

    public class CaveSystem
    {
        private readonly bool _allowSmallRevisit;
        private readonly Dictionary<string, HashSet<string>> _connections;

        public CaveSystem(string input, bool allowSmallRevisit)
        {
            _allowSmallRevisit = allowSmallRevisit;
            var lines = input.Split(LineBreaks.Single);
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
                connection = [];
                _connections.Add(from, connection);
            }

            connection.Add(to);
        }

        public int CountPaths() => FindPaths("-", "start", "-").Count;

        private List<string> FindPaths(string path, string current, string lowercasePath)
        {
            var paths = new List<string>();
            path = $"{path}{current}-";
            if (current.IsLower())
                lowercasePath = $"{lowercasePath}{current}-";
            var links = _connections[current];

            if (current == "end")
                return new List<string> { path };

            foreach (var link in links)
            {
                var isUpper = link.IsUpper();
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
}